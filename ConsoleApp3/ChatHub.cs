using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ChatHub : Hub
    {
        public ChatHub()
        {
            Console.WriteLine("Startup");
        }

        Random rand = new Random();
        public async Task SendMessage(string user, string message)
        {
            await Console.Out.WriteLineAsync("Testing");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetID(string user)
        {
            Console.WriteLine("GET ID CALLED");
            int id = rand.Next();
            await Clients.Caller.SendAsync("ReciveID", id);
        }

        public async override Task OnConnectedAsync()
        {
            await Console.Out.WriteLineAsync("New Connection");
            var user = Context.GetHttpContext().User;
        }
    }
}
