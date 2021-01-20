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
            Environment.SetEnvironmentVariable("PRESIGNED_URL_EXPIRATION_IN_SECONDS", "0.2");
            Environment.SetEnvironmentVariable("ELECTORAL_POC_S3_BUCKET_NAME", "bucket");
        }
        [Test]
        public void VerifyGatewayCallsS3Client()
        {
            var request = _fixture.Create<SaveJsonToS3Request>();
            _classUnderTest.ConvertJsonToArray(request);
            _mockS3Client.Verify(x => x.SaveJsonToS3(It.IsAny<GetPreSignedUrlRequest>()), Times.Once);
        }

        [Test]
        public void CheckThatIfS3ClientThrowsExceptionPreSignedUrlCouldNotBeGeneratedExceptionIsThrown()
        {
            _mockS3Client.Setup(x => x.SaveJsonToS3(It.IsAny<GetPreSignedUrlRequest>())).Throws(new AggregateException());
            Assert.Throws<SaveJsonToS3CouldNotBeGeneratedException>(() => _classUnderTest.ConvertJsonToArray(new SaveJsonToS3Request()));
        }

        [Test]
        public void CanSuccessfullyReturnGeneratedUrl()
        {
            var expectedResponse = "https://master.d1ew52s1hpob9x.amplifyapp.com/form/register-applicant/applicant-details";
            _mockS3Client.Setup(x => x.SaveJsonToS3(It.IsAny<GetPreSignedUrlRequest>())).Returns(expectedResponse);

            var request = _fixture.Create<SaveJsonToS3Request>();
            var actualResponse = _classUnderTest.ConvertJsonToArray(request);
            actualResponse.Should().Be(expectedResponse);
        }
    }
}
