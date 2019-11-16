using System.Collections.Generic;
using System.Net.Mail;

namespace ASPNetFramework_Angular7_EF.Business.Dtos
{
    public class EmailDto
    {
        public string Subject{ get; set; }
        public string Message { get; set; }
        public IEnumerable<string> PathAttachments { get; set; }
        public IEnumerable<string> ToEmails { get; set; }
        public IEnumerable<string> CCEmails { get; set; }
    }
}
