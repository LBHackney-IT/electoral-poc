using Bogus;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
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
    public class GetPreSignURLUseCaseTests
    {
        private GetPreSignURLUseCase _classUnderTest;
        private Mock<IGenerateS3PreSignedUrlGateway> _mockUrlGenerationService;
        private Faker _faker = new Faker();
        private string _responseUrl;
        [SetUp]
        public void Setup()
        {
            _mockUrlGenerationService = new Mock<IGenerateS3PreSignedUrlGateway>();
            _responseUrl = _faker.Random.Word();
            _mockUrlGenerationService.Setup(x => x.GenerateS3PutPreSignurl(It.IsAny<GenerateS3PreSignedUrlRequest>())).Returns(_responseUrl);
            _classUnderTest = new GetPreSignURLUseCase(_mockUrlGenerationService.Object);
        }
        [Test]
        public void VerifyUseCaseCallsS3UrlHelper()
        {
            _classUnderTest.GetS3PutPresignUrl(new GenerateS3PreSignedUrlRequest());
            _mockUrlGenerationService.Verify(x => x.GenerateS3PutPreSignurl(It.IsAny<GenerateS3PreSignedUrlRequest>()), Times.Once);
        }
        [Test]
        public void CanGetS3PutPreSignUrl()
        {
            var response = _classUnderTest.GetS3PutPresignUrl(new GenerateS3PreSignedUrlRequest());
            response.Url.Should().Be(_responseUrl);
            response.Should().BeOfType<GeneratePreSignedUrlResponse>();
        }
    }
}
