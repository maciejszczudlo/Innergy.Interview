using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Innergy.Interview.Test.Mocks;
using NUnit.Framework;

namespace Innergy.Interview.Test.Unit
{
    public class TransferTests
    {
        [Test]
        public void Magazines_Should_Be_Grouped_And_Sorted_By_Total_Desc()
        {

            var transfer = new Transfer();

            var input = new InputDataModel[]
            {
                MockRepository.CreateInput("matA", "mag-A", 1, "mag-B", 100, "mag-C", 20),
                MockRepository.CreateInput("matB", "mag-A", 1, "mag-B", 101, "mag-C", 22),

            }.ToList();

            var output = transfer.Process(input);

            output[0].MagazineId.Should().Be("mag-B");
            output[1].MagazineId.Should().Be("mag-C");
            output[2].MagazineId.Should().Be("mag-A");
        }

        [Test]
        public void Magazines_With_Same_Total_Should_Be_Sorted_By_Id_Desc()
        {
            var transfer = new Transfer();

            var input = new InputDataModel[]
            {
                MockRepository.CreateInput("matA", "mag-A", 1, "mag-B", 1, "mag-C", 1),
                MockRepository.CreateInput("matB", "mag-A", 1, "mag-B", 1, "mag-C", 1),

            }.ToList();

            var output = transfer.Process(input);

            output[0].MagazineId.Should().Be("mag-C");
            output[1].MagazineId.Should().Be("mag-B");
            output[2].MagazineId.Should().Be("mag-A");
        }

        [Test]
        public void Materials_Should_Be_Sorted_By_Id()
        {
            var transfer = new Transfer();

            var input = new InputDataModel[]
            {
                MockRepository.CreateInput("matA", "mag-A", 1, "mag-B", 34),
                MockRepository.CreateInput("matB", "mag-A", 1, "mag-B", 23),
                MockRepository.CreateInput("matC", "mag-A", 1, "mag-B", 23)

            }.ToList();

            var output = transfer.Process(input);


            foreach (var outputItem in output)
            {
                outputItem.Materials[0].Id.Should().Be("matA");
                outputItem.Materials[1].Id.Should().Be("matB");
                outputItem.Materials[2].Id.Should().Be("matC");
            }


        }

    }
}

