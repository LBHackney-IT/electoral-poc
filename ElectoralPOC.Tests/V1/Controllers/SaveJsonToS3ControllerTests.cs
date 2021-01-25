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
        private Mock<ISaveJsonToS3UseCase> _mockUseCase;
        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<ISaveJsonToS3UseCase>();
            _classUnderTest = new SaveJsonToS3Controller(_mockUseCase.Object);
        }
        [Test]
        public void VerifyControllerCallsUseCase()
        {
            _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request());
            _mockUseCase.Verify(x => x.SaveJsonToS3Case(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        }

        [Test]
        public void CanSaveJsonToS3AndReturn201Created()
        {
            _mockUseCase.Setup(x => x.SaveJsonToS3Case(It.IsAny<SaveJsonToS3Request>()));

            var response = _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()) as CreatedAtActionResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(201);
        }

        [Test]
        public void ControllerReturns500IfJsonDataCannotBeSavedToS3()
        {
            _mockUseCase.Setup(x => x.SaveJsonToS3Case(It.IsAny<SaveJsonToS3Request>())).Throws(new JsonFileCouldNotBeSavedToS3Exception("Json File could not be saved"));

            var response = _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
            response.Value.Should().Be("Json File could not be saved");
        }

        [Test]
        public void ThrowsExceptionIfFileReturnsInvalidExtension()
        {
            var fileName = "test.csv";
            _mockUseCase.Setup(x => x.SaveJsonToS3Case(It.IsAny<SaveJsonToS3Request>())).Throws(new JsonFileCouldNotBeSavedToS3Exception("Filename contains invalid extension " + fileName));

            var response = _classUnderTest.SaveJsonToS3(new SaveJsonToS3Request()) as ObjectResult;
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(500);
            response.Value.Should().Be("Filename contains invalid extension " + fileName);

        }


    }
}
