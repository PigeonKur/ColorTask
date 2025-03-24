
using System;
using System.Globalization;

namespace ColorLibrary
{
    public static class ColorConverter
    {
        public static string RgbToHex(int r, int g, int b)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                throw new ArgumentOutOfRangeException("RGB значениение между 0 и 255");

            return $"#{r:X2}{g:X2}{b:X2}";
        }

        public static (int r, int g, int b) HexToRgb(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex) || !hex.StartsWith("#") || (hex.Length != 7))
                throw new ArgumentException("Неправильный формат. Используйте #RRGGBB");

            try
            {
                var r = int.Parse(hex.Substring(1, 2), NumberStyles.HexNumber);
                var g = int.Parse(hex.Substring(3, 2), NumberStyles.HexNumber);
                var b = int.Parse(hex.Substring(5, 2), NumberStyles.HexNumber);
                return (r, g, b);
            }
            catch (Exception)
            {
                throw new ArgumentException("Неправильный формат.");
            }
        }

        public static (double h, double s, double l) RgbToHsl(int r, int g, int b)
        {
            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                throw new ArgumentOutOfRangeException("RGB значениение между 0 и 255");

            double rNorm = r / 255.0;
            double gNorm = g / 255.0;
            double bNorm = b / 255.0;

            double max = Math.Max(Math.Max(rNorm, gNorm), bNorm);
            double min = Math.Min(Math.Min(rNorm, gNorm), bNorm);
            double h, s, l;
            h = s = l = (max + min) / 2;

            if (max == min)
            {
                h = s = 0;
            }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
                if (max == rNorm)
                    h = (gNorm - bNorm) / d + (gNorm < bNorm ? 6 : 0);
                else if (max == gNorm)
                    h = (bNorm - rNorm) / d + 2;
                else
                    h = (rNorm - gNorm) / d + 4;
                h /= 6;
            }
            return (Math.Round(h * 360, 2), Math.Round(s * 100, 2), Math.Round(l * 100, 2));
        }
    }
}
