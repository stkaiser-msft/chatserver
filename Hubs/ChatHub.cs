using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace chatserver.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentBag<string> _names = new ConcurrentBag<string>();

        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", Util.Sanitize(name), Util.MdToHtml(message));
        }

        public async Task RegisterName(string name)
        {
            // Add a name to the list.
            string newName = Util.Sanitize(name);
            if (!_names.Contains<string>(newName) && newName != string.Empty)
            {
                _names.Add(newName);
            }
            await SendNames();
        }

        public async Task SendNames()
        {
            // Send the name list to all clients.
            await Clients.All.SendAsync("nameList", _names.ToArray<string>());
        }

    }
}