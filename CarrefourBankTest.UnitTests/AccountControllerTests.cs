using CarrefourBankTest.Api.Controllers;
using CarrefourBankTest.Application.DTOs;
using CarrefourBankTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CarrefourBankTest.UnitTests
{
    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IAccountAppService> _mockAccountAppService;

        public AccountControllerTests()
        {
            _mockAccountAppService = new Mock<IAccountAppService>();
            _accountController = new AccountController(_mockAccountAppService.Object);
        }

        [Fact]
        public void Credit_ValidAccountIdAndAmount_ReturnsOkResult()
        {
            // Arrange
            var accountId = 1;
            var amount = 100m;

            // Act
            var result = _accountController.Credit(accountId, amount);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockAccountAppService.Verify(x => x.CreditAsync(accountId, amount), Times.Once);
        }

        [Fact]
        public void Debit_ValidAccountIdAndAmount_ReturnsOkResult()
        {
            // Arrange
            var accountId = 1;
            var amount = 50m;

            // Act
            var result = _accountController.Debit(accountId, amount);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockAccountAppService.Verify(x => x.DebitAsync(accountId, amount), Times.Once);
        }

        [Fact]
        public void GetBalance_ValidAccountId_ReturnsOkResultWithBalance()
        {
            // Arrange
            var accountId = 1;
            var balance = 500m;
            _mockAccountAppService.Setup(x => x.GetBalanceAsync(accountId)).ReturnsAsync(balance);

            // Act
            var result = _accountController.GetBalance(accountId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(balance, okResult.Value);
        }
    }
}