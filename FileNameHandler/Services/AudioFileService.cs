using FileNameHandler.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace FileNameHandler.Services
{
    public class AudioFileService : IAudioFileService
    {
        private readonly char[] SEPARATORS = new char[] { Constants.HIPHEN, Constants.DOT, Constants.WS };
        private readonly TextInfo _textInfo;

        public AudioFileService(TextInfo info)
        {
            _textInfo = info;
        }
        public AudioFile ConvertTo(string input)
        {
            input = _textInfo.ToTitleCase(input.ToLower());
            var audioFile = new AudioFile
            {
                Track = 0,
                AudioName = input
            };
            foreach (var separator in SEPARATORS)
            {
                if (input.Substring(0, 4).Contains(separator))
                {
                    var splitted = input.Split(separator).Select(x => x.Trim()).ToArray();
                    int trackNumber;
                    bool isValid = Int32.TryParse(splitted.FirstOrDefault(), out trackNumber);
                    if (isValid)
                    {
                        audioFile.Track = trackNumber;
                        audioFile.AudioName = string.Join(Constants.WS.ToString(), splitted.Skip(1).ToArray());
                    }
                    break;
                }
            }
            return audioFile;
        }
        public Album TransformTo(string rootPath)
        {
            Album album = new Album();
            var albumName = new DirectoryInfo(rootPath).Name;
            var names = albumName.Split(Constants.HIPHEN).Select(x => x.Trim()).ToArray();
            album.BandName = names.FirstOrDefault();
            album.AlbumName = string.Join(Constants.HIPHEN.ToString(), names.Skip(1));

            foreach (var file in Directory.GetFiles(rootPath))
            {
                var filename = Path.GetFileNameWithoutExtension(file);
                album.AudioFiles.Add(ConvertTo(filename));
            }
            return album;
        }
    }
}
