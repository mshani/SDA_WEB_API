using SDA_WEB_API.BusinessLayer.Infrastucture;
using SDA_WEB_API.DataLayer;
using SDA_WEB_API.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.BusinessLayer.DTOs;

namespace SDA_WEB_API.BusinessLayer.Services
{
    public class VideoGameService : IVideoGameService
    {
        private readonly VideoGameStoreContext context;
        public VideoGameService(VideoGameStoreContext context)
        {
            this.context = context;
        }
        public async Task<VideoGame> Create(VideoGameDTO payload)
        {
            try
            {
                var item = new VideoGame
                {
                    Name = payload.Name,
                    Size = payload.Size,
                    PublisherId = payload.PublisherId,
                    Category = payload.Category,
                    CreateTime = DateTime.UtcNow,
                };

                context.VideoGames.Add(item);
                await context.SaveChangesAsync();
                return item;
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
                var result = await 
                    context.VideoGames
                    .Include(x => x.Publisher)
                    .FirstOrDefaultAsync(x => x.Id == id);
                
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<VideoGame>?> GetByFilter(
            string? name, 
            string? category, 
            int? size, 
            string? publisher)
        {
            try
            {
                var query = context.VideoGames.Include(x => x.Publisher).AsQueryable();
                if (!string.IsNullOrEmpty(name))
                {
                    query = query
                        .Where(x => 
                        x.Name != null &&
                        x.Name.ToUpper().Trim().Contains(name.ToUpper().Trim()));
                }
                if (!string.IsNullOrEmpty(category))
                {
                    query = query
                        .Where(x =>
                        x.Category != null && 
                        x.Category.ToUpper().Trim().Contains(category.ToUpper().Trim()));
                }
                if (size != null)
                {
                    query = query
                        .Where(x => x.Size == size);
                }
                if (!string.IsNullOrEmpty(publisher))
                {
                    query = query.Where(x => 
                    x.Publisher != null &&
                    x.Publisher.Name != null &&
                    x.Publisher.Name.ToUpper().Trim().Contains(publisher.ToUpper().Trim()));
                }
                var result = query.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<VideoGame?> Update(int id, VideoGameDTO payload)
        {
            try
            {
                var existingItem = await context.VideoGames.FirstOrDefaultAsync(x => x.Id == id);
                if (existingItem != null)
                {
                    existingItem.Name = payload.Name;
                    existingItem.Size = payload.Size;
                    existingItem.Category = payload.Category;
                    existingItem.PublisherId = payload.PublisherId;
                    existingItem.ModifiedTime = DateTime.UtcNow;

                    context.VideoGames.Update(existingItem);
                    await context.SaveChangesAsync();
                    return existingItem;
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
