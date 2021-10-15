using System;
using Xunit;
using ValidStringParentheses;
using Moq;


namespace XUnitTestProject1
{
    public class UnitTest1
    {
        Program _p;

        public UnitTest1()
        {
            _p = new Program();
        }
        [Theory]     // or [Fact]
        [InlineData("(())")]
        [InlineData("((]))")]
        [InlineData("([())")]
        [InlineData("({())")]
        public void Test1(string str)     //input.Setup is to replace the oringal method
        {
            Mock<ITakeInput> input = new Mock<ITakeInput>();      // object creation        // mock means copy a copy of the interface
            input.Setup(t => t.TakeInputMethod()).Returns(str);       // whenever someone call method Test1, wont call original implementation but will return this string
            CheckString checkstring = new CheckString(input.Object);
            bool res = checkstring.checkValidString();
            Assert.True(res);
        }
        // different test but same results for all
        // ms test       
        // xunit
        // nunit


        //for xunit
        //e.g. normal project - consoleapp.netframework
        //then go solutions - add project choose xUnit Test project
        //solution explorer - right click xUnittestproject1 - change<TargetFramework> net48</TargetFramework.    -- to net48
        //then save, then right click xUnittestproject1 = and BUILD

        //Then right click xUnittestproject1 - add project reference - normal project
        //go to normal project and make class all public

    }
}
