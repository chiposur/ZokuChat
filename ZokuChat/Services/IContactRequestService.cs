﻿using System;
using System.Collections.Generic;
using ZokuChat.Data;
using ZokuChat.Models;

namespace ZokuChat.Services
{
    public interface IContactRequestService
    {
		List<ContactRequest> GetContactRequestsToUser(User user);

		List<ContactRequest> GetContactRequestsFromUser(User user);

		void CreateContactRequest(User fromUser, User toUser);

		void CancelContactRequest(User actionUser, ContactRequest request);

		void ConfirmContactRequest(User actionUser, ContactRequest request);

		ContactRequest GetContactRequest(int requestId);

		List<ContactRequest> GetUsersContactRequestsByUser(User fromUser, User toUser);

		bool HasActiveContactRequest(User fromUser, User toUser);
	}
}
