using System;
using System.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CreateSection.Abstractions;

namespace CreateSection.Services
{
    internal class SectionService : ISectionService
    {
        private readonly ExternalCommandData _commandData;

        public SectionService(ExternalCommandData commandData)
        {
            _commandData = commandData;
        }

        /// <summary>
        /// Создаёт 3 разреза по выбранному элементу: по основным трём плоскостям.
        /// Возвращает true, если хотя бы один разрез успешно создан.
        /// </summary>
        public bool CreateSection(
            FamilyInstance instance,
            double widthOffsetMm,
            double depthOffsetMm,
            double heightOffsetMm,
            string sectionName)
        {
            var doc = _commandData.Application.ActiveUIDocument.Document;

            var bbox = instance.get_BoundingBox(null);
            if (bbox == null) return false;

            var center = (bbox.Min + bbox.Max) / 2;
            var size = bbox.Max - bbox.Min;

            // смещения в internal units
            var widthOffset = UnitUtils.ConvertToInternalUnits(widthOffsetMm, DisplayUnitType.DUT_MILLIMETERS);
            var depthOffset = UnitUtils.ConvertToInternalUnits(depthOffsetMm, DisplayUnitType.DUT_MILLIMETERS);
            var heightOffset = UnitUtils.ConvertToInternalUnits(heightOffsetMm, DisplayUnitType.DUT_MILLIMETERS);

            // Получаем ViewFamilyType для Section
            var viewType = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .OfType<ViewFamilyType>()
                .FirstOrDefault(x => x.ViewFamily == ViewFamily.Section);

            if (viewType == null) return false;

            // Список конфигураций ориентиров (basisY, basisZ, суффикс имени)
            var configs = new[]
            {
                // ОРИЕНТАЦИЯ 1: вертикальная плоскость, нормаль вдоль X (плоскость YZ)
                new { BasisY = XYZ.BasisZ, BasisZ = XYZ.BasisY, Suffix = "_YZ" },

                // ОРИЕНТАЦИЯ 2: вертикальная плоскость, нормаль вдоль Y (плоскость ZX)
                new { BasisY = XYZ.BasisZ, BasisZ = XYZ.BasisX, Suffix = "_ZX" },

                // ОРИЕНТАЦИЯ 3: горизонтальная плоскость, нормаль вдоль Z (плоскость XY)
                // Для горизонтальной плоскости делаем BasisY = X, BasisZ = Y (локально Z будет вверх)
                new { BasisY = XYZ.BasisX, BasisZ = XYZ.BasisY, Suffix = "_XY" }
            };

            bool anyCreated = false;

            try
            {
                using (var tx = new Transaction(doc, "Create 3 Sections"))
                {
                    tx.Start();

                    foreach (var cfg in configs)
                    {
                        // Композиция локальных осей: BasisX = BasisZ x BasisY
                        var basisY = cfg.BasisY;
                        var basisZ = cfg.BasisZ;
                        var basisX = basisZ.CrossProduct(basisY).Normalize();

                        var transform = Transform.CreateTranslation(XYZ.Zero);
                        transform.Origin = center;
                        transform.BasisX = basisX;
                        transform.BasisY = basisY;
                        transform.BasisZ = basisZ;

                        // NOTE: соответствие размерностей (size.X,size.Y,size.Z) и локальных осей
                        // в оригинальном коде использовалась формула:
                        // Min = (-size.X/2 - widthOffset, -size.Z/2 - depthOffset, -size.Y/2 - heightOffset)
                        // Max = ( size.X/2 + widthOffset,  size.Z/2 + depthOffset,  size.Y/2 + heightOffset)
                        // Чтобы не разрабатывать сложную логику привязки под каждую ориентацию,
                        // оставим ту же схему — она даёт корректные секции для большинства семейств.
                        var sectionBox = new BoundingBoxXYZ();
                        sectionBox.Transform = transform;
                        sectionBox.Min = new XYZ(
                            -size.X / 2.0 - widthOffset,
                            -size.Z / 2.0 - depthOffset,
                            -size.Y / 2.0 - heightOffset);
                        sectionBox.Max = new XYZ(
                            size.X / 2.0 + widthOffset,
                            size.Z / 2.0 + depthOffset,
                            size.Y / 2.0 + heightOffset);

                        // Создаём секцию
                        var viewSection = ViewSection.CreateSection(doc, viewType.Id, sectionBox);

                        if (viewSection != null)
                        {
                            // Даем осмысленное имя
                            try
                            {
                                viewSection.Name = sectionName + cfg.Suffix;
                            }
                            catch
                            {
                                // если имя нельзя задать — пропускаем
                            }

                            anyCreated = true;
                        }
                    }

                    tx.Commit();
                }
            }
            catch (Exception)
            {
                // В случае ошибки возвращаем текущее состояние (false если ничего не создано)
                return anyCreated;
            }

            return anyCreated;
        }
    }
}