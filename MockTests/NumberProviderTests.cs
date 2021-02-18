using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockIntroduction;
using Moq;

namespace MockTests
{
    [TestClass]
    public class NumberProviderTests
    {

        [TestMethod]
        public void ProvideNumber_CalledFiveTimes()
        {
            //Arrange

            var mockedProvider = new Mock<NumberProvider>();

            mockedProvider.SetupSequence(NP => NP.ProvideNumber()).Returns(9).Returns(9).Returns(5);

            NumberProvider testMock = mockedProvider.Object;

            //Act

            testMock.ProvideNumber();
            testMock.ProvideNumber();
            testMock.ProvideNumber();
            testMock.ProvideNumber();
            testMock.ProvideNumber();
            //testMock.ProvideNumber(); //Fails if this line is invoked

            //Assert 

            mockedProvider.Verify(NP => NP.ProvideNumber(), Times.Exactly(5));
        }


    }
}
