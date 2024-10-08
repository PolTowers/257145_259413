﻿using Domain;

namespace Interface.DataAccess
{
	public class SessionManager
	{
		private Client? _logged { get; set; }

		public Client CurrentUser
		{
			get { return _logged; }
			set { _logged = value; }
		}

		public void ClearCurrentUser()
		{
			_logged = null;
		}

		public bool UserIsLogged()
		{
			return _logged != null;
		}
	}
}
