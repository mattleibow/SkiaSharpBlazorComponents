using Microsoft.AspNetCore.Components;
using SkiaSharp;
using System;
using System.Threading.Tasks;

namespace SkiaSharpBlazorComponents.SkiaSharpImages
{
	public partial class SkiaSharpImage : ComponentBase
	{
		public string ImageUrl { get; private set; }

		[Parameter]
		public EventCallback<PaintImageEventArgs> OnPaintImage { get; set; }

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();

			using var surface = SKSurface.Create(new SKImageInfo(100, 100));

			await OnPaintImage.InvokeAsync(new PaintImageEventArgs(surface));

			using var image = surface.Snapshot();
			var guid = SkiaSharpImagesController.Save(image);

			ImageUrl = "/api/skiasharpimages?g=" + guid;
		}
	}

	public class PaintImageEventArgs : EventArgs
	{
		public PaintImageEventArgs(SKSurface surface)
		{
			Surface = surface;
		}

		public SKSurface Surface { get; }
	}
}
