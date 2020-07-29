# SkiaSharp Blazor Components

No, this is not production-ready.

Not even a thing you should even try to ship in a POC because we all know that once it leaves the shop, it is in production.

Just a demo. I know nothing.

From here: https://github.com/mono/SkiaSharp/issues/1194

## Usage

```razor
<div>
    <SkiaSharpImage OnPaintImage="@PaintImage" />
</div>

@{
    void PaintImage(PaintImageEventArgs e)
    {
        var canvas = e.Surface.Canvas;

        canvas.Clear(SKColors.Blue);
    }
}
```
