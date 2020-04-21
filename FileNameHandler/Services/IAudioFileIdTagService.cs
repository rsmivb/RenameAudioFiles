using FileNameHandler.Models;

namespace FileNameHandler.Services
{
    public interface IAudioFileIdTagService
    {
        AudioFile TranformTo(string audioFilePath);
        Album TransformTo(string audioFilePath);
    }
}