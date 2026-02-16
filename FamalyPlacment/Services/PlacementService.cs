using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using CSharpFunctionalExtensions;
using FamalyPlacment.Abstractions;
using FamalyPlacment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FamalyPlacment.Services
{
    public class PlacementService : IPlacementService
    {
        private readonly Document _document;

        public PlacementService(Document document)
        {
            _document = document;
        }

        /// <summary>
        /// Основной метод размещения
        /// </summary>
        public Result Place(TreeType treeType, int count)
        {
            return Validate(count)
                .Bind(() => FindFamily(treeType))
                .Bind(symbol => PlaceInstances(symbol, count));
        }

        /// <summary>
        /// Проверка корректности входных данных
        /// </summary>
        private Result Validate(int count)
        {
            if (count <= 0)
                return Result.Failure("Количество должно быть больше 0");

            return Result.Success();
        }

        /// <summary>
        /// Поиск семейства деревьев в категории Planting
        /// </summary>
        private Result<FamilySymbol> FindFamily(TreeType treeType)
        {
            string familyNamePart = string.Empty;

            switch (treeType)
            {
                case TreeType.Oak:
                    familyNamePart = "Oak";
                    break;

                case TreeType.Birch:
                    familyNamePart = "Birch";
                    break;

                case TreeType.Pine:
                    familyNamePart = "Pine";
                    break;

                default:
                    familyNamePart = "Tree";
                    break;
            }

            var familySymbol = new FilteredElementCollector(_document)
                .OfCategory(BuiltInCategory.OST_Planting)
                .OfClass(typeof(FamilySymbol))
                .OfType<FamilySymbol>()
                .FirstOrDefault(x =>
                    x.FamilyName.IndexOf(familyNamePart, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    x.Name.IndexOf(familyNamePart, StringComparison.InvariantCultureIgnoreCase) >= 0);

            if (familySymbol == null)
                return Result.Failure<FamilySymbol>(
                    $"Не найден типоразмер семейства для '{treeType}'");

            return Result.Success(familySymbol);
        }

        /// <summary>
        /// Размещение экземпляров по квадратной сетке
        /// </summary>
        private Result PlaceInstances(FamilySymbol familySymbol, int count)
        {
            try
            {
                // Шаг сетки — 2 метра
                double step = UnitUtils.ConvertToInternalUnits(
                    2.0,
                    DisplayUnitType.DUT_METERS);

                // Размер квадратной сетки
                int gridSize = (int)Math.Ceiling(Math.Sqrt(count));

                var points = new List<XYZ>();
                int placed = 0;

                for (int row = 0; row < gridSize && placed < count; row++)
                {
                    for (int col = 0; col < gridSize && placed < count; col++)
                    {
                        double x = col * step;
                        double y = row * step;

                        points.Add(new XYZ(x, y, 0));
                        placed++;
                    }
                }

                // Берём первый уровень в проекте
                var level = new FilteredElementCollector(_document)
                    .OfClass(typeof(Level))
                    .OfType<Level>()
                    .OrderBy(l => l.Elevation)
                    .FirstOrDefault();

                if (level == null)
                    return Result.Failure("Не найден уровень для размещения");

                using (Transaction transaction =
                    new Transaction(_document, "Размещение деревьев"))
                {
                    transaction.Start();

                    if (!familySymbol.IsActive)
                        familySymbol.Activate();

                    foreach (var point in points)
                    {
                        _document.Create.NewFamilyInstance(
                            point,
                            familySymbol,
                            level,
                            StructuralType.NonStructural);
                    }

                    transaction.Commit();
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }
    }
}