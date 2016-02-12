using System;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace CShirtsNet.Models
{
	public class Bootstrapper : Nancy.DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);
			container.Register<CreationTimeService>().AsSingleton();
		}
	}
}

