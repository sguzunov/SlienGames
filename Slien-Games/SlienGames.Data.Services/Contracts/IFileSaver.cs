
namespace SlienGames.Data.Services.Contracts
{
    public interface IFileSaver
    {
        void SaveFile(string filePath, byte[] allBytes);
    }
}
