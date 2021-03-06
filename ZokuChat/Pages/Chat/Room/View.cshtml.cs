using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZokuChat.Helpers;
using ZokuChat.Models;
using ZokuChat.Services;

namespace ZokuChat.Pages.Chat.Room
{
    public class ViewModel : PageModel
    {
		private readonly Context _context;
		private readonly IRoomService _roomService;

		public ViewModel(Context context, IRoomService roomService)
		{
			_context = context;
			_roomService = roomService;
		}

		public Models.Room Room;

        public IActionResult OnGet(int id)
        {
			if (id > 0)
			{
				Room = _roomService.GetRoom(id);
			}

			if (Room == null || !RoomPermissionHelper.CanViewRoom(_context.CurrentUser, Room))
			{
				return LocalRedirect(UrlHelper.GetAccessDeniedUrl());
			}
			else
			{
				return Page();
			}
        }
    }
}