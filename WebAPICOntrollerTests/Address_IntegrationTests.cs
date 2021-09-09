using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Test.Models;
using Xunit;

namespace WebAPIControllerTests
{
    public class Address_IntegrationTests
    {
        [Fact]
        public async Task Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/address");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Get_ById()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/address?id=1");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/address", new StringContent(JsonConvert.SerializeObject(new Address()
                {
                    //id = 1,
                    EmployeeId = 1,
                    Type = true,
                    Line1 = "Dallas Center, Near IKEA Store",
                    Line2 = "RAIDURG",
                    City = "HYDERABAD",
                    State = "Telangana",
                    Country = "India",
                    zipCode = "50010",
                    Active = true,
                    CreatedBy = 741,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 741,
                    ModifiedDate = DateTime.Now
                }),
                Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("api/Address/1006");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }

        [Fact]
        public async Task Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PutAsync("/api/address?id=1004", new StringContent(JsonConvert.SerializeObject(new Address
                {
                    id = 1004,
                    EmployeeId = 2,
                    Type = true,
                    Line1 = "Dallas Center, Near IKEA Store",
                    Line2 = "RAIDURG",
                    City = "HYDERABAD",
                    State = "Telangana",
                    Country = "India",
                    zipCode = "50010",
                    Active = true,
                    CreatedBy = 741,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 741,
                    ModifiedDate = DateTime.Now
                }), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }

        #region Address_Line1_FailCase
        [Fact]
        public Task Address_Line1_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                //Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_Line2_FailCase
        [Fact]
        public Task Address_Line2_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                //Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_City_FailCase
        [Fact]
        public Task Address_City_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                //City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion


        #region Address_State_FailCase
        [Fact]
        public Task Address_State_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                //State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_Country_FailCase
        [Fact]
        public Task Address_Country_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                //Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion


        #region Address_zipCode_FailCase
        [Fact]
        public Task Address_zipCode_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                //zipCode = "500100",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_Active_FailCase
        [Fact]
        public Task Address_Active_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                //Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_CreatedBy_FailCase
        [Fact]
        public Task Address_CreatedBy_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                //CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion


        #region Address_CreatedDate_FailCase
        [Fact]
        public Task Address_CreatedDate_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                //CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_ModifiedBy_FailCase
        [Fact]
        public Task Address_ModifiedBy_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                //ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Address_ModifiedDate_FailCase
        [Fact]
        public Task Address_ModifiedDate_FailCase()
        {
            var address = new Address
            {
                EmployeeId = 2,
                Type = true,
                //Line1 = "Dallas Center, Near IKEA Store",
                Line2 = "RAIDURG",
                City = "HYDERABAD",
                State = "Telangana",
                Country = "India",
                zipCode = "50010",
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address);
            Validator.TryValidateObject(address, validationContext, result);
            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

    }
}
