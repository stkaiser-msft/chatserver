using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace chatserver.Hubs
{
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> _names = new ConcurrentDictionary<string,string>();

        public async Task Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            await Clients.All.SendAsync("broadcastMessage", Util.Sanitize(name), Util.MdToHtml(message));
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }
        public async Task RegisterName(string name)
        {
            // Add a name to the list.
            string newName = Util.Sanitize(name);
            if (!_names.Values.Contains<string>(newName) && newName != string.Empty)
            {
                string conn = Context.ConnectionId;
                _names.TryAdd(conn, newName);
            }
            await SendNames();
        }

        public async Task SendNames()
        {
            // Send the name list to all clients.
            await Clients.All.SendAsync("nameList", _names.Values.ToArray<string>());
        }

    }
}