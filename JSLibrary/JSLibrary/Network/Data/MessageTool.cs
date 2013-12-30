using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Network.Data
{
    public class MessageTool
    {

        public JSPacket Pack(JSMessage msg)
        {
            var packet = new JSPacket();
            packet.MessageType = msg.GetType();
            msg.OnSerialize(packet);
            return packet;
        }

        public JSMessage Open(JSPacket packet)
        {
            Type type = packet.MessageType;
            var msg = (JSMessage)Activator.CreateInstance(type);
            OnOpening(msg);
            msg.OnDeserialize(packet);
            
            return msg;
        }

        protected virtual void OnOpening(JSMessage message)
        {

        }
    }
}
