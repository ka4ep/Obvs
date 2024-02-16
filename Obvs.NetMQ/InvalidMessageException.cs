using System;
using System.Collections.Generic;
using System.Text;

namespace Obvs.NetMQ
{
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException(string errorMessage, IReadOnlyCollection<Tuple<byte[], string>> frames) : base(errorMessage)
        {
            Frames = frames ?? Array.Empty<Tuple<byte[], string>>();
        }

        public IReadOnlyCollection<Tuple<byte[], string>> Frames { get; }

    }
}
