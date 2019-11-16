using ASPNetFramework_Angular7_EF.Business.Dtos;

namespace ASPNetFramework_Angular7_EF.Business.Email
{
    public interface IEmailSender
    {
        void Send(EmailDto emailDto);
    }
}
