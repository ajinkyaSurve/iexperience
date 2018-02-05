using iexperience.Entities;

namespace iexperience.Services
{
    public interface IEmailService
    {
        bool SendEmail(Email e);
    }
}
