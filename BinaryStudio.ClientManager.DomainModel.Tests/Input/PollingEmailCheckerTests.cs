using System.Collections.Generic;
using System.Net.Mail;
using BinaryStudio.ClientManager.DomainModel.Input;
using BinaryStudio.ClientManager.DomainModel.Tests.Infrastructure;
using Moq;
using NUnit.Framework;

namespace BinaryStudio.ClientManager.DomainModel.Tests.Input
{
    [TestFixture]
    public class PollingEmailCheckerTests
    {
        [Test]
        public void ShouldNot_RaiseEmailReceivedEvent_WhenNoMessagesAreReceivedFromServer()
        {
            // arrange
            var timer = new FakeTimer();
            var clientMock = new Mock<IEmailClient>();
            clientMock.Setup(x => x.GetUnreadMessages()).Returns(new List<MailMessage>());

            var checker = new PollingEmailChecker(timer, clientMock.Object);

            var received = false;
            checker.EmailReceived += (sender, args) => received = true;

            // act
            timer.RaiseOnTick();

            // assert
            Assert.That(!received);
        }

        [Test]
        public void Should_RaiseEmailReceivedEvent_WhenMessagesAreReceivedFromServer()
        {
            // arrange
            var timer = new FakeTimer();
            var clientMock = new Mock<IEmailClient>();
            clientMock.Setup(x => x.GetUnreadMessages()).Returns(new MailMessage[10]);

            var checker = new PollingEmailChecker(timer, clientMock.Object);

            var received = false;
            checker.EmailReceived += (sender, args) => received = true;

            // act
            timer.RaiseOnTick();

            // assert
            Assert.That(received);
        }

        [Test]
        public void ShouldNot_ThrowNullReferenceException_WhenNoHandlersExistForEmailReceived()
        {
            // arrange
            var timer = new FakeTimer();
            var mock = new Mock<IEmailClient>();
            mock.Setup(x => x.GetUnreadMessages()).Returns(new MailMessage[10]);

            var checker = new PollingEmailChecker(timer, mock.Object);

            // act
            timer.RaiseOnTick();

            // assert
            Assert.NotNull(checker);
            Assert.Pass();
        }
    }
}