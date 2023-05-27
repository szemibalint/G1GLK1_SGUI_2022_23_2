using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace G1GLK1_SGUI_2023_23_2.Services
{
    public class SignalR : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }

}