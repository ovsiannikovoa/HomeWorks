using System.Windows.Media;

namespace Task03_08_01.Models
{
    public enum ThicknessStatus
    {
        Ok,
        Exceeded,
        Unknown
    }

    public class WallInfo
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        // В мм
        public double Length { get; set; }
        public double Height { get; set; }
        public double Thickness { get; set; }

        // В куб. метрах и кв. метрах
        public double Volume { get; set; }
        public double Area { get; set; }

        public ThicknessStatus ThicknessStatus { get; set; } = ThicknessStatus.Unknown;

        // Текстовые представления
        public string LengthText
        {
            get { return string.Format("{0:F0} мм", Length); }
        }

        public string HeightText
        {
            get { return string.Format("{0:F0} мм", Height); }
        }

        public string ThicknessText
        {
            get { return string.Format("{0:F0} мм", Thickness); }
        }

        public string VolumeText
        {
            get { return string.Format("{0:F3} м³", Volume); }
        }

        public string AreaText
        {
            get { return string.Format("{0:F2} м²", Area); }
        }

        public string StatusText
        {
            get
            {
                switch (ThicknessStatus)
                {
                    case ThicknessStatus.Ok:
                        return "Норма";
                    case ThicknessStatus.Exceeded:
                        return "Превышение";
                    default:
                        return "Не определено";
                }
            }
        }

        public Brush StatusBrush
        {
            get
            {
                switch (ThicknessStatus)
                {
                    case ThicknessStatus.Ok:
                        return Brushes.Green;
                    case ThicknessStatus.Exceeded:
                        return Brushes.OrangeRed;
                    default:
                        return Brushes.Gray;
                }
            }
        }
    }
}