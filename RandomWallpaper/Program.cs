using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace RandomWallpaper
{
	class Program
	{
		const int SPI_SETDESKWALLPAPER = 20;
		const int SPIF_UPDATEINIFILE = 0x01;
		const int SPIF_SENDWININICHANGE = 0x02;

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        
		static void Main(string[] args)
		{
			var picturesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			var backgroundFolder = Path.Combine(picturesFolder, @"Backgrounds");
			var backgrounds = Directory.EnumerateFiles(backgroundFolder).ToList();
			var rnd = new Random();
			var nextBackground = backgrounds[rnd.Next(0, backgrounds.Count)];

			SystemParametersInfo(SPI_SETDESKWALLPAPER, 0,
				nextBackground,
				SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
		}
	}
}
