using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Boundary.Response;
using ElectoralPOC.V1.Controllers;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.UseCase.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.Tests.V1.Controllers
{
    public class GenerateS3PreSignedUrlsControllerTests
    {
        private GenerateS3PreSignedUrlController _classUnderTest;
        private Mock<IGetPreSignURLUseCase> _mockUseCase;
        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<IGetPreSignURLUseCase>();
            _classUnderTest = new GenerateS3PreSignedUrlController(_mockUseCase.Object);
        }
        [Test]
        public void VerifyControllerCallsUseCase()
        {
            _classUnderTest.GenerateS3PreSignedUrl(new GenerateS3PreSignedUrlRequest());
            _mockUseCase.Verify(x => x.GetS3PutPresignUrl(It.IsAny<GenerateS3PreSignedUrlRequest>()), Times.Once);
        }

        [Test]
        public void CanGeneratePreSignedURL()
        {
            var expectedResponse = new GeneratePreSignedUrlResponse() { Url = "https://random-url.test" };
            _mockUseCase.Setup(x => x.GetS3PutPresignUrl(It.IsAny<GenerateS3PreSignedUrlRequest>())).Returns(expectedResponse);

            var response = _classUnderTest.GenerateS3PreSignedUrl(new GenerateS3PreSignedUrlRequest()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(201);
            response.Value.Should().Be(expectedResponse);
        }

        [Test]
        public void ControllerReturns500IfUrlNotGenerated()
        {
            _mockUseCase.Setup(x => x.GetS3PutPresignUrl(It.IsAny<GenerateS3PreSignedUrlRequest>())).Throws(new PreSignedUrlCouldNotBeGeneratedException("URL could not be generated"));

            var response = _classUnderTest.GenerateS3PreSignedUrl(new GenerateS3PreSignedUrlRequest()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
            response.Value.Should().Be("URL could not be generated");
        }

        [Test]
        public void ControllerReturns500IfExpirationTimeVariableIsNotAValidDouble()
        {
            _mockUseCase.Setup(x => x.GetS3PutPresignUrl(It.IsAny<GenerateS3PreSignedUrlRequest>())).Throws(new UrlExpirationTimeInvalidException("Variable value must be of type double"));

            var response = _classUnderTest.GenerateS3PreSignedUrl(new GenerateS3PreSignedUrlRequest()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
            response.Value.Should().Be("Variable value must be of type double");
        }
    }
}
