using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Innergy.Interview.Test.Mocks;
using Innergy.Interview.Test.Unit;
using NUnit.Framework;

namespace Innergy.Interview.Test.Unit
{
    public class LoadTests
    {
        [Test]
        public void Magazines_Should_Be_Divided_By_Single_Line()
        {

            var load = new Load();
            var output = MockRepository.CreateOutputs("A", "B", "C");

            var result = load.Process(output);

            result.Should().HaveCount(5);

            result[0].Should().NotBeEmpty();
            result[1].Should().BeEmpty();
            result[2].Should().NotBeEmpty();
            result[3].Should().BeEmpty();
            result[4].Should().NotBeEmpty();
        }


        [Test]
        public void Magazine_Should_Be_Displayed_In_Specified_Format()
        {
            var load = new Load();
            var output = MockRepository.CreateOutputs("A");

            var result = load.Process(output);

            result.Should().HaveCount(1);

            result[0].Should().Be("A (total 0)");
        }

        [Test]
        public void Material_Should_Be_Displayed_In_Specified_Format()
        {
            // arrange
            var output = new List<OutputDataModel>
            {
                new OutputDataModel{MagazineId = "mag-A", Materials = new List<OutputMaterialModel>()
                {
                    new OutputMaterialModel
                    {
                        Id = "mat-A",
                        Count = 10
                    }
                }
            }};

            var load = new Load();

            // act
            var result = load.Process(output);

            // assert
            result.Should().HaveCount(2);
            result[1].Should().Be("mat-A: 10");
        }
    }
}
