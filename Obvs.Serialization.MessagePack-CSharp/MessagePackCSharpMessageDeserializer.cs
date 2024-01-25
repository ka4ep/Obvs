using System.IO;
using MessagePack;
using MessagePack.Resolvers;

namespace Obvs.Serialization.MessagePack
{
    public class MessagePackCSharpMessageDeserializer<TMessage> : MessageDeserializerBase<TMessage> 
        where TMessage : class
    {
        private readonly MessagePackSerializerOptions _options;

        public MessagePackCSharpMessageDeserializer() : this(null)
        {
        }

        public MessagePackCSharpMessageDeserializer(IFormatterResolver resolver)
        {
            _options = MessagePackSerializer.DefaultOptions.WithResolver(resolver ?? MessagePackSerializer.DefaultOptions.Resolver);
        }

        public override TMessage Deserialize(Stream source)
        {
            return MessagePackSerializer.Deserialize<TMessage>(stream: source, options: _options);
        }
    }
}