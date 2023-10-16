using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Media3D;

namespace ProjectGameInteraction2DRacingGame.Public
{
    public class ImageColorConverter
    {
        public static WriteableBitmap ConvertColorToSource(Uri path, Color color)
        {
            StreamResourceInfo x = Application.GetResourceStream(path);
            BitmapDecoder dec = PngBitmapDecoder.Create(x.Stream, BitmapCreateOptions.None, BitmapCacheOption.Default);
            BitmapFrame image = dec.Frames[0];
            byte[] pixels = new byte[image.PixelWidth * image.PixelHeight * 4];
            image.CopyPixels(pixels, image.PixelWidth * 4, 0);

            // Modify the white pixels
            for (int i = 0; i < pixels.Length / 4; ++i)
            {
                byte b = pixels[i * 4];
                byte g = pixels[i * 4 + 1];
                byte r = pixels[i * 4 + 2];
                byte a = pixels[i * 4 + 3];

                if (r == 255 &&
                    g == 255 &&
                    b == 255 &&
                    a == 255)
                {
                    // Change it to red.
                    r = color.R;
                    g = color.G;
                    b = color.B;

                    pixels[i * 4 + 1] = g;
                    pixels[i * 4] = b; 
                    pixels[i * 4 + 2] = r;
                }
            }

            // Write the modified pixels into a new bitmap and use that as the source of an Image
            var bmp = new WriteableBitmap(image.PixelWidth, image.PixelHeight, image.DpiX, image.DpiY, PixelFormats.Bgra32, null);
            bmp.WritePixels(new Int32Rect(0, 0, image.PixelWidth, image.PixelHeight), pixels, image.PixelWidth * 4, 0);            
            return bmp;
        }
    }
}
