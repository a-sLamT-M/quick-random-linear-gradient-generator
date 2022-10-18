using System.Security.Cryptography;
using rainbow.FileHelper;
using SkiaSharp;

namespace rainbow.Color;

public class LinearGradient
{
    private readonly List<SKColor> _colors = new();
    private readonly List<SKBitmap> _bitmaps = new();
    private readonly List<Action<int>> _generation = new();
    private ImageSaver _imageSaver { get; }
    private LinearGradientOptions _options;

    public LinearGradient(LinearGradientOptions options)
    {
        this._options = options;
        _generation.Add(GenerationA);
        _imageSaver = new(options.SavePath);
    }

    /// <summary>
    /// Return false if the generation failed.
    /// </summary>
    /// <returns>bool</returns>
    public string TryStartGenerating()
    {
        try
        {
            for (int i = 0; i < _options.GenNum; i++)
            {
                _bitmaps.Add(new SKBitmap(1920, 1080));
                int functionIndex = _generation.Count.Equals(1)
                    ? 0
                    : RandomNumberGenerator.GetInt32(0, _generation.Count);
                _generation[functionIndex](i);
            }
        }
        catch (Exception e)
        {
            return e.ToString();
        }
        return "success";
    }

    private void CreateColorPool()
    {
        _colors.Clear();
        for(int i = 0; i < 100; i++)
        {
            _colors.Add(new SKColor(Convert.ToByte(RandomNumberGenerator.GetInt32(0, 255)),
                        Convert.ToByte(RandomNumberGenerator.GetInt32(0, 255)),
                        Convert.ToByte(RandomNumberGenerator.GetInt32(0, 255))));
        }
    }

    /// <summary>
    /// Double random color
    /// </summary>
    /// <param name="index"></param>
    private void GenerationA(int index)
    {
        using SKCanvas canvas = new(_bitmaps[index]);
        CreateColorPool();
        SKColor topColor = new();
        using SKPaint paint = new();
        SKRect rect = new(0,0, 1920, 1080);
        paint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(rect.Left, rect.Top),
                new SKPoint(rect.Right, rect.Bottom),
                new SKColor[] {_colors[RandomNumberGenerator.GetInt32(0, _colors.Count)], _colors[RandomNumberGenerator.GetInt32(0, _colors.Count)]},
                new float[] { 0, 1 },
                SKShaderTileMode.Repeat
            );
        canvas.DrawRect(rect, paint);
        _imageSaver.SavePng(_bitmaps[index]);
    }
}