using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using System;
using System.IO;

namespace SkiaSharpBlazorComponents
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkiaSharpImagesController : ControllerBase
	{
		private static readonly string rootPath;

		static SkiaSharpImagesController()
		{
			rootPath = Path.Combine(Path.GetTempPath(), "SkiaSharpImages");
			if (!Directory.Exists(rootPath))
				Directory.CreateDirectory(rootPath);
		}

		[HttpGet]
		public ActionResult Get(string g)
		{
			if (!Guid.TryParse(g, out _))
				return NotFound();

			var path = Path.Combine(rootPath, g);

			if (!System.IO.File.Exists(path))
				return NotFound();

			var file = System.IO.File.OpenRead(path);
			return File(file, "image/png");
		}

		public static string Save(SKImage image)
		{
			var guid = Guid.NewGuid().ToString();

			using (var file = System.IO.File.Create(Path.Combine(rootPath, guid)))
			{
				using var pixmap = image.PeekPixels();
				pixmap.Encode(file, SKPngEncoderOptions.Default);
			}

			return guid;
		}
	}
}
