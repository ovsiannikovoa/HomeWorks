using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Task03_07_01
{
    [Transaction(TransactionMode.Manual)]
    public class CommandClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                Reference pickedRef = uiDoc.Selection.PickObject(ObjectType.Element, "Выберите экземпляр системного семейства");
                if (pickedRef == null)
                {
                    TaskDialog.Show("Информация", "Ничего не выбрано.");
                    return Result.Cancelled;
                }

                Element el = doc.GetElement(pickedRef);
                if (el == null)
                {
                    TaskDialog.Show("Ошибка", "Не удалось получить элемент.");
                    return Result.Failed;
                }

                Options options = new Options();
                GeometryElement geomElement = el.get_Geometry(options);

                List<Solid> solids = GetSolidsFromGeometry(geomElement);

                if (solids.Count == 0)
                {
                    TaskDialog.Show("Результат", "Не найдено Solid-объектов с положительным объёмом у выбранного элемента.");
                    return Result.Succeeded;
                }

                double totalVolume = 0.0;       
                double totalArea = 0.0;         
                long totalFaces = 0;
                long totalEdges = 0;
                double totalEdgeLength = 0.0;   

                foreach (var solid in solids)
                {
                    if (solid == null) continue;

                    if (solid.Volume > 0)
                    {
                        totalVolume += solid.Volume;
                    }

                    foreach (Face face in solid.Faces)
                    {
                        try
                        {
                            totalArea += face.Area;
                        }
                        catch
                        {
                        }
                        totalFaces++;
                    }

                    EdgeArray edges = solid.Edges;
                    foreach (Edge edge in edges)
                    {
                        if (edge == null) continue;
                        totalEdges++;
                        try
                        {
                            var curve = edge.AsCurve();
                            if (curve != null)
                                totalEdgeLength += curve.Length;
                        }
                        catch
                        {
                        }
                    }
                }

                double totalVolume_m3 = UnitUtils.ConvertFromInternalUnits(totalVolume, DisplayUnitType.DUT_CUBIC_METERS);
                double totalArea_m2 = UnitUtils.ConvertFromInternalUnits(totalArea, DisplayUnitType.DUT_SQUARE_METERS);
                double totalEdgeLength_m = UnitUtils.ConvertFromInternalUnits(totalEdgeLength, DisplayUnitType.DUT_METERS);

                var ci = CultureInfo.InvariantCulture;
                string msg =
                    $"Сводка по выбранному экземпляру: {Environment.NewLine}{Environment.NewLine}" +
                    $"Солидов (с положительным объёмом): {solids.Count}{Environment.NewLine}" +
                    $"Суммарный объём: {totalVolume:F6} (внутр. ед.) ≈ {totalVolume_m3:F3} м³{Environment.NewLine}" +
                    $"Суммарная площадь поверхностей: {totalArea:F6} (внутр. ед.) ≈ {totalArea_m2:F3} м²{Environment.NewLine}" +
                    $"Количество граней: {totalFaces}{Environment.NewLine}" +
                    $"Количество рёбер: {totalEdges}{Environment.NewLine}" +
                    $"Суммарная длина рёбер: {totalEdgeLength:F6} (внутр. ед.) ≈ {totalEdgeLength_m:F3} м";

                TaskDialog.Show("Статистика Solid'ов", msg);

                return Result.Succeeded;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ошибка", $"Произошла ошибка: {ex.Message}");
                return Result.Failed;
            }
        }

        private List<Solid> GetSolidsFromGeometry(GeometryElement geomElem)
        {
            var solids = new List<Solid>();
            if (geomElem == null) return solids;

            foreach (GeometryObject geomObj in geomElem)
            {
                if (geomObj == null) continue;

                if (geomObj is Solid solid)
                {
                    if (solid.Volume > 0)
                        solids.Add(solid);
                }
                else if (geomObj is GeometryInstance geomInst)
                {
                    GeometryElement instGeom = geomInst.GetSymbolGeometry();
                    if (instGeom != null)
                    {
                        solids.AddRange(GetSolidsFromGeometry(instGeom));
                    }
                }
                else if (geomObj is GeometryElement nestedGeom)
                {
                    solids.AddRange(GetSolidsFromGeometry(nestedGeom));
                }
            }

            return solids;
        }
    }
}