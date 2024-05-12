using heater;
using state;

namespace test;

public class TestHeater
{
    [Fact]
    public void test()
    {
        var heater = Heater.Instance;
        Assert.Equal(StateHeater.waiting, heater.state());

        heater.stop();
        Assert.Equal(StateHeater.waiting, heater.state());

        heater.start();
        Assert.Equal(StateHeater.running, heater.state());

        heater.start();
        Assert.Equal(StateHeater.running, heater.state());

        heater.stop();
        Assert.Equal(StateHeater.waiting, heater.state());
    }
}
