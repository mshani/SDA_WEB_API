using SDA_WEB_API.BusinessLayer.DTOs;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Infrastucture
{
    public interface IVideoGameService
    {
        Task<VideoGame> Create(VideoGameDTO payload);
        Task<VideoGame?> GetById(int id);
        Task<VideoGame?> Update(int id, VideoGameDTO payload);
        Task<bool> Delete(int id);
        Task<List<VideoGame>?> GetByFilter(string? name, string? category, int? size, string? publisher);
    }
}
