using Bogus;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Gateway;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.UseCase;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.Tests.V1.UseCase
{
    public class GetS3PutPresignUrlUseCaseTests
    {
        private SaveJsonToS3UseCase _classUnderTest;
        private Mock<ISaveJsonToS3Gateway> _mockUrlGenerationService;
        private Faker _faker = new Faker();
        private string _responseUrl;
        [SetUp]
        public void Setup()
        {
            _mockUrlGenerationService = new Mock<ISaveJsonToS3Gateway>();
            _responseUrl = _faker.Random.Word();
            _mockUrlGenerationService.Setup(x => x.ConvertJsonToArray(It.IsAny<SaveJsonToS3Request>())).Returns(_responseUrl);
            _classUnderTest = new SaveJsonToS3UseCase(_mockUrlGenerationService.Object);
        }
        [Test]
        public void VerifyUseCaseCallsS3UrlHelper()
        {
            _classUnderTest.SaveJsonToS3Case(new SaveJsonToS3Request());
            _mockUrlGenerationService.Verify(x => x.ConvertJsonToArray(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        }
        [Test]
        public void CanGetS3PutPreSignUrl()
        {
            var response = _classUnderTest.SaveJsonToS3Case(new SaveJsonToS3Request());
            response.JsonData.Should().Be(_responseUrl);
            response.Should().BeOfType<SaveJsonToS3Response>();
        }
    }
}
