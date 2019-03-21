using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Icatu.EmployeeManagerAPI.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Xunit;

namespace Icatu.EmployeeManagerAPI.Tests
{
    public class IntegrationTests
    {
        public HttpClient Client { get; private set; }

        public IntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }

        [Fact]
        public void Test_Get_All()
        {

            using (var client = new IntegrationTests().Client)
            {
                var response = client.GetAsync("api/v1/employee").Result;

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void Test_Post()
        {
            using (var client = new IntegrationTests().Client)
            {
                var response = client.PostAsync("/api/v1/employee"
                        , new StringContent(
                        JsonConvert.SerializeObject(new NewEmployeeRequest()
                        {
                            Name = "Test",
                            Email = "test@email.com",
                            Department = "DP"
                        }),
                    Encoding.UTF8,
                    "application/json")).Result;

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public void Test_Post_BadRequest()
        {
            using (var client = new IntegrationTests().Client)
            {
                var response = client.PostAsync("/api/v1/employee"
                        , new StringContent(
                        JsonConvert.SerializeObject(new NewEmployeeRequest()
                        {
                            Name = "",
                            Email = "test@email.com",
                            Department = "DP"
                        }),
                    Encoding.UTF8,
                    "application/json")).Result;

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

    }
}
