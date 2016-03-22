using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace sensibotest
{
    [TestClass]
    public class sensibotester
    {
        [TestMethod]
        public void Testgetpods()
        {
            sensibo.api sapi = new sensibo.api();
            sapi.getPods();
        }
    }
}
