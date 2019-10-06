//using System;
//using Microsoft.Azure.Functions.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//using AwesumIO.Core.Business.Integrations;

//[assembly: FunctionsStartup(typeof(AwesumIO.Functions.Startup))]
//namespace AwesumIO.Functions
//{
//    public class Startup : FunctionsStartup
//    {
//        public override void Configure(IFunctionsHostBuilder builder)
//        {
//            builder.Services.AddHttpClient();

//            builder.Services.AddSingleton<ITwitterService>(s =>
//            {
//                return new TwitterClient();
//            });

//           // builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
//        }
//    }
//}
