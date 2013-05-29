namespace $safeprojectname$.Endpoints.Home {
	public class HomeEndpoint	 {
		public IndexModel Index(IndexInput input) {
			return new IndexModel {
				Message = "Welcome to FUBUMVC!"
			};
		}
	}

	public class IndexInput {
	}

	public class IndexModel {
		public string Message { get; set; }
	}

}