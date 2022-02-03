using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace HermesChatTeamB_v3
{
    [Authorize]
    public class ChatHub : Hub
    {
        //public async Task Send(string message, string userName)
        //{
        //    await Clients.All.SendAsync("Receive", message, userName);
        //}
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} signed in the chat");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} signed out the chat");
            await base.OnDisconnectedAsync(exception);
        }
    }

    //[Authorize(Roles = "admin")]
    //public async Task Notify(string message, string userName)
    //{
    //    await Clients.All.SendAsync("Receive", message, userName);
    //}
}
