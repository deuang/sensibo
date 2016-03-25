using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sensibotest
{
    [TestClass]
    public class sensibotester
    {
        [TestMethod]
        public void Testpods()
        {
            sensibo.api sapi = new sensibo.api("APIKEY");
            sapi.getPods();
            sapi.getPodStatus("ENTER POD NUMBER");
            sapi.getPodMeasurments("ENTER POD NUMBER");

            sensibo.sensibo.SetAcState state = new sensibo.sensibo.SetAcState();
            state.fanLevel = "low";
            state.on = false;
            state.targetTemperature = 22;
            state.mode = "fan";
            sapi.SetStatus("POD ID", state);
        }
    }
}
