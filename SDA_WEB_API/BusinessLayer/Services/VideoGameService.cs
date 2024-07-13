using SDA_WEB_API.BusinessLayer.Infrastucture;
using SDA_WEB_API.DataLayer;
using SDA_WEB_API.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace SDA_WEB_API.BusinessLayer.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly VideoGameStoreContext context;
        public VideoGameService(VideoGameStoreContext context)
        {
            this.context = context;
        }
        public async Task<VideoGame> Create(VideoGame payload)
        {
            try
            {
                context.VideoGames.Add(payload);
                await context.SaveChangesAsync();
                return payload;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<VideoGame?> GetById(int id)
        {
            try
            {
                var result = await context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<VideoGame?> Update(int id, VideoGame payload)
        {
            try
            {
                var existingItem = await context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
                if (existingItem != null)
                {
                    existingItem.Name = payload.Name;
                    existingItem.Size = payload.Size;
                    existingItem.Category = payload.Category;

                    context.VideoGames.Update(existingItem);
                    await context.SaveChangesAsync();
                    return payload;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var existingItem = await context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
                if (existingItem != null)
                {
                    context.VideoGames.Remove(existingItem);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}
