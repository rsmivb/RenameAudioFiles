using FileNameHandler.Models;
using System;

namespace FileNameHandler.Services
{
    public class AudioFileIdTagService : IAudioFileIdTagService
    {
        public AudioFile TranformTo(string audioFilePath)
        {
            var tfile = TagLib.File.Create(audioFilePath);
            return new AudioFile
            {
                Track = Convert.ToInt32(tfile.Tag.Track),
                AudioName = tfile.Tag.Title
            };
        }
    }
}
