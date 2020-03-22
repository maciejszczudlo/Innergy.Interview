using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Innergy.Interview.Test.Unit
{
    public class EtlServiceTests
    {
        [Test]
        public void EtlService_Should_Return_Data_As_In_Example()
        {
            string[] output = null;
            
            // arrange
            var mockFileSystem = Substitute.For<IFileSystemService>();
            mockFileSystem.ReadLinesAsync(Arg.Any<string>())
                .Returns((path) => Task.FromResult(MockRepository.GetExampleInput()));
            mockFileSystem.WriteLinesAsync(Arg.Any<string>(), Arg.Any<string[]>())
                .Returns((callInfo) =>
                {
                    output = (string[]) callInfo[1];
                    return Task.CompletedTask;
                });

            var builder = Program.GetBuilder();
            builder.RegisterInstance(mockFileSystem).AsImplementedInterfaces().SingleInstance();

            using var container = builder.Build();
            using var scope = container.BeginLifetimeScope();
            var etlService = scope.Resolve<IEtlService>();

            // act
            etlService.Process(default, default);
            
            // assert
            var expectedOutput = MockRepository.GetExampleExpectedOutput();

            output.Should().BeEquivalentTo(expectedOutput);
        }


    }
    
}
