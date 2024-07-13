using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Infrastucture
{
    public interface IVideoGameService
    {
        Task<VideoGame> Create(VideoGame payload);
        Task<VideoGame?> GetById(int id);
        Task<VideoGame?> Update(int id, VideoGame payload);
        Task<bool> Delete(int id);
    }
}
