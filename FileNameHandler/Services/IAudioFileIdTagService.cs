using FileNameHandler.Models;

namespace FileNameHandler.Services
{
    public interface IAudioFileIdTagService
    {
        AudioFile Get(string audioFilePath);
        Album TransformTo(string albumPath);
    }
}