using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioSMSLibrary
{
    public class TwilioSMS
    {
        private readonly string accountSid;
        private readonly string authToken;
        private readonly string phoneNumber;

        public TwilioSMS(string accountSid, string authToken, string phoneNumber)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
            this.phoneNumber = phoneNumber; //token,sid,cislo twilio
        }

        public void SendSMS(string toPhoneNumber, string message)
        {
            TwilioClient.Init(accountSid, authToken);

            var smsMessage = MessageResource.Create(
                body: message,
                from: new PhoneNumber(phoneNumber),
                to: new PhoneNumber(toPhoneNumber) //odesilani zpravy
            );

            Console.WriteLine($"SMS sent: SID={smsMessage.Sid}, Status={smsMessage.Status}, Datum={smsMessage.DateSent}"); //stav zpravy
        }

        public IEnumerable<MessageResource> GetSentMessages()
        {
            TwilioClient.Init(accountSid, authToken);

            var messages = MessageResource.Read(
                from: new PhoneNumber(phoneNumber)
            );

            return messages; //statistika
        }
    }
}
