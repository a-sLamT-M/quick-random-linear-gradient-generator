namespace rainbow.Color;

public class LinearGradientOptions
{
    public int GenNum { get; }
    public string SavePath { get; }
    /// <summary>
    /// savePath must be a folder path.
    /// </summary>
    /// <param name="genNum"></param>
    /// <param name="savePath"></param>
    public LinearGradientOptions(int genNum, string savePath)
    {
        this.GenNum = genNum;
        this.SavePath = savePath;
    }
}