using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Particles2D;
namespace PaintedBells.Code.ECS.ECSTest {
    [TestClass]
    public class ProcessTest {
        [TestMethod]
        public void Interpolation_Halfway_Returns_Average() {
            Range range = new Range(5, 15);
            Assert.AreEqual(10, range.Lerp(0.5));
        }
        [TestMethod]
        public void Interpolation_Start_Returns_Min() {
            Range range = new Range(5, 15);
            Assert.AreEqual(5, range.Lerp(0));
        }
        [TestMethod]
        public void Interpolation_End_Returns_Max() {
            Range range = new Range(5, 15);
            Assert.AreEqual(15, range.Lerp(1));
        }
        [TestMethod]
        public void Interpolation_Ouside_Range_Returns_Borders() {
            Range range = new Range(5, 15);
            Assert.AreEqual(15, range.Lerp(16));
            Assert.AreEqual(5, range.Lerp(-19));
        }
    }
}
