using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.Infrastructure;
using Moq;
using NUnit.Framework;
using ElectoralPOC.V1.Boundary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Model;
using ElectoralPOC.V1.Domain.Exceptions;
using FluentAssertions;
using AutoFixture;
using ElectoralPOC.V1.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace ElectoralPOC.Tests.V1.Gateways
{
    public class SaveJsonToS3GatewayTests
    {
        private SaveJsonToS3Gateway _classUnderTest;
        private Mock<IAwsS3Client> _mockS3Client;
        private readonly Fixture _fixture = new Fixture();
        [SetUp]
        public void Setup()
        {
            _mockS3Client = new Mock<IAwsS3Client>();
            _classUnderTest = new SaveJsonToS3Gateway(_mockS3Client.Object);
        }
        [Test]
        public void VerifyGatewayCallsS3Client()
        {
            var request = _fixture.Create<SaveJsonToS3Request>();
            _classUnderTest.SaveJsonToS3(request);
            _mockS3Client.Verify(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        }

        [Test]
        public void CheckThatIfS3ClientThrowsExceptionWhenJsonFileCannotBeSaved()
        {
            _mockS3Client.Setup(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>())).Throws(new AggregateException());
            Assert.Throws<JsonFileCouldNotBeSavedToS3Exception>(() => _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()));
        }

        [Test]
        public void CanSuccessfullyReturnGeneratedUrl()
        {
            var request = _fixture.Create<SaveJsonToS3Request>();
            var response = _classUnderTest.SaveJsonToS3(request) as CreatedAtActionResult;
            response.StatusCode.Should().Be(201);

        }
    }
}
