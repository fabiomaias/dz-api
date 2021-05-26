using DotzInc.Application.CQRS.CreditCards.Commands.CreateCard;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;
using DotzInc.Tests;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DotzInc.Application.Tests.CQRS.CreditCards.Commands.CreateCard
{
    public class CreateCardCommandHandlerTests : TestBase
    {
        [Fact(DisplayName = "Create Credit Card With Success")]
        [Trait("Category", "CreditCard")]
        public async Task CommandIsValid_Executed_ShouldSuccess()
        {
            //Arrange
            var mockCreditCardRepository = new Mock<ICreditCardRepository>();
            var createCard = new CreateCardCommandHandler(mockCreditCardRepository.Object, _mapper);

            //Act
            var result = await createCard.Handle(new CreateCardCommand { AccountId = 1, InvoiceDueDate = 15, Type = CardType.Fisico }, new CancellationToken());

            //Assert
            mockCreditCardRepository.Setup(cr => cr.Add(It.IsAny<CreditCard>())).Verifiable();
            mockCreditCardRepository.Verify(cr => cr.Add(It.IsAny<CreditCard>()), Times.Once);

            Assert.True(result.Succeeded);
        }
    }
}
