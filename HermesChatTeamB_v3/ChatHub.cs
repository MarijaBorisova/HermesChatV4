﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using DLL.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;


namespace HermesChatTeamB_v3
{
    [Authorize]
    public class ChatHub : Hub
    {
        ///// <summary>
        ///// The user tracker to keep track of online users.
        ///// </summary>
        //private IUserTracker userTracker;

        ///// <summary>
        /////  Initializes a new instance of the <see cref="ChatHub"/> class.
        ///// </summary>
        ///// <param name="userTracker">The user tracker.</param>
        //public ChatHub(IUserTracker userTracker)
        //{
        //    this.userTracker = userTracker;
        //}

        ///// <summary>
        ///// Gets all the connected user list.
        ///// </summary>
        ///// <returns>The collection of online users.</returns>
        //public async Task<IEnumerable<UserInformation>> GetOnlineUsersAsync()
        //{
        //    return await userTracker.GetAllOnlineUsersAsync();
        //}

        ///// <summary>
        ///// Fires on client connected.
        ///// </summary>
        ///// <returns>The task.</returns>
        //public override async Task OnConnectedAsync()
        //{
        //    /*await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
        //    await base.OnConnectedAsync();*/

        //    var user = Helper.GetUserInformationFromContext(Context);
        //    await this.userTracker.AddUserAsync(Context, user);
        //    await Clients.All.SendAsync("UsersJoined", new UserInformation[] { user }); //InvokeAsync
        //    //// On connection, refresh online list.
        //    await Clients.All.SendAsync("SetUsersOnline", await GetOnlineUsersAsync());
        //    await base.OnConnectedAsync();
        //}

        ///// <summary>
        ///// Fires when client disconnects.
        ///// </summary>
        ///// <param name="exception">The exception.</param>
        ///// <returns>The task.</returns>
        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    var user = Helper.GetUserInformationFromContext(Context);
        //    await Clients.All.SendAsync("UsersLeft", new UserInformation[] { user });
        //    await this.userTracker.RemoveUserAsync(Context);
        //    //// On disconnection, refresh online list.
        //    await Clients.All.SendAsync("SetUsersOnline", await GetOnlineUsersAsync());
        //    await base.OnDisconnectedAsync(exception);

        //}

        ///// <summary>
        ///// Sends the message to all the connected clients.
        ///// </summary>
        ///// <param name = "message" > The message to be sent.</param>
        ///// <returns>A task.</returns>
        ///// 
        //public async Task Send(string message)
        //{
        //    UserInformation user = Helper.GetUserInformationFromContext(Context);
        //    await Clients.All.SendAsync("Send", user.Name, message);
        //}


        public async Task Send(string message, string to)
        {
            var userName = Context.User.Identity.Name;

            if (Context.UserIdentifier != to) // if the user and current client are not matched
                await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
            await Clients.User(to).SendAsync("Receive", message, userName);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"WELCOME,{Context.UserIdentifier}, to Hermes Chat");
            await base.OnConnectedAsync();
        }
    }
}
  