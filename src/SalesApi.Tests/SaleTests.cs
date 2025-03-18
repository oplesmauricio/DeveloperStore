using Bogus;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SalesApi.Tests
{

    public class SaleTests
    {
        private readonly Faker _faker;

        public SaleTests()
        {
            _faker = new Faker();
        }
    }

}
