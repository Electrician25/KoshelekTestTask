using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using KoshelekWebServer.IServices;
using Microsoft.EntityFrameworkCore;

namespace KoshelekWebServer.Services
{
    public class GetMessagesByDateService(ApplicationContext aplicationContext) : IGetMessagesByDateService
    {
        async public Task<Message[]> GetMessagesByDateServiceAsync(Message message)
        {
            return await aplicationContext.Messages.ToArrayAsync();
        }
    }
}