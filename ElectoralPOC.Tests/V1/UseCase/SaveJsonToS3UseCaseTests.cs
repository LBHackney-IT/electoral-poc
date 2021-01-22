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
    public class SaveJsonToS3UseCaseTests
    {
        private SaveJsonToS3UseCase _classUnderTest;
        private Mock<ISaveJsonToS3Gateway> _mockGateway;
        [SetUp]
        public void Setup()
        {
            _mockGateway = new Mock<ISaveJsonToS3Gateway>();
            _classUnderTest = new SaveJsonToS3UseCase(_mockGateway.Object);
        }
        //[Test]
        //public void VerifyThatGatewayIsCalled()
        //{
        //    var expectedResponse = new SaveJsonToS3Response() { JsonData = "{\"name\":\"john\",\"age\":22,\"class\":\"mca\"}" };
        //    _mockGateway.Setup(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>())).Returns(expectedResponse);
        //    _classUnderTest.SaveJsonToS3Case(new SaveJsonToS3Request());
        //    _mockGateway.Verify(x => x.SaveJsonToS3(It.IsAny<SaveJsonToS3Request>()), Times.Once);
        //}
        //[Test]
        //public void CanGetS3PutPreSignUrl()
        //{
        //    var response = _classUnderTest.SaveJsonToS3Case(new SaveJsonToS3Request());
        //    response.JsonData.Should().Be(_responseUrl);
        //    response.Should().BeOfType<SaveJsonToS3Response>();
        //}
    }
}
