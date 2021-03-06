﻿using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace BinaryStudio.ClientManager.DomainModel.Input
{
    /// <summary>
    /// Represents e-mail message domain input
    /// </summary>
    public class MailMessage
    {
        /// <summary>
        /// Date when message was received.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Author of this message.
        /// </summary>
        public MailAddress Sender { get; set; }

        /// <summary>
        /// List of all receivers.
        /// </summary>
        public ICollection<MailAddress> Receivers { get; set; }

        /// <summary>
        /// Subject of the message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of the message.
        /// </summary>
        public string Body { get; set; }
    }
}
