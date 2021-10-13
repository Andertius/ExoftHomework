using System.Threading;

namespace CallCenterThread
{
    public class ThreadArgs
    {
        public Call Call { get; init; }

        public CancellationToken Token { get; init; }
    }
}
