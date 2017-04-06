﻿namespace Uml.Robotics.XmlRpc
{
    public delegate void XmlRpcFunc(XmlRpcValue parms, XmlRpcValue result);

    public class XmlRpcServerMethod
    {
        private string name;
        private XmlRpcServer server;
        private XmlRpcFunc func;

        public XmlRpcServerMethod(string functionName, XmlRpcFunc func, XmlRpcServer server, bool autoAddToServer = true)
        {
            name = functionName;
            this.server = server;
            this.func = func;
            if (server != null && autoAddToServer)
                server.AddMethod(this);
        }

        public string Name
        {
            get { return name; }
        }

        public XmlRpcServer Server
        {
            get { return server; }
        }

        public XmlRpcFunc Func
        {
            get { return func; }
            set { func = value; }
        }

        public void Execute(XmlRpcValue parms, XmlRpcValue result)
        {
            func(parms, result);
        }

        public virtual string Help()
        {
            return "no help";
        }
    }
}
