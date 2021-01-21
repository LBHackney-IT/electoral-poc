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
            Environment.SetEnvironmentVariable("ELECTORAL_POC_S3_BUCKET_NAME", "bucket");
        }
        [Test]
        public void VerifyGatewayCallsS3Client()
        {
            var request = _fixture.Create<SaveJsonToS3Request>();
            _classUnderTest.ConvertJsonToArray(request);
            _mockS3Client.Verify(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        }

        [Test]
        public void CheckThatIfS3ClientThrowsExceptionPreSignedUrlCouldNotBeGeneratedExceptionIsThrown()
        {
            _mockS3Client.Setup(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>())).Throws(new AggregateException());
            Assert.Throws<JsonFileCouldNotBeSavedToS3Exception>(() => _classUnderTest.ConvertJsonToArray(new SaveJsonToS3Request()));
        }

        //[Test]
        //public void CanSuccessfullyReturnGeneratedUrl()
        //{
        //    var request = _fixture.Create<SaveJsonToS3Request>();
        //    var actualResponse = _classUnderTest.ConvertJsonToArray(request) as CreatedAtActionResult;
        //    actualResponse.StatusCode.Should().Be(201);

        //}
    }
}
