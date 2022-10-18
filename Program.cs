using rainbow.Color;

Console.WriteLine("This is a rainbow generator.");
Console.WriteLine("How many pngs do you like to gen?");

int genNum = 10;
string path = @".\result\";
while(!int.TryParse(Console.ReadLine(), out genNum))
{
    Console.WriteLine("Your input is invalid, pls try again.");
}
genNum = genNum.Equals(0) ? 1 : genNum;
if (!Directory.Exists(path)) Directory.CreateDirectory(path);
LinearGradient lg = new(new LinearGradientOptions(genNum, path));
Console.WriteLine(lg.TryStartGenerating());