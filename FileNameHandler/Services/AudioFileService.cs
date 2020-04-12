using FileNameHandler.Models;
using System.Globalization;
using System.Linq;

namespace FileNameHandler.Services
{
    public class AudioFileService : IAudioFileService
    {
        private readonly char[] SEPARATORS = new char[] { '-', '.', ' ' };
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
                if (input.Contains(separator))
                {
                    var splitted = input.Split(separator).Select(x => x.Trim()).ToArray();
                    int trackNumber;
                    bool isValid = int.TryParse(splitted[0], out trackNumber);
                    if (isValid)
                    {
                        audioFile.Track = trackNumber;
                        audioFile.AudioName = string.Join(" ", splitted.Skip(1).ToArray());
                    }
                    break;
                }
            }
            return audioFile;
        }
    }
}
