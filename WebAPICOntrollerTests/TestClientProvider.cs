﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using WebAPI_Test;

namespace WebAPIControllerTests
{
    public class TestClientProvider : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get ; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient(); 
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
