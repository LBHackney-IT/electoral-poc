using Bogus;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Helpers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralPOC.Tests.V1.Helper
{
    public class SaveJsonToS3HelperTests
    {
        private readonly Faker _faker = new Faker();
        [Test]
        public void CanComposeUrlCorrectly()
        {
            var fileName = _faker.Random.Word();
            var submissionId = _faker.Random.AlphaNumeric(9);
            var expectedUrl = submissionId + "/docs/" + fileName;

            var actualResult = SaveJsonToS3Helper.ComposeFilePath("", fileName, submissionId);
            actualResult.Should().Be(expectedUrl);
        }

        [Test]
        public void AnyStartingForwardSlashesWillBeRemovedIfPresent()
        {
            var fileName = _faker.Random.Word();
            var submissionId = _faker.Random.AlphaNumeric(9);
            var expectedUrl = submissionId + "/docs/" + fileName;

            var actualResult = SaveJsonToS3Helper.ComposeFilePath("", "/" + fileName, "/" + submissionId);
            actualResult.Should().Be(expectedUrl);
        }

        [Test]
        [Ignore("In Progress")]
        public void ThrowsExceptionIfFileReturnsInvalidExtension()
        {
            var fileName = "test.csv";
            var result = SaveJsonToS3Helper.EnsureFileIsJson(fileName);
            
           
        }

        [Test]
        public void EditsFileNameSoItContainsJsonExtension()
        {
            var fileName = "test";
            var expectedFileName = "test.json";
            var result = SaveJsonToS3Helper.EnsureFileIsJson(fileName);
            result.Should().Be(expectedFileName);
        }
    }
}
