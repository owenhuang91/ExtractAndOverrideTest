using System;
using DateTimeValidate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace DateTimeTest {
    [TestClass]
    public class UnitTest1 {

        /// <summary>
        /// 使用Internal的方式解耦合(for單元測試特殊技巧)
        /// </summary>
        [TestMethod]
        public void ExtractAndOverrideTest() {

            //arrange
            var target = new ExtractAndOverrideDateTime();
            var expectd = new DateTime(2017, 6, 28);
            target.Now = expectd;

            //act
            var actual = target.CheckDate();

            //assert
            Assert.AreEqual(expectd, actual);
        }

        /// <summary>
        /// 正規抽介面作法
        /// </summary>
        [TestMethod]
        public void StubTest() {

            //arrange
            var dateTimeStub = Substitute.For<INewDateTime>();
            dateTimeStub.GetNow().Returns(new DateTime(2017, 6, 28));

            var target = new TestProgram(dateTimeStub);
            var expectd = "2017/06/28";

            //act
            var actual = target.Test();

            //assert
            Assert.AreEqual(expectd, actual);
        }
    }
}
