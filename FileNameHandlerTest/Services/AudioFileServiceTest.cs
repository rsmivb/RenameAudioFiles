using FileNameHandler.Models;
using FileNameHandler.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Xunit;

namespace RenameFileNamesTest
{
	public class AudioFileServiceTest
	{
		private readonly TextInfo textInfo;
		private readonly IAudioFileService service;

		public AudioFileServiceTest()
		{
			textInfo = new CultureInfo("en-US", false).TextInfo;
			service = new AudioFileService(textInfo);
		}

		[Fact(DisplayName = "Create Album")]
		[Trait("Service", "Audio File")]
		public void CreateAlbumTest()
		{
			var rootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AudioSamples\\Axxis - Monster Hero\\");
			var expected = new Album
			{
				AlbumName = "Monster Hero",
				BandName = "Axxis",
				AudioFiles = new List<AudioFile>
				{
					new AudioFile
					{
						Track = 1,
						AudioName = "Monster Hero"
					},
					new AudioFile
					{
						Track = 2,
						AudioName = "Living As Outlaws"
					},
					new AudioFile
					{
						Track = 3,
						AudioName = "Rock Is My Religion"
					},
					new AudioFile
					{
						Track = 4,
						AudioName = "Love Is Gonna Get You Killed"
					},
					new AudioFile
					{
						Track = 5,
						AudioName = "Glory Of The Brave"
					},
					new AudioFile
					{
						Track = 6,
						AudioName = "Make Me Fight"
					},
					new AudioFile
					{
						Track = 7,
						AudioName = "Gonna Be Tough"
					},
					new AudioFile
					{
						Track = 8,
						AudioName = "Firebird"
					},
					new AudioFile
					{
						Track = 9,
						AudioName = "We Are Seven"
					},
					new AudioFile
					{
						Track = 10,
						AudioName = "Give Me Good Times"
					},
					new AudioFile
					{
						Track = 11,
						AudioName = "All I Want Is Rock"
					},
					new AudioFile
					{
						Track = 12,
						AudioName = "The Tragedy Of Mr Smith"
					},
					new AudioFile
					{
						Track = 13,
						AudioName = "Rock Is My Religion (Raw Mix)"
					},
					new AudioFile
					{
						Track = 14,
						AudioName = "All I Want Is Rock (Raw Mix)"
					},
				}
			};
			Album current = service.TransformTo(rootPath);
			Assert.Equal(expected, current);
		}
		[Theory]
		[Trait("Service", "Audio File")]
		[MemberData(nameof(FileNames))]
		public void TransformInputInAudioFileTest(string input, string expected)
		{
			var current = service.ConvertTo(input);

			Assert.True(expected.Equals(current.ToString()), $"expected: {expected} || current:{current}");
		}
		public static IEnumerable<object[]> FileNames =>
			new List<object[]>
			{
				new object[] { "01 Holding On Mrs.Eunuco", "01 - Holding On Mrs.Eunuco" },
				new object[] { "05 - die mutter die ihr kinder verlor", "05 - Die Mutter Die Ihr Kinder Verlor" },
				new object[] { "01-Filename", "01 - Filename" },
				new object[] { "01. Holding On", "01 - Holding On" },
				new object[] { "01.Holding On", "01 - Holding On" },
				new object[] { "Holding On", "00 - Holding On" },
				new object[] { "holding on", "00 - Holding On" },
				new object[] { "01 FILEname the nAME", "01 - Filename The Name" },
				new object[] { "01 THIS IS ONLY THE BEGINNING", "01 - This Is Only The Beginning" },
				new object[] { "10 oUtro Teste em pOrtuguês com cÇedilha", "10 - Outro Teste Em Português Com Cçedilha" },
				new object[] { "06-Süßer Die Glocken Nie Klingen","06 - Süßer Die Glocken Nie Klingen" },
				new object[] { "Süßer Die Glocken Nie Klingen","00 - Süßer Die Glocken Nie Klingen" },
			};
	}
}
