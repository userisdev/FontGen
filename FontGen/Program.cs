using SkiaSharp;

var savePath = "tmp.png";

var text = "あいうえおHello, world.1234１２３４";
var color = SKColors.Black;
var size = 100;
var bg = SKColors.Transparent;

var paint = new SKPaint();

paint.Color = color;
paint.TextSize = size;
paint.Typeface = SKTypeface.FromFile("yojo.ttf");
paint.SubpixelText = true;

var drawSize = paint.MeasureText(text);

using var surface = SKSurface.Create(new SKImageInfo((int)drawSize, (int)(paint.FontMetrics.Descent - paint.FontMetrics.Ascent) ));
using var canvas = surface.Canvas;

canvas.Clear(bg);
canvas.DrawText(text,0, 0 - paint.FontMetrics.Ascent, paint);

var img = surface.Snapshot();
var tmp = img.Encode();

using var fs = new FileStream(savePath,FileMode.CreateNew);
tmp.SaveTo(fs);