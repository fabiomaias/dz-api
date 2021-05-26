using DotzInc.Application.CQRS.Accounts.Commands.CreateAccount;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Tests;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DotzInc.Application.Tests.CQRS.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommandHandlerTests : TestBase
    {
        [Fact(DisplayName = "Create Account With Success")]
        [Trait("Category", "Account")]
        public async Task CommandIsValid_Executed_ShouldSuccess()
        {
            //Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            var createAccount = new CreateAccountCommandHandler(mockAccountRepository.Object, _mapper);
            var guid = Guid.NewGuid().ToString();

            //Act
            var result = await createAccount.Handle(new CreateAccountCommand { AuthId = guid, Dz = 200 }, new CancellationToken());

            //Assert
            mockAccountRepository.Setup(ar => ar.Add(It.IsAny<Account>())).Verifiable();
            mockAccountRepository.Verify(ar => ar.Add(It.IsAny<Account>()), Times.Once);

            Assert.NotNull(result.Data);
            Assert.Equal(200, result.Data.Dz);
        }
    }
}