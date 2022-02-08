using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DLL.Models
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity.Name;
            // or
            //return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}