﻿using System;
using System.Web;
using FubuMVC.Core;
using FubuMVC.StructureMap;

namespace $safeprojectname$ {
	public class Global : HttpApplication {
		protected void Application_Start(object sender, EventArgs e) {
			FubuApplication.BootstrapApplication<MyApplication>();
		}

		protected void Session_Start(object sender, EventArgs e) {

		}

		protected void Application_BeginRequest(object sender, EventArgs e) {

		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e) {

		}

		protected void Application_Error(object sender, EventArgs e) {

		}

		protected void Session_End(object sender, EventArgs e) {

		}

		protected void Application_End(object sender, EventArgs e) {

		}
	}
}