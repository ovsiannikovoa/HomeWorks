using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Task03_08_01.Helpers;
using Task03_08_01.Models;
using Task03_08_01.Services;

namespace Task03_08_01.ViewModels
{
    public class Task03_08_01ViewModel : INotifyPropertyChanged
    {
        private readonly IWallAnalyzerService _analyzer;
        private readonly UIDocument _uiDoc;

        public Task03_08_01ViewModel(IWallAnalyzerService analyzer, UIDocument uiDoc)
        {
            _analyzer = analyzer ?? throw new ArgumentNullException(nameof(analyzer));
            _uiDoc = uiDoc ?? throw new ArgumentNullException(nameof(uiDoc));

            SelectWallCommand = new RelayCommand(_ => SelectWall(), _ => true);
            CloseCommand = new RelayCommand(_ => CloseRequested?.Invoke(this, EventArgs.Empty));
        }

        private WallInfo _wallInfo;
        public WallInfo WallInfo
        {
            get => _wallInfo;
            set { _wallInfo = value; OnPropertyChanged(nameof(WallInfo)); }
        }

        public ICommand SelectWallCommand { get; }
        public ICommand CloseCommand { get; }

        // параметр нормы толщины (мм)
        private double _thicknessLimit = 200.0;
        public double ThicknessLimit
        {
            get => _thicknessLimit;
            set { _thicknessLimit = value; OnPropertyChanged(nameof(ThicknessLimit)); }
        }

        // событие, чтобы View мог закрыться
        public event EventHandler CloseRequested;

        // Реализация выбора стены в Revit — использует Revit API UI.Selection
        private void SelectWall()
        {
            try
            {
                var sel = _uiDoc.Selection;
                var refPick = sel.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new WallSelectionFilter(), "Выберите стену");
                if (refPick == null) return;

                Element elem = _uiDoc.Document.GetElement(refPick);
                var info = _analyzer.AnalyzeWall(elem, ThicknessLimit);
                WallInfo = info;
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                // отмена пользователем — игнорируем
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Ошибка", ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    // Небольшой фильтр для выбора только стен
    public class WallSelectionFilter : Autodesk.Revit.UI.Selection.ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return elem is Wall;
        }

        public bool AllowReference(Autodesk.Revit.DB.Reference reference, Autodesk.Revit.DB.XYZ position)
        {
            return false;
        }
    }
}