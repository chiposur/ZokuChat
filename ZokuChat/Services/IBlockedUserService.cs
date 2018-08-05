﻿using System.Collections.Generic;
using ZokuChat.Data;
using ZokuChat.Models;

namespace ZokuChat.Services
{
    interface IBlockedUserService
    {
		void BlockUser(User blocker, User blocked);

		void UnblockUser(User blocker, User blocked);

		bool IsUserBlocked(User user, User blocker);

		List<BlockedUser> GetUsersBlockedUsers(User user);

		List<User> GetUsersWhoBlockedUser(User user);
    }
}