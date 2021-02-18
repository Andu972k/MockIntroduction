using System;
using System.IO;
using Moq;

namespace MockIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var mockedProvider = new Mock<NumberProvider>();

            mockedProvider.SetupSequence(NP => NP.ProvideNumber()).Returns(9).Returns(9).Returns(5);

            mockedProvider.Setup(NP => NP.ProvideException()).Throws<IOException>();

            NumberProvider testMock = mockedProvider.Object;

            Console.WriteLine(testMock.ProvideNumber());
            Console.WriteLine();
            Console.WriteLine(testMock.ProvideNumber());
            Console.WriteLine();
            Console.WriteLine(testMock.ProvideNumber());
            Console.WriteLine();
            Console.WriteLine(testMock.ProvideNumber());
            Console.WriteLine();
            Console.WriteLine(testMock.ProvideNumber());
            Console.WriteLine();

            try
            {
                testMock.ProvideException();
            }
            catch (IOException e)
            {
                Console.WriteLine("IOException was caught");
            }

            Console.WriteLine();

            foreach (var invocation in mockedProvider.Invocations)
            {
                Console.WriteLine(invocation.ToString());
            }

        }
    }
}
