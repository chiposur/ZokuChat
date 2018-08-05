﻿using FluentAssertions;
using System;
using System.Linq;
using ZokuChat.Data;
using ZokuChat.Models;

namespace ZokuChat.Helpers
{
    public class ContactPermissionHelper
    {
		private readonly Context _context;

		public ContactPermissionHelper(Context context)
		{
			_context = context;
		}

		public bool CanDeleteContact(User actionUser, int contactId)
		{
			// Validate
			actionUser.Should().NotBeNull();
			contactId.Should().BeGreaterThan(0);

			bool result;

			if(_context.Contacts.Any(c => c.Id == contactId && new Guid(c.UserUID).Equals(new Guid(actionUser.Id))))
			{
				// The contact exists and is the action user's so return true
				result = true;
			}
			else
			{
				result = false;
			}

			return result;
		}
    }
}