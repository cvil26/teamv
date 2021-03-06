﻿using System;
using Microsoft.Owin.Hosting;
using MobilePoll.Infrastructure.Persistence.Mongo;
using MobilePoll.Infrastructure.Wireup;
using MobilePoll.Web.Api.Wireup;

namespace MobilePoll.Web.Api
{
    class Program
    {
        const string BaseAddress = "http://localhost:9000/";

        static void Main(string[] args)
        {
            MongoUnitOfWork.DropDatabaseOnStartup = false;
            Startup.DefaultConfiguration = new MongoConfiguration();

            Console.WriteLine("Configuring OWIN Self Host to run on {0}", BaseAddress);
            Console.WriteLine("Starting OWIN Server with {0} configuration...", Startup.DefaultConfiguration.GetType().Name);

            Console.WriteLine();

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                Console.WriteLine("\nServer Started. To test the connection go to {0}api/Test", BaseAddress);

                Console.WriteLine("\nAvailable API Calls:");
                Console.WriteLine("GET {0}api/PollResult", BaseAddress);
                Console.WriteLine("GET {0}api/PollResult/{{id}}", BaseAddress);
                Console.WriteLine("POST {0}api/PollResult", BaseAddress);
                Console.WriteLine();
                Console.WriteLine("GET {0}api/PollResult", BaseAddress);
                Console.WriteLine("GET {0}api/PollResult/{{id}}", BaseAddress);
                Console.WriteLine("POST {0}api/PollResult", BaseAddress);
                Console.WriteLine();
                Console.WriteLine("GET {0}api/Report", BaseAddress);

                Console.WriteLine("\nPress the X key to stop the server.");

                do
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey();

                    if (keyPress.KeyChar == 'x' || keyPress.KeyChar == 'X')
                    {
                        break;
                    }
                } while (true);
            }
        }
    }
}
