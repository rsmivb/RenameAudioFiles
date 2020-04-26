using FileNameHandler.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileNameHandler.Services
{
    public class AudioFileIdTagService : IAudioFileIdTagService
    {
        public AudioFile Get(string audioFilePath)
        {
            var tfile = TagLib.File.Create(audioFilePath);
            return new AudioFile
            {
                Track = Convert.ToInt32(tfile.Tag.Track),
                AudioName = tfile.Tag.Title
            };
        }

        public Album TransformTo(string rootPath)
        {
            var list = new List<AudioFile>();
            Album album = new Album();

            var albumDirectory = new DirectoryInfo(rootPath);
            foreach (var file in albumDirectory.GetFiles())
            {
                var fileTag = GetTag(file.FullName);
                album.AlbumName = album.AlbumName ?? fileTag.Album;
                album.BandName = album.BandName ?? fileTag.FirstAlbumArtist;
                list.Add(new AudioFile
                {
                    AudioName = fileTag.Title,
                    Track = (int)fileTag.Track
                });
            }
            album.AudioFiles = list;
            return album;
        }

        public TagLib.Tag GetTag(string audioFilePath)
        {
            return TagLib.File.Create(audioFilePath).Tag;
        }
    }
}
