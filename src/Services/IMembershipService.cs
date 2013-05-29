namespace $safeprojectname$.Services {
	public interface IMembershipService {
		bool CreateUser(string userName, string password, string email);
		bool UserExists(string userName, string password);
	}
}