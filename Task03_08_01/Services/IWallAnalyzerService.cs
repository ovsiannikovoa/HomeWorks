using Autodesk.Revit.DB;
using Task03_08_01.Models;

namespace Task03_08_01.Services
{
    public interface IWallAnalyzerService
    {
        /// <summary>
        /// Анализирует стену и заполняет WallInfo. Возвращает null если что-то пошло не так.
        /// </summary>
        WallInfo AnalyzeWall(Element wallElement, double thicknessLimitMm = 200.0);
    }
}