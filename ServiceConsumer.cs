using System;
using System.IO.Pipes;
using System.IO;

namespace AirpodsStartbarService
{
    class ServiceConsumer
    {

        private string _pipeName;

        public string pipeName
        {
            get
            {
                return _pipeName;
            }
            set
            {
                _pipeName = value;
            }
        }

        public ServiceConsumer(string pipeServiceName)
        {
            pipeName = pipeServiceName;
        }

        public string readPipe()
        {
            using (NamedPipeClientStream pipe = new NamedPipeClientStream(
                ".",
                pipeName,
                PipeAccessRights.ReadData | PipeAccessRights.WriteAttributes,
                PipeOptions.None,
                System.Security.Principal.TokenImpersonationLevel.None,
                HandleInheritability.None
                ))
            {
                try
                {
                    pipe.Connect();
                }
                catch (UnauthorizedAccessException uae)
                {
                    return "Cannot connect to pipe";
                }
                catch (System.Reflection.TargetInvocationException tie)
                {
                    return "Already Connected to pipe";
                }
                catch (IOException ioe)
                {
                    return ioe.Message;
                }

                StreamReader pipeStream;
                string result;
                try
                {
                    using (pipeStream = new StreamReader(pipe))
                    {
                        result = pipeStream.ReadLine();
                    }
                }
                catch
                {
                    Console.WriteLine("Unable to open StreamReader to pipe");
                    result = "";
                }
                pipe.Close();
                return result;
            }
  
        }
    }
}
