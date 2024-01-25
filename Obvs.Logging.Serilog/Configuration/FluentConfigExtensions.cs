using Obvs.Configuration;
using System;

namespace Obvs.Logging.Serilog.Configuration
{
    public static class FluentConfigExtensions
    {
        /// <summary>
        /// A shared <see cref="global::Serilog.Log.Logger"/> will be used.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <typeparam name="TCommand"></typeparam>
        /// <typeparam name="TEvent"></typeparam>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="configurator"></param>
        /// <param name="enableLogging"></param>
        /// <param name="logLevelSend"></param>
        /// <param name="logLevelReceive"></param>
        /// <returns></returns>
        public static ICanCreate<TMessage, TCommand, TEvent, TRequest, TResponse> UsingSerilog<TMessage, TCommand, TEvent, TRequest, TResponse>(this ICanAddEndpointOrLoggingOrCorrelationOrCreate<TMessage, TCommand, TEvent, TRequest, TResponse> configurator,
            Func<IEndpoint<TMessage>, bool> enableLogging = null,
            Func<Type, LogLevel> logLevelSend = null,
            Func<Type, LogLevel> logLevelReceive = null)
            where TMessage : class
            where TCommand : class, TMessage
            where TEvent : class, TMessage
            where TRequest : class, TMessage
            where TResponse : class, TMessage
        {
            return configurator.UsingLogging(new SerilogLoggerFactory(), enableLogging, logLevelSend, logLevelReceive);
        }
    }
}
