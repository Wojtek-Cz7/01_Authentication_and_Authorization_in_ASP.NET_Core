using System.Threading.Tasks;

namespace ConfArch.Web.Areas.Identity
{
    public interface ITestEmailSender
    {
        Task SendTestEmailAsync();
    }
}
