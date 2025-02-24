using Microsoft.Extensions.Primitives;

namespace DesignPatternsPlayground.Patterns
{
    sealed class SingletonDB
    {
        private static SingletonDB? _instance;
        private static readonly object _lock = new object();
        public string? Value { get; set; } = null;

        private SingletonDB()
        {

        }

        public static SingletonDB GetInstance(string value)
        {
            if (_instance == null)
            {
                // Locks external threads out of current instance if populated by a single thread.
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonDB();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
    }
}
