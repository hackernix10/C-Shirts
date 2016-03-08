using System;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using MyCouch;
using Autofac;
using CShirts.Persistence.Models;
//using CShirts.Web.Views.Admin.Models;
using Nancy.Bootstrappers.Autofac;
using Nancy;

namespace CShirts.Web
{
	public class Bootstrapper : AutofacNancyBootstrapper
	{
		protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);

			// register interfaces/implementations
			container.Update(builder => builder
				//.RegisterType<CouchDbTShirtRepository>()
				.RegisterType<MockedTShirtRepository>()
				.As<ITShirtRepository>());

			// register MyCouchStore parameter for couchdb repo classes
			container.Update(builder => builder
				.RegisterType<MyCouchStore>()
				.As<IMyCouchStore>()
				.UsingConstructor(typeof (string), typeof (string))
				.WithParameters(new [] {
					new NamedParameter("dbUri","http://seraya_dba:Pa$$w0rd@localhost:5984/"),
					new NamedParameter("dbName","cshirts")
				})
			);
				
			// TODO: remove after implementing REST-Api & replacing razor with angular
			// display razor error messages
			StaticConfiguration.DisableErrorTraces = false;
		}
	}
}