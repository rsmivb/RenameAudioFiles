using System.Collections.Generic;

namespace FileNameHandler.Models
{
    public class AudioFile
    {
        public int Track { set; get; }
        public string AudioName { set; get; }

        public override bool Equals(object obj)
        {
            return obj is AudioFile file &&
                   Track == file.Track &&
                   AudioName == file.AudioName;
        }

        public override int GetHashCode()
        {
            int hashCode = -118504466;
            hashCode = hashCode * -1521134295 + Track.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AudioName);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Track.ToString().PadLeft(2, '0')} - {AudioName}";
        }
    }
}
