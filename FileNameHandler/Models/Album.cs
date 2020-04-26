using System.Collections.Generic;
using System.Linq;

namespace FileNameHandler.Models
{
    public class Album
    {
        public Album()
        {
            AudioFiles = new List<AudioFile>();
        }
        public string BandName { set; get; }
        public string AlbumName { set; get; }
        public List<AudioFile> AudioFiles { set; get; }
        public override bool Equals(object obj)
        {
            return obj is Album album &&
                   BandName == album.BandName &&
                   AlbumName == album.AlbumName &&
                   AudioFiles.SequenceEqual(album.AudioFiles);
        }

        public override int GetHashCode()
        {
            int hashCode = -914998472;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(BandName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(AlbumName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<List<AudioFile>>.Default.GetHashCode(AudioFiles);
            return hashCode;
        }

        public override string ToString()
        {
            return $"{nameof(BandName)}:{BandName},{nameof(AlbumName)}:{AlbumName},{nameof(AudioFiles)}:{string.Join(" || ", AudioFiles)}";
        }
    }
}
