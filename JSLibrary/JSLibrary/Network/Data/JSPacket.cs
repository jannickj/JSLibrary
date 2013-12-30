using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace JSLibrary.Network.Data
{
    [Serializable]
    public class JSPacket
    {
       
        private Dictionary<string, object> info = new Dictionary<string, object>();


        public void Add(string name, object data)
        {
            this.info.Add(name, data);
        }

        public object Get(string name)
        {
            return info[name];
        }


        internal Type MessageType { get; set; }
    }
}
