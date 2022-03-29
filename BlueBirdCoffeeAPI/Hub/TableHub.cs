using Data.ViewModels;
using Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hub
{
    public interface ITableHub
    {
        Task ChangeStatus(OrderViewModel model, string userId);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TableHub : DynamicHub, ITableHub
    {
        public static ConcurrentDictionary<string, List<string>> ConnectedUsers = new ConcurrentDictionary<string, List<string>>();
        public IHubContext<NotificationHub> Current { get; set; }

        public TableHub(IHubContext<NotificationHub> current)
        {
            Current = current;
        }

        public async Task ChangeStatus(OrderViewModel model, string userId)
        {
            try
            {
                List<string> ReceiverConnectionids;
                ConnectedUsers.TryGetValue(userId, out ReceiverConnectionids);
                await Current.Clients.Clients(ReceiverConnectionids).SendAsync("newNotify", model);
            }
            catch (Exception) { }
        }

        public override Task OnConnectedAsync()
        {
            Trace.TraceInformation("MapHub started. ID: {0}", Context.ConnectionId);

            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(Context.User.GetId(), out existingUserConnectionIds);

            if (existingUserConnectionIds == null)
            {
                existingUserConnectionIds = new List<string>();
            }

            existingUserConnectionIds.Add(Context.ConnectionId);
            ConnectedUsers.TryAdd(Context.User.GetId(), existingUserConnectionIds);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            List<string> existingUserConnectionIds;
            ConnectedUsers.TryGetValue(Context.User.GetId(), out existingUserConnectionIds);

            existingUserConnectionIds.Remove(Context.ConnectionId);
            if (existingUserConnectionIds.Count == 0)
            {
                List<string> garbage;
                ConnectedUsers.TryRemove(Context.User.GetId(), out garbage);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}
