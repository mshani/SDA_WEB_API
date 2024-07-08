using SDA_WEB_API.DataLayer.Models;

namespace SDA_WEB_API.BusinessLayer.Infrastucture
{
    public interface IPublisherService
    {
        Task<Publisher> Create(Publisher publisher);
        Task<Publisher?> GetById(int id);
        Task<Publisher?> Update(int id, Publisher publisher);
        Task<bool> Delete(int id);
    }
}
