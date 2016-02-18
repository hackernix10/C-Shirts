using System;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using MyCouch;

namespace CShirtsNet.Models
{
	public class Bootstrapper : Nancy.DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);

			// register services etc
			container.Register<CreationTimeService>().AsSingleton();


			// with autofac
			container.Register<CouchDbTshirtRepository>().As<ITShirtRepository>();
			container.Register(s => new MyCouchStore("url","db"));
		}
	}
}

