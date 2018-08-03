﻿using System.Collections.Generic;
using ZokuChat.Data;
using ZokuChat.Models;

namespace ZokuChat.Services
{
    public interface IContactService
    {
		List<Contact> GetUserContacts(ZokuChatUser user);
    }
}