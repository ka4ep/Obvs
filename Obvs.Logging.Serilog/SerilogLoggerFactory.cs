namespace Obvs.Logging.Serilog
{
    public class SerilogLoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name)
        {
            var logger = global::Serilog.Log.Logger;
            _ = logger.BindProperty("Name", name, true, out _);
            return new SerilogLoggerWrapper(logger);
        }

        public ILogger Create<T>() => Create(typeof(T).FullName);
        
    }
}
