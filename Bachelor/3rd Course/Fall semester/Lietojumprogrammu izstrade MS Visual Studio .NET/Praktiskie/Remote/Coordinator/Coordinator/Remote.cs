using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Coordinator
{
    [Serializable]
    public struct ServerMsg
    {
        public bool ChoosenCross;
        public string ControlName;
    };

    [Serializable]
    public struct ClientMsg
    {
        public bool _ChoosenCross;
        public string _ControlName;
    };

    public class Remote : MarshalByRefObject
    {
        public delegate ClientMsg Submission(ServerMsg Msg);
        public event Submission SubmitEventHandler;

        public Remote() { }

        public ClientMsg callCln(ServerMsg Msg)
        {
            return SubmitEventHandler(Msg);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
