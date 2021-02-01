using HttpTracer.Logger;
using System.Diagnostics;

namespace OpenGazettes.Services.Implementation
{
    public class HttpDebugLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}