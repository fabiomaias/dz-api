using DotzInc.Application.CQRS.Accounts.Commands.UpdateBalanceDz;
using DotzInc.Application.Exceptions;
using DotzInc.Application.Interfaces.Repositories;
using DotzInc.Domain.Entities;
using DotzInc.Domain.Enums;
using DotzInc.Tests;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DotzInc.Application.Tests.CQRS.Accounts.Commands.CreateAccount
{
    public class UpdateBalanceDzCommandHandlerTests : TestBase
    {
        [Fact(DisplayName = "Update Dz Balance With Exception")]
        [Trait("Category", "Account")]
        public async Task UpdateBalance_WithAuthIdDiferent_ThrowApiException()
        {
            //Arrange
            var mockAccountRepository = new Mock<IAccountRepository>();
            var updateAccount = new UpdateBalanceDzCommandHandler(mockAccountRepository.Object, _mapper);
            var guid = Guid.NewGuid().ToString();
            var account = new Account();
                account.AuthId = guid;
                account.Dz = 200;

            //Act
            var ex = await Assert.ThrowsAsync<ApiException>(() =>
            updateAccount.Handle(new UpdateBalanceDzCommand { AuthId = guid, Dz = 200, Operation = TypeOperationDz.Adicionar }, new CancellationToken())); 

            //Assert
            mockAccountRepository.Setup(ar => ar.Update(It.IsAny<Account>())).Verifiable();
            mockAccountRepository.Verify(ar => ar.Update(It.IsAny<Account>()), Times.Never);

            Assert.Equal("A conta para atualização de Dz é inexistente.", ex.Message);

        }
    }
}
