using Bogus;
using FluentAssertions;
using FluentResults;
using NSubstitute;
using SalesApi.Domain.Entities;
using SalesApi.Domain.Services;
using SalesApi.Domain.Services.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SalesApi.Tests.Domain
{
    public class SaleTests
    {
        private readonly Faker _faker;

        public SaleTests()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ApplyDiscounts_ShouldApplyCorrectDiscount_WithNSubstitute()
        {
            // Arrange
            var discountStrategy = Substitute.For<IDiscountStrategy>();
            discountStrategy.IsApplicable(Arg.Any<int>()).Returns(true);
            discountStrategy.CalculateDiscount(Arg.Any<int>(), Arg.Any<decimal>()).Returns(10);

            var sale = new Sale
            {
                SaleNumber = _faker.Random.String2(10),
                SaleDate = _faker.Date.Past(),
                CustomerId = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = _faker.Random.Guid(),
                        Quantity = 5,
                        UnitPrice = 100
                    }
                }
            };

            var strategies = new List<IDiscountStrategy> { discountStrategy };

            // Act
            sale.ApplyDiscounts(strategies);

            // Assert
            sale.Items.First().Discount.Should().Be(10);
            sale.TotalValue.Should().Be(490); // (5 * 100) - 10
        }


        [Fact]
        public void QuantityValidation_ShouldReturnFailure_WhenValidationFails()
        {
            // Arrange
            var strategy = new MaxQuantityValidationStrategy();

            var sale = new Sale
            {
                SaleNumber = _faker.Random.String2(10),
                SaleDate = _faker.Date.Past(),
                CustomerId = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = _faker.Random.Guid(),
                        Quantity = 25,
                        UnitPrice = 100
                    }
                }
            };

            var strategies = new List<IQuantityValidationStrategy> { strategy };

            // Act
            var result = sale.QuantityValidation(strategies);

            // Assert
            result.IsFailed.Should().BeTrue();
            result.Errors.First().Message.Should().Be("You cannot buy more than 20 pieces of the same item");
        }

        [Theory]
        [InlineData(3, 100, 0)]
        [InlineData(5, 100, 50)]
        [InlineData(15, 50, 150)]
        public void ApplyDiscounts_ShouldApplyCorrectDiscount(int quantity, decimal unitPrice, decimal expectedDiscount)
        {
            // Arrange
            var strategies = new List<IDiscountStrategy>
            {
                new NoDiscountStrategy(),
                new TenPercentDiscountStrategy(),
                new TwentyPercentDiscountStrategy()
            };

            var sale = new Sale
            {
                SaleNumber = _faker.Random.String2(10),
                SaleDate = _faker.Date.Past(),
                CustomerId = Guid.NewGuid(),
                BranchId = Guid.NewGuid(),
                Items = new List<SaleItem>
                {
                    new SaleItem
                    {
                        ProductId = _faker.Random.Guid(),
                        Quantity = quantity,
                        UnitPrice = unitPrice
                    }
                }
            };

            // Act
            sale.ApplyDiscounts(strategies);

            // Assert
            sale.Items.First().Discount.Should().Be(expectedDiscount);
        }


    }
}
