using FileNameHandler.Models;
using FileNameHandler.Services;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FileNameHandlerTest.Services
{
	public class AudioFileIdTagServiceTest
	{
		private readonly IAudioFileIdTagService _service;

		public AudioFileIdTagServiceTest()
		{
			_service = new AudioFileIdTagService();
		}

		[Fact(DisplayName = "Get AudioFile from IdTag")]
		[Trait("Audio File Id Tag", "Service")]
		public void ExtractAudioFileObjectFromAudioFileTest()
		{
			AudioFile expected = new AudioFile { Track = 1, AudioName = "Monster Hero" };
			const string audioFileName = "01 Monster Hero.mp3";
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AudioSamples");

			var current = _service.Get(Path.Combine(path, audioFileName));

			Assert.Equal(expected, current);
		}

		[Fact(DisplayName = "Create Album based on album folder path")]
		[Trait("Audio File Id Tag", "Service")]
		public void CreateAlbumUsingFolderPathTest()
		{
			var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AudioSamples\\Axxis - Monster Hero\\");
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
						AudioName = "Living as Outlaws"
					},
					new AudioFile
					{
						Track = 3,
						AudioName = "Rock is My Religion"
					},
					new AudioFile
					{
						Track = 4,
						AudioName = "Love is Gonna Get You Killed"
					},
					new AudioFile
					{
						Track = 5,
						AudioName = "Glory of the Brave"
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
						AudioName = "All I Want is Rock"
					},
					new AudioFile
					{
						Track = 12,
						AudioName = "The Tragedy of Mr.Smith"
					},
					new AudioFile
					{
						Track = 13,
						AudioName = "Rock is My Religion (Raw Mix)"
					},
					new AudioFile
					{
						Track = 14,
						AudioName = "All I Want is Rock (Raw Mix)"
					},
				}
			};
			var current = _service.TransformTo(path);
			Assert.Equal(expected, current);
		}
	}
}
