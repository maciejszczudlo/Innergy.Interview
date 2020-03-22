using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Innergy.Interview.Test.Mocks;
using NUnit.Framework;

namespace Innergy.Interview.Test.Unit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InputLineParser_Should_Parse_Given_Line()
        {
            var line = "Yankee Hardware 110 Deg. Hinge;COM-123908;WH-A,10|WH-B,11";

            var singleLinePaser = new InputLineParser();

            var result = singleLinePaser.Parse(line);

            var material = result;
            var magazines = result.Magazines;

            result.Should().NotBeNull();

            material.MaterialName.Should().Be("Yankee Hardware 110 Deg. Hinge");
            material.MaterialId.Should().Be("COM-123908");

            magazines.Should().HaveCount(2);

            magazines[0].Id.Should().Be("WH-A");
            magazines[0].Count.Should().Be(10);

            magazines[1].Id.Should().Be("WH-B");
            magazines[1].Count.Should().Be(11);
        }

        private static string[] LineCases => MockRepository.GetExampleInput()
            .Where(l => !l.StartsWith("#") && !string.IsNullOrEmpty(l))
            .ToArray();

        [Test, TestCaseSource(nameof(LineCases))]
        public void InputLineParser_Should_Parse_All_Lines(string line)
        {
            var singleLinePaser = new InputLineParser();

            var material = singleLinePaser.Parse(line);

            material.Should().NotBeNull();
            material.MaterialName.Should().NotBeNullOrEmpty();
            material.MaterialId.Should().NotBeNullOrEmpty();

            var magazines = material.Magazines;
            magazines.Should().HaveCountGreaterOrEqualTo(1);

        }

        [Test]
        [TestCase("# Test1", true)]
        [TestCase("## Test1", true)]
        [TestCase(" # Test1", false)]
        [TestCase("Test1", false)]
        public void IgnoreLineSpecification_Should_Check_If_Line_Ignored(string str, bool isToIgnoreExpected)
        {
            var specification = new IgnoreLineSpecification();

            var isToIgnored = specification.IsToBeIgnored(str);

            isToIgnored.Should().Be(isToIgnoreExpected);
        }
    }
}