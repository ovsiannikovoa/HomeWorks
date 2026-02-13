using System;
using System.Windows;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Extensions.DependencyInjection;
using Task03_08_01.Services;
using Task03_08_01.ViewModels;
using Task03_08_01.Views;

namespace Task03_08_01.External
{
    [Transaction(TransactionMode.Manual)]
    public class Task03_08_01Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                // Настраиваем DI
                var services = new ServiceCollection();
                services.AddSingleton<IWallAnalyzerService, WallAnalyzerService>();
                // Регистрируем UIDocument как scoped singleton
                services.AddSingleton(commandData.Application.ActiveUIDocument);

                var provider = services.BuildServiceProvider();

                var analyzer = provider.GetRequiredService<IWallAnalyzerService>();
                var uiDoc = provider.GetRequiredService<UIDocument>();

                // Создаем VM и View через DI
                var vm = new Task03_08_01ViewModel(analyzer, uiDoc);
                var wnd = new Task03_08_01View(vm);

                // В Revit UI нужно показывать окно как диалог поверх родительского окна Revit
                var revitWindowHandle = new System.Windows.Interop.WindowInteropHelper(wnd).Handle;
                // Можно использовать WindowInteropHelper.Owner - но Revit требует внешнего родителя через Win32
                // Проще: показываем ShowDialog
                wnd.Owner = Application.Current?.MainWindow; // может быть null, но обычно работает
                wnd.ShowDialog();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ошибка", ex.Message);
                return Result.Failed;
            }
        }
    }
}