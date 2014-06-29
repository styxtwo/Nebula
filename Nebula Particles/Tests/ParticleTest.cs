using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nebula.Particles2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Nebula.Tests {
    [TestClass]
    public class ParticleTest {
        [TestMethod]
        public void Particle_Duplicates_Template() {
            Particle template = new Particle(null, 1, 1, 0);
            Particle particle = new Particle(template);
            Assert.AreEqual(template.Alpha, particle.Alpha);
            Assert.AreEqual(template.color, particle.color);
            Assert.AreEqual(template.Scale, particle.Scale);
            Assert.AreEqual(template.Rotation, particle.Rotation);
        }
        [TestMethod]
        public void Update_Velocity_Adds_To_Position() {
            Particle particle = new Particle(null,1,1,0);
            particle.Reset(particle, new Vector2(0, 0), new Vector2(10, 0), 10);
            particle.Update(1);
            Assert.AreEqual(10, particle.Position.X);
        }
        [TestMethod]
        public void Update_Increases_Age() {
            Particle particle = new Particle(null, 1, 1, 0);
            particle.Reset(particle, new Vector2(0, 0), new Vector2(10, 0), 10);
            particle.Update(10);
            Assert.AreEqual(true, particle.IsAlive());
            particle.Update(11);
            Assert.AreEqual(false, particle.IsAlive());
        }
    }
}
