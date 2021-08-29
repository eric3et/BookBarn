
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(emailOptions.SendGridKey, subject, htmlMessage, email);
        }
        private Task Execute(string sendGridKEy, string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKEy);
            var from = new EmailAddress("admin@bulky.com", "Bulky Books");
            var to = new EmailAddress(email, "End User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            return client.SendEmailAsync(msg);
        }
    }
}




//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
//using SendGrid;
//using SendGrid.Helpers.Mail;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Mailjet.Client;
//using Mailjet.Client.Resources;
//using System;
//using Newtonsoft.Json.Linq;

//namespace BulkyBook.Utility
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly EmailOptions emailOptions;
//        private readonly IConfiguration _config;

//        public EmailSender(IOptions<EmailOptions> options, IConfiguration config)
//        {
//            emailOptions = options.Value;
//            _config = config;

//        }
//        public static async Task SendEmailAsync(string email, string subject, string htmlMessage)
//        {

//            MailjetClient client = new MailjetClient(Environment.GetEnvironmentVariable("c40f1ad17920819e29005322e2bbf945"), Environment.GetEnvironmentVariable("eb6bbb7ed4f05bb8aefd2c821e9b2fd7"))
//            {
//                //Version = ApiVersion.V3_1,
//            };
//            MailjetRequest request = new MailjetRequest
//            {
//                Resource = Send.Resource,
//            }
//             .Property(Send.Messages, new JArray {
//     new JObject {
//      {
//       "From",
//       new JObject {
//        {"Email", "eric3et@gmail.com"},
//        {"Name", "Eric"}
//       }
//      }, {
//       "To",
//       new JArray {
//        new JObject {
//         {
//          "Email",
//          "eric3et@gmail.com"
//         }, {
//          "Name",
//          "Eric"
//         }
//        }
//       }
//      }, {
//       "Subject",
//       "Greetings from Mailjet."
//      }, {
//       "TextPart",
//       "My first Mailjet email"
//      }, {
//       "HTMLPart",
//       "<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
//      }, {
//       "CustomID",
//       "AppGettingStartedTest"
//      }
//     }
//             });
//            MailjetResponse response = await client.PostAsync(request);
//            if (response.IsSuccessStatusCode)
//            {
//                Console.WriteLine(string.Format("Total: {0}, Count: {1}\n", response.GetTotal(), response.GetCount()));
//                Console.WriteLine(response.GetData());
//            }
//            else
//            {
//                Console.WriteLine(string.Format("StatusCode: {0}\n", response.StatusCode));
//                Console.WriteLine(string.Format("ErrorInfo: {0}\n", response.GetErrorInfo()));
//                Console.WriteLine(response.GetData());
//                Console.WriteLine(string.Format("ErrorMessage: {0}\n", response.GetErrorMessage()));
//            }
//        }
//    }
//}







