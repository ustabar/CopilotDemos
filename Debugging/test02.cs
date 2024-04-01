/*
Download the Image: Retrieve an image from the URL "https://source.unsplash.com/random" 
and save it locally as "original.png."
Resize the Image:
Create a square version of the image by adding a transparent background.
Resize another copy of the image to dimensions 1000x1000 pixels.
Make a third copy of the image with dimensions 256x256 pixels and convert it to greyscale. 
create a c# code for me
*/
using System;
using System.Drawing;
using System.Net;

class Program
{
    static void Main()
    {
        using (WebClient webClient = new WebClient())
        {
            webClient.DownloadFile("https://source.unsplash.com/random", "original.png");
        }

        using (Bitmap original = new Bitmap("original.png"))
        {
            int width = original.Width;
            int height = original.Height;

            int size = Math.Max(width, height);
            using (Bitmap square = new Bitmap(size, size))
            {
                using (Graphics g = Graphics.FromImage(square))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(original, (size - width) / 2, (size - height) / 2);
                }
                square.Save("square.png");
            }

            using (Bitmap resized = new Bitmap(original, new Size(1000, 1000)))
            {
                resized.Save("resized.png");
            }

            using (Bitmap greyscale = new Bitmap(256, 256))
            {
                using (Graphics g = Graphics.FromImage(greyscale))
                {
                    g.Clear(Color.Transparent);
                    g.DrawImage(original, 0, 0, 256, 256);
                }
                for (int x = 0; x < greyscale.Width; x++)
                {
                    for (int y = 0; y < greyscale.Height; y++)
                    {
                        Color color = greyscale.GetPixel(x, y);
                        int average = (color.R + color.G + color.B) / 3;
                        greyscale.SetPixel(x, y, Color.FromArgb(average, average, average));
                    }
                }
                greyscale.Save("greyscale.png");
            }
        }
    }
}
```
