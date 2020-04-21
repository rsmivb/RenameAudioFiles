using FileNameHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;

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

        public Album TransformTo(string audioFilePath)
        {
            var tfile = TagLib.File.Create(audioFilePath);
            return new Album
            {
                AlbumName = tfile.Tag.Album,
                BandName = tfile.Tag.FirstAlbumArtist,

            };
        }

        public List<AudioFile> GetAudioFiles(string rootFolderPath)
        {
            var list = new List<AudioFile>();
            var files = Directory.GetFiles(rootFolderPath);


            return list;
        }
    }
}
