using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task03_06_01
{
    [Transaction(TransactionMode.Manual)]
    public class CommandClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            if (uiDoc == null)
            {
                TaskDialog.Show("Ошибка", "Нет активного документа.");
                return Result.Failed;
            }

            var selectedIds = uiDoc.Selection.GetElementIds();

            if (selectedIds.Count != 2)
            {
                TaskDialog.Show("Ошибка", "Выберите 2 стены.");
                return Result.Failed;
            }

            Element elem1 = uiDoc.Document.GetElement(selectedIds.ElementAt(0));
            Element elem2 = uiDoc.Document.GetElement(selectedIds.ElementAt(1));

            Wall wall1 = elem1 as Wall;
            Wall wall2 = elem2 as Wall;

            if (wall1 == null || wall2 == null)
            {
                TaskDialog.Show("Ошибка", "Выберите именно стены.");
                return Result.Failed;
            }

            LocationCurve loc1 = wall1.Location as LocationCurve;
            LocationCurve loc2 = wall2.Location as LocationCurve;

            if (loc1 == null || loc2 == null)
            {
                TaskDialog.Show("Ошибка", "Не удалось получить геометрию одной из выбранных стен.");
                return Result.Failed;
            }

            Curve curve1 = loc1.Curve;
            Curve curve2 = loc2.Curve;

            if (curve1 == null || curve2 == null)
            {
                TaskDialog.Show("Ошибка", "Не удалось получить кривую расположения стены.");
                return Result.Failed;
            }

            XYZ dir1 = (curve1.GetEndPoint(1) - curve1.GetEndPoint(0));
            XYZ dir2 = (curve2.GetEndPoint(1) - curve2.GetEndPoint(0));

            XYZ dir1Plan = new XYZ(dir1.X, dir1.Y, 0);
            XYZ dir2Plan = new XYZ(dir2.X, dir2.Y, 0);

            double eps = 1e-9;
            if (dir1Plan.GetLength() < eps || dir2Plan.GetLength() < eps)
            {
                TaskDialog.Show("Ошибка", "Одна из стен имеет недопустимую плановую геометрию.");
                return Result.Failed;
            }

            dir1Plan = dir1Plan.Normalize();
            dir2Plan = dir2Plan.Normalize();

            XYZ normal1 = new XYZ(-dir1Plan.Y, dir1Plan.X, 0).Normalize();
            XYZ normal2 = new XYZ(-dir2Plan.Y, dir2Plan.X, 0).Normalize();

            double dotNormals = Math.Abs(normal1.DotProduct(normal2));
            double parallelTolerance = 1e-3;

            if (Math.Abs(dotNormals - 1.0) > parallelTolerance)
            {
                TaskDialog.Show("Результат", "Стены НЕ параллельны.");
                return Result.Succeeded;
            }

            XYZ mid1 = (curve1.GetEndPoint(0) + curve1.GetEndPoint(1)) * 0.5;
            XYZ mid2 = (curve2.GetEndPoint(0) + curve2.GetEndPoint(1)) * 0.5;

            XYZ vectorBetween = mid2 - mid1;

            double distanceInternal = Math.Abs(vectorBetween.DotProduct(normal1)); 

            double distanceMm = distanceInternal * 304.8;

            TaskDialog.Show("Результат", $"Перпендикулярное расстояние между стенами: {distanceMm:F3} мм");

            return Result.Succeeded;
        }

    }
}
