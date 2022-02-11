﻿using System.Linq;
using System.Security.Claims;
using DLL.Models;
using DLL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HermesChatTeamB_v3.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private ApplicationDbContext _ctx;

        public RoomViewComponent(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chats = _ctx.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == userId
                    && x.Chat.Type == ChatType.Room)
                .Select(x => x.Chat)
                .ToList();

            return View(chats);
        }
    }
}


