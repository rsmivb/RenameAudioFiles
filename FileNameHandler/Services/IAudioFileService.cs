using FileNameHandler.Models;

namespace FileNameHandler.Services
{
    public interface IAudioFileService
    {
        AudioFile ConvertTo(string input);
    }
}