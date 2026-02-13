using System;
using Autodesk.Revit.DB;
using Task03_08_01.Models;

namespace Task03_08_01.Services
{
    public class WallAnalyzerService : IWallAnalyzerService
    {
        // Перевод из internal units (футы) в мм
        private double ToMillimeters(double internalValue)
        {
            return UnitUtils.ConvertFromInternalUnits(
                internalValue,
                DisplayUnitType.DUT_MILLIMETERS);
        }

        // Перевод из internal units в м²
        private double ToSquareMeters(double internalValue)
        {
            return UnitUtils.ConvertFromInternalUnits(
                internalValue,
                DisplayUnitType.DUT_SQUARE_METERS);
        }

        // Перевод из internal units в м³
        private double ToCubicMeters(double internalValue)
        {
            return UnitUtils.ConvertFromInternalUnits(
                internalValue,
                DisplayUnitType.DUT_CUBIC_METERS);
        }

        public WallInfo AnalyzeWall(Element wallElement, double thicknessLimitMm = 200.0)
        {
            if (wallElement == null)
                return null;

            Wall wall = wallElement as Wall;
            if (wall == null)
                return null;

            WallInfo info = new WallInfo();

            info.Name = wall.Name;
            info.TypeName = wall.WallType != null ? wall.WallType.Name : "—";

            // ===== ДЛИНА =====
            double lengthInternal = 0.0;
            LocationCurve lc = wall.Location as LocationCurve;
            if (lc != null && lc.Curve != null)
            {
                lengthInternal = lc.Curve.Length;
            }
            info.Length = ToMillimeters(lengthInternal);

            // ===== ТОЛЩИНА =====
            double thicknessInternal = wall.Width;
            info.Thickness = ToMillimeters(thicknessInternal);

            // ===== ВЫСОТА =====
            double heightInternal = 0.0;
            Parameter pHeight = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM);

            if (pHeight != null && pHeight.HasValue)
            {
                heightInternal = pHeight.AsDouble();
            }
            else
            {
                BoundingBoxXYZ bb = wall.get_BoundingBox(null);
                if (bb != null)
                {
                    heightInternal = Math.Abs(bb.Max.Z - bb.Min.Z);
                }
            }

            info.Height = ToMillimeters(heightInternal);

            // ===== ОБЪЁМ =====
            Parameter pVolume = wall.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
            if (pVolume != null && pVolume.HasValue)
            {
                info.Volume = ToCubicMeters(pVolume.AsDouble());
            }
            else
            {
                // приближённый расчёт
                info.Volume =
                    (info.Length / 1000.0) *
                    (info.Height / 1000.0) *
                    (info.Thickness / 1000.0);
            }

            // ===== ПЛОЩАДЬ =====
            Parameter pArea = wall.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
            if (pArea != null && pArea.HasValue)
            {
                info.Area = ToSquareMeters(pArea.AsDouble());
            }
            else
            {
                // приближённый расчёт
                info.Area =
                    (info.Length / 1000.0) *
                    (info.Height / 1000.0);
            }

            // ===== ПРОВЕРКА ТОЛЩИНЫ =====
            if (info.Thickness <= 0)
            {
                info.ThicknessStatus = ThicknessStatus.Unknown;
            }
            else if (info.Thickness > thicknessLimitMm)
            {
                info.ThicknessStatus = ThicknessStatus.Exceeded;
            }
            else
            {
                info.ThicknessStatus = ThicknessStatus.Ok;
            }

            return info;
        }
    }
}