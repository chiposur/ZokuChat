﻿using Microsoft.AspNetCore.Html;
using System.Linq;
using ZokuChat.Data;
using ZokuChat.Models;
using ZokuChat.Services;

namespace ZokuChat.Helpers
{
    public class HtmlHelper
    {
		public static HtmlString GetContactRequestButton(
			Context context,
			IContactService contactService,
			IContactRequestService contactRequestService,
			User user,
			string cssClasses = "")
		{
			if (contactRequestService.HasActiveContactRequest(user, context.CurrentUser))
			{
				int requestId = contactRequestService.GetContactRequestsFromUserToUser(user, context.CurrentUser).Where(r => r.IsActive()).Select(c => c.Id).First();

				return new HtmlString(
					$"<button class='btn btn-outline-success request-{requestId} {cssClasses} margin-right' onclick=\"window.ZokuChat.AcceptRequestButtonClick($(this), '{requestId}');\">Accept Request</button>" +
					$"<button class='btn btn-outline-danger request-{requestId} {cssClasses}' onclick=\"window.ZokuChat.CancelRequestButtonClick($(this), '{requestId}');\">Decline Request</button>"
				);
			}
			else if (contactRequestService.HasActiveContactRequest(context.CurrentUser, user))
			{
				return new HtmlString($"<button class='btn btn-outline-success {cssClasses}' disabled>Request Sent</button>");
			}
			else
			{
				return new HtmlString($"<button class='btn btn-outline-primary {cssClasses}' onclick=\"window.ZokuChat.SendRequestButtonClick($(this), '{user.Id}');\">Send Request</button>");
			}
		}

		public static HtmlString GetContactRemoveButton(Contact contact, string cssClasses = "")
		{
			return new HtmlString($"<button class='btn btn-outline-danger {cssClasses}' onclick=\"window.ZokuChat.RemoveContactButtonClick($(this), '{contact.Id}')\">Remove Contact</button>");
		}

		public static HtmlString GetBlockUserButton(User user, string cssClasses = "")
		{
			return new HtmlString($"<button class='btn btn-outline-danger {cssClasses}' onclick=\"window.ZokuChat.BlockUserButtonClick($(this), '{user.Id}');\">Block User</button>");
		}

		public static HtmlString GetUnblockUserButton(User user, string cssClasses = "")
		{
			return new HtmlString($"<button class='btn btn-outline-primary {cssClasses}' onclick=\"window.ZokuChat.UnblockUserButtonClick($(this), '{user.Id}');\">Unblock User</button>");
		}
	}
}
