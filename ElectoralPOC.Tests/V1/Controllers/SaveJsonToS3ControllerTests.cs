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
    public class SaveJsonToS3ControllerTests
    {
        private SaveJsonToS3Controller _classUnderTest;
        private Mock<IGetS3PutPresignUrlUseCase> _mockUseCase;
        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<IGetS3PutPresignUrlUseCase>();
            _classUnderTest = new SaveJsonToS3Controller(_mockUseCase.Object);
        }
        [Test]
        public void VerifyControllerCallsUseCase()
        {
            _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request());
            _mockUseCase.Verify(x => x.GetS3PutPresignUrl(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        }

        [Test]
        public void CanGeneratePreSignedURL()
        {
            var expectedResponse = new SaveJsonToS3Response() { JsonData = "https://master.d1ew52s1hpob9x.amplifyapp.com/form/register-applicant/applicant-details" };
            _mockUseCase.Setup(x => x.GetS3PutPresignUrl(It.IsAny<SaveJsonToS3Request>())).Returns(expectedResponse);

            var response = _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(201);
            response.Value.Should().Be(expectedResponse);
        }

        [Test]
        public void ControllerReturns500IfUrlNotGenerated()
        {
            _mockUseCase.Setup(x => x.GetS3PutPresignUrl(It.IsAny<SaveJsonToS3Request>())).Throws(new JsonFileCouldNotBeSavedToS3Exception("URL could not be generated"));

            var response = _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
            response.Value.Should().Be("URL could not be generated");
        }

     
    }
}
