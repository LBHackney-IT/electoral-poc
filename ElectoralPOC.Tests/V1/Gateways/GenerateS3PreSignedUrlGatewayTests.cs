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

namespace ElectoralPOC.Tests.V1.Gateways
{
    public class GenerateS3PreSignedUrlGatewayTests
    {
        private GenerateS3PreSignedUrlGateway _classUnderTest;
        private Mock<IAwsS3Client> _mockS3Client;
        private readonly Fixture _fixture = new Fixture();
        [SetUp]
        public void Setup()
        {
            _mockS3Client = new Mock<IAwsS3Client>();
            _classUnderTest = new GenerateS3PreSignedUrlGateway(_mockS3Client.Object);
            Environment.SetEnvironmentVariable("PRESIGNED_URL_EXPIRATION_IN_SECONDS","0.2");
            Environment.SetEnvironmentVariable("ELECTORAL_POC_S3_BUCKET_NAME", "bucket");
        }
        [Test]
        public void VerifyGatewayCallsS3Client()
        {
            var request = _fixture.Create<GenerateS3PreSignedUrlRequest>();
            _classUnderTest.GenerateS3PutPreSignurl(request);
            _mockS3Client.Verify(x => x.GenerateS3PreSignURL(It.IsAny<GetPreSignedUrlRequest>()), Times.Once);
        }

        [Test]
        public void TestThatIfExpirationTimeVariableValueIsNotADoubleExceptionWillBeThrown()
        {
            Environment.SetEnvironmentVariable("PRESIGNED_URL_EXPIRATION_IN_SECONDS", "invalid");
            Assert.Throws<UrlExpirationTimeInvalidException>(() => _classUnderTest.GenerateS3PutPreSignurl(new GenerateS3PreSignedUrlRequest()));
        }

        [Test]
        public void CheckThatIfS3ClientThrowsExceptionPreSignedUrlCouldNotBeGeneratedExceptionIsThrown()
        {
            _mockS3Client.Setup(x => x.GenerateS3PreSignURL(It.IsAny<GetPreSignedUrlRequest>())).Throws(new AggregateException());
            Assert.Throws<PreSignedUrlCouldNotBeGeneratedException>(() => _classUnderTest.GenerateS3PutPreSignurl(new GenerateS3PreSignedUrlRequest()));
        }

        [Test]
        public void CanSuccessfullyReturnGeneratedUrl()
        {
            var expectedResponse = "https://random.test";
            _mockS3Client.Setup(x => x.GenerateS3PreSignURL(It.IsAny<GetPreSignedUrlRequest>())).Returns(expectedResponse);

            var request = _fixture.Create<GenerateS3PreSignedUrlRequest>();
            var actualResponse = _classUnderTest.GenerateS3PutPreSignurl(request);
            actualResponse.Should().Be(expectedResponse);
        }
    }
}
