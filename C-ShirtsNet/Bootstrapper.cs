using System;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using MyCouch;
using Autofac;
using CShirts.Persistence.Models;

namespace CShirtsNet.Models
{
	public class Bootstrapper : Nancy.DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(IContainer container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);

			// register services etc
			container.Register<CreationTimeService>().AsSingleton();

			// with autofac
			container.Register<CouchDbTShirtRepository>().As<ITShirtRepository>();
			container.Register(s => new MyCouchStore("http://127.0.0.1:5984","cshirts"));
		}
	}
}

