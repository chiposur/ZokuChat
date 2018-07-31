﻿namespace ZokuChat.Helpers
{
    public class UrlHelper
    {
		private const string _CONTACTS_URL = "/Contacts/List";
		private const string _LOGIN_URL = "/Identity/Account/Login";
		private const string _REGISTER_URL = "/Identity/Account/Register";
		private const string _HOME_URL = "/";
		private const string _ABOUT_URL = "/About";
		private const string _ERROR_URL = "/Error";

		public static string GetContactsListUrl()
		{
			return _CONTACTS_URL;
		}

		public static string GetAboutUrl()
		{
			return _ABOUT_URL;
		}

		public static string GetErrorUrl()
		{
			return _ERROR_URL;
		}

		public static string GetHomeUrl()
		{
			return _HOME_URL;
		}

		public static string GetLoginUrl()
		{
			return _LOGIN_URL;
		}

		public static string GetRegisterUrl()
		{
			return _REGISTER_URL;
		}
    }
}
