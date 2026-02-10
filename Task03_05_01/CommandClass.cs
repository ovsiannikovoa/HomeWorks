using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task03_05_01;

namespace Task03_05_01
{
    [Transaction(TransactionMode.Manual)]
    public class CommandClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uiDoc = uiapp.ActiveUIDocument;
            Document doc = uiDoc.Document;

            try
            {
                IList<Reference> pickedRefs = uiDoc.Selection.PickObjects(
                    ObjectType.Element,
                    new FamilyInstanceSelectionFilter(),
                    "Выберите элементы (только элементы семейств)");

                Dictionary<string, int> countsByCategory = new Dictionary<string, int>();

                int total = 0;
                foreach (var pickedRef in pickedRefs)
                {
                    Element el = doc.GetElement(pickedRef);
                    FamilyInstance fi = el as FamilyInstance;
                    if (fi == null) continue;

                    total++;

                    string categoryName = fi.Category != null ? fi.Category.Name : "Без категории";
                    if (countsByCategory.ContainsKey(categoryName))
                    {
                        countsByCategory[categoryName]++;
                    }
                    else
                    {
                        countsByCategory[categoryName] = 1;
                    }
                }

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Общее количество элементов: {total}");
                sb.AppendLine();
                sb.AppendLine("Распределение по категориям:");

                foreach (var kvp in countsByCategory.OrderByDescending(k => k.Value).ThenBy(k => k.Key))
                {
                    sb.AppendLine($"{kvp.Key} → {kvp.Value}");
                }

                TaskDialog.Show("Статистика по выбранным элементам", sb.ToString());
            }
            catch (OperationCanceledException)
            {
                TaskDialog.Show("Инфо", "Вы отменили выбор элементов.");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ошибка", ex.Message);
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}
