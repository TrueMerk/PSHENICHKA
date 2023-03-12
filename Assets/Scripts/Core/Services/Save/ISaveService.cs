using System.Threading.Tasks;

namespace SarrrGames.GoldenRush.Core.Services.Save
{
    public interface ISaveService
    {
        public Task SaveObject(string path, object obj);
        public Task<T> LoadObject<T>(string path);
    }
}
