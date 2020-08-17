using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_Streaming_Trial21.Hubs
{
    public class AsyncEnumerableHub : Hub
    {
        public async IAsyncEnumerable<string> Counter(
            int count,
            int delay,
            [EnumeratorCancellation]
        CancellationToken cancellationToken)
        {
            for (var i = 0; i < count; i++)
            {
                // Check the cancellation token regularly so that the server will stop
                // producing items if the client disconnects.
                cancellationToken.ThrowIfCancellationRequested();

                yield return GetDate();

                // Use the cancellationToken in other APIs that accept cancellation
                // tokens so the cancellation can flow down to them.
                await Task.Delay(delay, cancellationToken);
            }
        }
        public string GetDate()
        {
            StringBuilder strBuilder = new StringBuilder("");
            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                
                strBuilder.Append(random.Next(1, 100));
                strBuilder.Append(" ,");
            }
            //strBuilder.Append(random.Next(1, 100));
            return strBuilder.ToString();
        }
    }


}
