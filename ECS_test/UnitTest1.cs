using NUnit.Framework;
using ECS.Legacy;
using NSubstitute;

namespace ECS_test
{
    public class Tests
    {
        //gg
        private ECS1 ecs;
        private ITempSensor _tempSensor;
        private IHeater _heater;

        [SetUp]
        public void Setup()
        {
            //Arrang
            //ecs = new ECS1(23, new FakeHeater(), new FakeTempSensor());
            //_tempSensor = new FakeTempSensor();

            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            ecs = new ECS1(25, _heater, _tempSensor);
        }

        [Test]
        public void StubTest()
        {
            _tempSensor.RunSelfTest().Returns(true);
            _heater.RunSelfTest().Returns(true);
            Assert.IsTrue(ecs.RunSelfTest());
        }

        [Test]
        public void MockTest()
        {
            //Her tester vi at heater is on hvis temperaturen er mindre end threshold
            _tempSensor.GetTemp().Returns(25);
            ecs.Regulate();
            _heater.Received(1).TurnOff();
        }

    }
}