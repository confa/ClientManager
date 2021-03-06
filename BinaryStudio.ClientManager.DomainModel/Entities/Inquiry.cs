﻿using BinaryStudio.ClientManager.DomainModel.Infrastructure;

namespace BinaryStudio.ClientManager.DomainModel.Entities
{
    /// <summary>
    /// Details about both inquiry
    /// </summary>
    public class Inquiry : IIdentifiable
    {
        public Inquiry()
        {
            Status = InquiryStatus.IncomingInquiry;
        }

        /// <summary>
        /// Int value that represents Status of inquiry.
        /// For full list of values <see cref="InquiryStatus"/> class.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Author of inquiry.
        /// </summary>
        public Person Client { get; set; }

        /// <summary>
        /// Person which is assigned to inquiry
        /// </summary>
        public Person AssignTo { get; set; }

        /// <summary>
        /// Contains source message from which inquiry was created.
        /// </summary>
        public MailMessage Source { get; set; }

        public bool Equals(Inquiry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Status == Status && other.Id == Id && Equals(other.Client, Client) && Equals(other.Source, Source);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Inquiry)) return false;
            return Equals((Inquiry) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing 
        /// algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = Status;
                result = (result*397) ^ Id;
                result = (result*397) ^ (Client != null ? Client.GetHashCode() : 0);
                result = (result*397) ^ (Source != null ? Source.GetHashCode() : 0);
                return result;
            }
        }
    }
}