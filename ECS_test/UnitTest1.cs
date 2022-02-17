using NUnit.Framework;
using ECS.Legacy;

namespace ECS_test
{
    public class Tests
    {
        private ECS1 ecs;
        private FakeTempSensor fts;

        [SetUp]
        public void Setup()
        {
            //Arrange
            ecs = new ECS1(23, new FakeHeater(), new FakeTempSensor());
            fts = new FakeTempSensor();
        }

        [Test]
        public void Test1()
        {
            Assert.That(fts.GetTemp(),Is.EqualTo(5));
        }
    }
}