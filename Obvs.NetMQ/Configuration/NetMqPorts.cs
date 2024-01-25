namespace Obvs.NetMQ.Configuration
{
    public class NetMqPorts
    {
        public int Request { get; }
        public int Response { get; }
        public int Command { get; }
        public int Event { get; }

        /// <summary>
        /// Sequential ports.
        /// <see cref="Request"/> =<paramref name="port"/>,
        /// <see cref="Response"/> = <paramref name="port"/> + 1,
        /// <see cref="Command"/> = <paramref name="port"/> + 2,
        /// <see cref="Event"/> = <paramref name="port"/> + 3.
        /// </summary>
        /// <param name="port"></param>
        public NetMqPorts(int port) : this(port, port+1,port+2,port+3)
        {            
        }

        /// <summary>
        /// User-defined ports for each channel.
        /// </summary>
        /// <param name="requestPort"></param>
        /// <param name="responsePort"></param>
        /// <param name="commandPort"></param>
        /// <param name="eventPort"></param>
        public NetMqPorts(int requestPort, int responsePort, int commandPort, int eventPort)
        {
            Request = requestPort;
            Response = responsePort;
            Command = commandPort;
            Event = eventPort;
        }
        /// <summary>
        /// Define sequential ports.
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static NetMqPorts Sequential(int port) => new NetMqPorts(port);
        /// <summary>
        /// User-defined ports.
        /// </summary>
        /// <param name="requestPort"></param>
        /// <param name="responsePort"></param>
        /// <param name="commandPort"></param>
        /// <param name="eventPort"></param>
        /// <returns></returns>
        public static NetMqPorts UserDefined(int requestPort, int responsePort, int commandPort, int eventPort)
            => new NetMqPorts(requestPort, responsePort, commandPort, eventPort);
    }
}
