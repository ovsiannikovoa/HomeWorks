using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.Linq;
using System.Collections.Generic;

namespace Task03_04_01
{
    [Transaction(TransactionMode.Manual)]
    public class CommandClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Application application = uiapp.Application;
            UIDocument uiDoc = uiapp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            var collector = new FilteredElementCollector(doc)
                .OfClass(typeof(Wall))
                .WhereElementIsNotElementType()
                .Cast<Wall>()
                .ToList();

            if (collector == null || collector.Count == 0)
            {
                TaskDialog.Show("Статистика стен", "В проекте нет стен");
                return Result.Succeeded;
            }

            List<double> lengthsInternal = new List<double>();
            foreach (var w in collector)
            {
                Parameter pLen = w.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                double lenInternal = 0.0;
                if (pLen != null && pLen.StorageType == StorageType.Double)
                {
                    lenInternal = pLen.AsDouble();
                }
                lengthsInternal.Add(lenInternal);
            }

            int count = lengthsInternal.Count;
            double maxInternal = lengthsInternal.Max();
            double minInternal = lengthsInternal.Min();
            double avgInternal = lengthsInternal.Average();

            double maxMeters = UnitUtils.ConvertFromInternalUnits(maxInternal, DisplayUnitType.DUT_METERS);
            double minMeters = UnitUtils.ConvertFromInternalUnits(minInternal, DisplayUnitType.DUT_METERS);
            double avgMeters = UnitUtils.ConvertFromInternalUnits(avgInternal, DisplayUnitType.DUT_METERS);

            Wall longestWall = collector
                .FirstOrDefault(w =>
                {
                    var p = w.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    return p != null && Math.Abs(p.AsDouble() - maxInternal) < 1e-9;
                });

            Wall shortestWall = collector
                .FirstOrDefault(w =>
                {
                    var p = w.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
                    return p != null && Math.Abs(p.AsDouble() - minInternal) < 1e-9;
                });

            string report = $"Статистика по стенам проекта:\n\n" +
                            $"Общее количество стен: {count}\n" +
                            $"Самая длинная стена: {maxMeters:F3} м\n" +
                            $"Самая короткая стена: {minMeters:F3} м\n" +
                            $"Средняя длина стен: {avgMeters:F3} м";

            // Показываем отчет
            TaskDialog.Show("Статистика стен", report);

            // Меняем параметры в транзакции
            using (Transaction t = new Transaction(doc, "Пометить самую длинную и короткую стены"))
            {
                t.Start();

                // Используем встроенный параметр комментариев, если он есть
                BuiltInParameter commentsParam = BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS;

                if (longestWall != null)
                {
                    Parameter pComments = longestWall.get_Parameter(commentsParam);
                    if (pComments != null && !pComments.IsReadOnly)
                    {
                        pComments.Set("Самая длинная стена");
                    }
                    else
                    {
                        // Попытка через LookupParameter на случай локализованных шаблонов
                        var lp = longestWall.LookupParameter("Комментарии") ?? longestWall.LookupParameter("Comments");
                        if (lp != null && !lp.IsReadOnly) lp.Set("Самая длинная стена");
                    }
                }

                if (shortestWall != null)
                {
                    Parameter pComments = shortestWall.get_Parameter(commentsParam);
                    if (pComments != null && !pComments.IsReadOnly)
                    {
                        pComments.Set("Самая короткая стена");
                    }
                    else
                    {
                        var lp = shortestWall.LookupParameter("Комментарии") ?? shortestWall.LookupParameter("Comments");
                        if (lp != null && !lp.IsReadOnly) lp.Set("Самая короткая стена");
                    }
                }

                t.Commit();
            }

            TaskDialog.Show("Готово", "Комментарии установлены для самой длинной и самой короткой стены (если параметр доступен).");
            return Result.Succeeded;
        }
    }
}
