using Microsoft.AspNetCore.Mvc;
using HermesChatTeamB_v3.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace HermesChatTeamB_v3.Controllers
{
    public class ChatController : Controller
    {


        IHubContext<ChatHub> hubContext;
        public ChatController(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //public async Task SendMessage(string user, string message)
        //{
        //    await _hubContext.Clients.All.SendAsync(user, message);
        //}

        //[HttpPost]
        public async Task<IActionResult> Create(string product)
        {
            await hubContext.Clients.All.SendAsync("Notify", $"Добавлено: {product} - {DateTime.Now.ToShortTimeString()}");
            return RedirectToAction("Index");
        }
    }
}
 
