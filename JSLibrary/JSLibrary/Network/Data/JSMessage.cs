using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Network.Data
{
    public abstract class JSMessage
    {

        internal protected abstract void OnSerialize(JSPacket packet);
        internal protected abstract void OnDeserialize(JSPacket packet);

        public abstract void Execute();
    }
}
