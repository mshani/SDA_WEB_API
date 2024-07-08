using Microsoft.EntityFrameworkCore;
using SDA_WEB_API.BusinessLayer.Infrastucture;
using SDA_WEB_API.DataLayer;
using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly VideoGameStoreContext context;
        public PublisherService(VideoGameStoreContext context)
        {
            this.context = context;
        }
        public async Task<Publisher> Create(Publisher publisher)
        {
            try
            {
                context.Publishers.Add(publisher);
                await context.SaveChangesAsync();
                return publisher;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Publisher?> GetById(int id)
        {
            try
            {
                var result = await context.Publishers.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Publisher?> Update(int id, Publisher publisher)
        {
            try
            {
                var existingItem = await context.Publishers.FirstOrDefaultAsync(x => x.Id == id);
                if (existingItem != null)
                {
                    existingItem.Name = publisher.Name;
                    existingItem.Adress = publisher.Adress;
                    existingItem.Phone = publisher.Phone;

                    context.Publishers.Update(existingItem);
                    await context.SaveChangesAsync();
                    return publisher;
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
                var existingItem = await context.Publishers.FirstOrDefaultAsync(x => x.Id == id);
                if (existingItem != null)
                {
                    context.Publishers.Remove(existingItem);
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
