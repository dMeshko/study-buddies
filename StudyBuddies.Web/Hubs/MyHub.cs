using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace StudyBuddies.Web.Hubs
{
    public class MyHub : Hub
    {
        public void Subscribe(string userId)
        {
            Groups.Add(Context.ConnectionId, userId);
        }

        public void Unsubscribe(string userId)
        {
            Groups.Remove(Context.ConnectionId, userId);
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}