using FileNameHandler.Models;
using FileNameHandler.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
		[Fact]
		[Trait("Category", "Integration")]
		public void ExtractAudioFileObjectFromAudioFileTest()
		{
			AudioFile expected = new AudioFile { Track = 1, AudioName = "Monster Hero" };
			var audioFileName = "01 Monster Hero.mp3";
			string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"AudioSamples");
			var current = _service.TranformTo(Path.Combine(path,audioFileName));

			Assert.Equal(expected, current);
		}

	}
}
