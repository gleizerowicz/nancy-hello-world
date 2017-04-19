using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nancy;
using Nancy.TinyIoc;
using NancyHelloWorld.BusinessLogic.Services;
using NancyHelloWorld.BusinessLogic.Services.Interfaces;
using System;


namespace NancyHelloWorld
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private readonly IAppSettings appSettings;
        private readonly IServiceProvider serviceProvider;
        public Bootstrapper()
        {
        }

        public Bootstrapper(IAppSettings appSet, IServiceProvider serviceProv)
        {
            appSettings = appSet;
            serviceProvider = serviceProv;
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register(appSettings);
            container.Register(serviceProvider.GetService<ILoggerFactory>());

            container.Register<IVersionService, VersionService>();
        }

        
    }
}
