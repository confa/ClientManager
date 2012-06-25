﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BinaryStudio.ClientManager.DomainModel.DataAccess;
using BinaryStudio.ClientManager.DomainModel.Entities;
using BinaryStudio.ClientManager.WebUi.Controllers;
using Moq;
using NUnit.Framework;

namespace BinaryStudio.ClientManager.WebUi.Tests.Controllers
{
    [TestFixture]
    public class InquiryControllerTests
    {
        /// <summary>
        /// our test DB
        /// </summary>
        private static readonly List<Inquiry> ListEnquiries = new List<Inquiry>() {
                                                 new Inquiry(
                                                     new Person()
                                                         {
                                                             FirstName = "Ivan",
                                                             LastName = "Ivanov",
                                                             Role = PersonRole.Client,
                                                             Id = 9
                                                         },
                                                     new MailMessage() {Subject = "subj1"},
                                                     5
                                                     ),
                                                 new Inquiry(
                                                     new Person()
                                                         {
                                                             FirstName = "Petr",
                                                             LastName = "Petrov",
                                                             Role = PersonRole.Client,
                                                             Id = 8
                                                         },
                                                     new MailMessage() {Subject = "subj2"},
                                                     1
                                                     )
                                             };

        [Test]
        public void Shoild_ReturnInquiry_WhenRequestedFullList()
        {
            // setup
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Inquiry>()).Returns(ListEnquiries.AsQueryable());
            var inquiriesController = new InquiriesController(mock.Object);

            // act
            var response = inquiriesController.Index();
            //Assert.That(response != null && response.GetType() == typeof(ViewResult), "type is");
            var typedResponse = response as ViewResult;
            var list = typedResponse.Model as IEnumerable<Inquiry>;

            // chek
            Assert.That(list.Single(x => x.Issuer.LastName == "Petrov") != null &&
                list.Single(x => x.Issue.Subject == "subj2") != null);
        }

        [Test]
        public void ShouldNot_RaiseException_WhenDbIsEmpty()
        {
            // setup
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Inquiry>()).Returns(new List<Inquiry>().AsQueryable());
            var inquiriesController = new InquiriesController(mock.Object);

            // act
            var response = inquiriesController.Index() as ViewResult;

            // check
            Assert.That(response != null);
        }
    }
}
