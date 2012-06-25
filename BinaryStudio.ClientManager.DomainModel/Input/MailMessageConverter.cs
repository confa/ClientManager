using System.Collections.Generic;
using BinaryStudio.ClientManager.DomainModel.DataAccess;
using BinaryStudio.ClientManager.DomainModel.Entities;

namespace BinaryStudio.ClientManager.DomainModel.Input
{
    public class MailMessageConverter
    {
        private IRepository repository;

        public MailMessageConverter(IRepository repository)
        {
            this.repository = repository;
        }

        ///// <summary>
        ///// This method converts Input.MailMessage type into Entities.MailMessage type
        ///// </summary>
        ///// <param name="message">Input.MailMessage type of mail message </param>
        ///// <param name="sender">Represents sender as Person class</param>
        ///// <param name="receivers">Represents reveivers as ICollection of Person class</param>
        ///// <returns>Entities.MailMessage type of mail message</returns>
        //public Entities.MailMessage ConvertMailMessageFromInputTypeToEntityType(MailMessage message, Person sender, ICollection<Person> receivers)
        //{
        //    return new Entities.MailMessage
        //                            {
        //                                Sender = sender,
        //                                Date = message.Date,
        //                                Subject = message.Subject,
        //                                Receivers = receivers
        //                            };        
        //}

        public Entities.MailMessage ConvertMailMessageFromInputTypeToEntityType(MailMessage mailMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}
