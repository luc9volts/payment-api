using ApplicationCore;
using ApplicationCore.Abstract;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using web.Controllers;
using web.Models;
using Xunit;

namespace UnitTests
{
    public class PaymentTest
    {
        private readonly PaymentsController _controller;

        public PaymentTest()
        {
            //Setup
            var pList = new List<Payment>();
            var repMock = new Mock<IPaymentRepository>();

            repMock
                .Setup(r => r.Add(It.IsAny<Payment>()))
                .Callback((Payment p) => pList.Add(p));

            var factory = new PaymentFactoryCardOrBill();
            _controller = new PaymentsController(factory, repMock.Object);
        }

        [Fact]
        public void ReturnStringWhenPaymentMethodIsBoleto()
        {
            //Arrange
            const int billLength = 47;
            var parm = new PaymentRequest
            {
                Amount = 100,
                Type = "BOLETO",
                Client = new ClientRequest { Id = 10 },
                Buyer = new BuyerRequest { Cpf = "1111111", Email = "hari.seldon@foundation.com", Name = "Hari Seldon" }
            };

            //Act
            var postResult = _controller.Post(parm) as CreatedAtRouteResult;

            //Assert
            Assert.True(postResult.Value.ToString().Length == billLength);
        }

        [Fact]
        public void ReturnBoolWhenPaymentMethodIsCreditCard()
        {
            //Arrange
            var parm = new PaymentRequest
            {
                Amount = 100,
                Type = "CREDIT_CARD",
                Client = new ClientRequest { Id = 10 },
                Buyer = new BuyerRequest { Cpf = "1111111", Email = "salvor.h@foundation.com", Name = "Salvor Hardin" },
                Card = new CardRequest { Cvv = 10, ExpirationDate = DateTime.Now, HolderName = "Gaal Dornick", Number = "42" }
            };

            //Act
            var postResult = (_controller.Post(parm) as CreatedAtRouteResult)
                .Value
                .ToString()
                .ToLower();

            //Assert
            Assert.True(postResult == "true" || postResult == "false");
        }

        [Fact]
        public void ReturnErrorWhenPaymentTypeIsInvalid()
        {
            //Arrange
            var parm = new PaymentRequest
            {
                Amount = 100,
                Type = "invalid type",
                Client = new ClientRequest { Id = 10 },
                Buyer = new BuyerRequest { Cpf = "1111111", Email = "andrew.h@endeternity.com", Name = "Andrew Harlan" },
                Card = new CardRequest { Cvv = 10, ExpirationDate = DateTime.Now, HolderName = "Noys Lambent", Number = "9999999" }
            };

            //Act
            Action act = () => _controller.Post(parm);

            //Assert
            Assert.Throws<ArgumentException>(act);
        }
    }
}
