using System.IO;
using MessagePack;

namespace Obvs.Serialization.MessagePack
{
    public class MessagePackCSharpMessageSerializer : IMessageSerializer
    {
        private readonly MessagePackSerializerOptions _options;

        public MessagePackCSharpMessageSerializer() : this(null)
        {
        }

        public MessagePackCSharpMessageSerializer(IFormatterResolver resolver)
        {
            _options = MessagePackSerializer.DefaultOptions.WithResolver(resolver ?? MessagePackSerializer.DefaultOptions.Resolver);
        }

        public void Serialize(Stream destination, object message)
        {
            MessagePackSerializer.Serialize(type: message.GetType(), stream: destination, obj: message, options: _options);
        }
    }
}
