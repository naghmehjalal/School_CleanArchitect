using Core.Application.Models;
using System.Threading.Tasks;

namespace Core.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
