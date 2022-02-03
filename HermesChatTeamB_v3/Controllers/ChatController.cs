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
        //private readonly ILogger<ChatController> _logger;

        //public ChatController(ILogger<ChatController> logger)
        //{
        //    _logger = logger;
        //}
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
        public async Task Create(string product, string connectionId)
        {
            await hubContext.Clients.AllExcept(connectionId).SendAsync("Notify", $"Добавлено: {product} - {DateTime.Now.ToShortTimeString()}");
            await hubContext.Clients.Client(connectionId).SendAsync("Notify", $"Ваш товар добавлен!");
        }


    }
}
