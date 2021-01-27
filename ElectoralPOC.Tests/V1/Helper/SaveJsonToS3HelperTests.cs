using Bogus;
using ElectoralPOC.V1.Boundary.Request;
using ElectoralPOC.V1.Controllers;
using ElectoralPOC.V1.Domain.Exceptions;
using ElectoralPOC.V1.Helpers;
using ElectoralPOC.V1.UseCase.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
        public void EditsFileNameSoItContainsJsonExtension()
        {
            var fileName = "test";
            var expectedFileName = "test.json";
            var result = SaveJsonToS3Helper.EnsureFileIsJson(fileName);
            result.Should().Be(expectedFileName);
        }

        [Test]
        public void ReturnsFilenameIfExtensionIsCorrect()
        {
            var filename = "test.json";
            var result = SaveJsonToS3Helper.EnsureFileIsJson(filename);
            result.Should().Be(filename);
        }

        [Test]
        public void ThrowErrorIfExtensionIsInCorrect()
        {
            var filename = "test.csv";
            Assert.Throws<FileNameContainsInvalidExtensionException>(() => SaveJsonToS3Helper.EnsureFileIsJson(filename));
        }

    }
}
