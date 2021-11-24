using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace HealthSystem.Common {

    public class CommonMethods {

        public static bool IsCorrectDate(byte day, byte month)
        {
            if (month <= 12) {
                switch (month) {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (day <= 31) return true;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (day <= 30) return true;
                        break;
                    case 2:
                        if (day <= 29) return true;
                        break;
                }
            }
            return false;
        }

        public static Image ResizeImage(Image img)
        {
            float percent, widthPercent, heigthPercent;
            int sourceWidth = img.Width;
            int sourceHeight = img.Height;
            Size size = new Size(500, 500);

            widthPercent = ((float)size.Width / (float)sourceWidth);
            heigthPercent = ((float)size.Height / (float)sourceHeight);

            percent = (heigthPercent < widthPercent) ? heigthPercent : widthPercent;

            int destWidth = (int)(sourceWidth * percent);
            int destHeigth = (int)(sourceHeight * percent);

            Bitmap b = new Bitmap(destWidth, destHeigth);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, 0, 0, destWidth, destHeigth);
            g.Dispose();

            return (Image)b;
        }

        public static byte[] PreparePhoto(Image img) {
            MemoryStream ms = new MemoryStream();

            img.Save(ms, ImageFormat.Jpeg);

            Byte[] imageData = new Byte[ms.Length];
            ms.Position = 0;
            ms.Read(imageData, 0, Convert.ToInt32(ms.Length));

            return imageData;
        }

        public static Image LoadImage(byte[] imageData) {
            Image img;

            using (MemoryStream ms = new MemoryStream(imageData, 0, imageData.Length)) {
                ms.Write(imageData, 0, imageData.Length);
                img = Image.FromStream(ms, true);
            }

            return img;
        }
    }
}
