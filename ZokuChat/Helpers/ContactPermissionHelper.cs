﻿using FluentAssertions;
using ZokuChat.Data;
using ZokuChat.Models;

namespace ZokuChat.Helpers
{
    public class ContactPermissionHelper
    {
		public static bool CanDeleteContact(User actionUser, Contact contact)
		{
			// Validate
			actionUser.Should().NotBeNull();
			contact.Should().NotBeNull();

			// Return whether or not the action user is part of the contact pair
			return contact.UserUID.Equals(actionUser.Id) || contact.ContactUID.Equals(actionUser.Id);
		}
    }
}
