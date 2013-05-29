using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$.Services {
	public class InMemoryMembershipService : IMembershipService {
		private static readonly IList<User> _users = new List<User>();

		public bool CreateUser(string userName, string password, string email) {
			_users.Add(new User { UserName = userName, Password = password, Email = email });
			return true;
		}

		public bool UserExists(string userName, string password) {
			return _users.Any(x => x.UserName.ToLowerInvariant() == userName.ToLowerInvariant() && x.Password == password);
		}
	}
}