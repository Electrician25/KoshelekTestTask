using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KoshelekWebServer.Services
{
    public class GetMessagesByDateService(ApplicationContext aplicationContext)
    {
        async public Task<Message[]> GetMessagesByDateServiceAsync(Message message)
        {
            return await aplicationContext.Messages.ToArrayAsync();
        }
    }
}