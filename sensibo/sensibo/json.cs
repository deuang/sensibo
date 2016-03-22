using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sensibo.sensibo
{
    class json
    {
    }

    public class Pod
    {
        public string id { get; set; }
    }

    public class pods
    {
        public string status { get; set; }
        public List<Pod> pod { get; set; }
    }

}
