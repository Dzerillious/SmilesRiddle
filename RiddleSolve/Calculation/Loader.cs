using System;
using System.Drawing;
using System.Linq;
using System.Windows.Media.Imaging;

namespace RiddleSolve.Calculation
{
    public static class Loader
    {
        public static BitmapImage GetBitmap()
            => new BitmapImage(new Uri("riddle.bmp", UriKind.RelativeOrAbsolute));

        public static Color[] GetPixels(BitmapImage bitmap)
        {
            int stride = bitmap.PixelWidth * 4;
            int size = bitmap.PixelHeight * stride;
            
            int[] pixelsArray = new int[size / 4];
            bitmap.CopyPixels(pixelsArray, stride, 0);
            return pixelsArray.Select(Color.FromArgb).ToArray();
        }
    }
}