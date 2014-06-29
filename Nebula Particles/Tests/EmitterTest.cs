using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Particles2D;

namespace Nebula.Tests {
    [TestClass]
    public class EmitterTest {
        [TestMethod]
        public void Emit_50_Particles_Long_Lifespan_Expect_50_Living() {
            Particle particle = new Particle(null, 1, 1, 0);
            Range lifespan = new Range(1001, 1001);
            Emitter emitter = new Emitter(particle, new Range(0, 0), new Range(0, 0), lifespan, new Random(), 50);
            emitter.Update(1000);

            Assert.AreEqual(50, emitter.GetAliveParticles());
            Assert.AreEqual(0, emitter.GetDeadParticles());
        }
        [TestMethod]
        public void Emit_50_Particles_Short_Lifespan_Expect_50_Dead() {
            Particle particle = new Particle(null, 1, 1, 0);
            Range lifespan = new Range(0, 0);
            Emitter emitter = new Emitter(particle, new Range(0, 0), new Range(0, 0), lifespan, new Random(), 50);
            emitter.Update(1000);

            Assert.AreEqual(0, emitter.GetAliveParticles());
            Assert.AreEqual(50, emitter.GetDeadParticles());
        }
        [TestMethod]
        public void Emit_500_Particles_Short_Lifespan_250_Dead_Particles_Get_Cleaned_Up() {
            Particle particle = new Particle(null, 1, 1, 0);
            Range lifespan = new Range(0, 0);
            Emitter emitter = new Emitter(particle, new Range(0, 0), new Range(0, 0), lifespan, new Random(), 500);
            emitter.Update(1000);

            Assert.AreEqual(0, emitter.GetAliveParticles());
            Assert.AreEqual(250, emitter.GetDeadParticles());
        }
    }
}
