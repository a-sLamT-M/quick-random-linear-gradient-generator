using System.Drawing;
using SkiaSharp;

namespace rainbow.FileHelper;

public class ImageSaver
{
    private string Path { get; set; }
    public ImageSaver(string path)
    {
        this.Path = path;
    }

    public void SavePng(SKBitmap bitmap)
    {
        using Stream s = File.Open(Path + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".png", FileMode.Create);
        SKData data = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
        data.SaveTo(s);
    }

    public void SavePng(SKBitmap bitmap, string fileName)
    {
        using Stream s = File.Open(Path + fileName, FileMode.OpenOrCreate);
        SKData data = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
        data.SaveTo(s);
    }
}