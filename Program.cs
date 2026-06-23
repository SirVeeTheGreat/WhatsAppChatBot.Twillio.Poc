using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WhatsAppChatBot.Twillio.Poc
{
    internal class Program
    {
       static void Main(string[] args)
        {
            try
            {
                var accountSid = "";
                var authToken = "";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber("whatsapp:[receiverNumber]"));

                messageOptions.From = new PhoneNumber("whatsapp:+[senderNumber]");

                messageOptions.ContentSid = "[TemplateId]";
                messageOptions.ContentVariables = "[Variables]";


                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);

                ReplyToMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending message: " + e.Message);
            }

        }

        static void ReplyToMessage()
        {
            var accountSid = "";
            var authToken = "";
            TwilioClient.Init(accountSid, authToken);

            var messageOptions = new CreateMessageOptions(
                new PhoneNumber("whatsapp:[receiverNumber]"));

            messageOptions.From = new PhoneNumber("whatsapp:+[senderNumber]");
            messageOptions.Body = "Your appointment is coming up on July 21 at 3PM";


            var message = MessageResource.Create(messageOptions);
            Console.WriteLine(message.Body);
        }
    }
}
