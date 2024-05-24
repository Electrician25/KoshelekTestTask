using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KoshelekWebServer.Services
{
    public class GetMessagesByDateService(ApplicationContext aplicationContext)
    {
        async public Task<Message[]> GetMessagesByDateServiceAsync(string date)
        {
            return await aplicationContext.Messages.Where(x => x.Date.ToString().Contains(date)).ToArrayAsync();
        }
    }
}