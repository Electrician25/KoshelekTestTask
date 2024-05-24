using DatabaseLevel.DAL.Entities;
using DatabaseLevel.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace KoshelekWebServer.Services
{
    public class MessageByDateService(
        ApplicationContext aplicationContext,
        ILogger<MessageByDateService> logger) : Interfaces.IMessageByDateService
    {
        async public Task<Message[]> GetMessagesByDateServiceAsync(DateTime date)
        {
            return await aplicationContext.Messages.Where(x
                => x.Date >= date).ToArrayAsync();
        }
    }
}