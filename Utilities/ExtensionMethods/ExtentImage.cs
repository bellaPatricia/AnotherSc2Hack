using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Utilities.ExtensionMethods
{
    public static class ExtentImage
    {
        public static Image SetImageOpacity(this Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height,
                        GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Image ResizeImage(this Image imgToResize, int width, int height)
        {
            return ResizeImage(imgToResize, new Size(width, height));
        }

        public static Image ResizeImage(this Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }
    }
}
