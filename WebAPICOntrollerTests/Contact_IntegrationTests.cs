using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Test.Models;
using Xunit;

namespace WebAPIControllerTests
{
    public class Contact_IntegrationTests
    {
        #region MorseCode
        ////public class ContactXunitTesting
        ////{
        //    private readonly IContactRepository _contactRepo;
        //    private readonly ContactController _controller;
        //    //static Contact_IntegrationTests()
        //    //{
        //    //    dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
        //    //        .Options;
        //    //}
        //    public Contact_IntegrationTests(IContactRepository contactRepo, ContactController controller)
        //    {
        //        _controller = controller;

        //public Contact_IntegrationTests(IContactRepository contactRepository, ContactController controller)
        //    var context = new ApplicationDbContext(dbContextOptions);
        //    _contactRepository = contactRepository;
        //    _controller = controller;
        //}
        //public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; }
        //public static string connectionString = "Data Source=DESKTOP-SE277G7\\RAJEEVSQLSERVER;Initial Catalog=Employees;Persist Security Info=True;User ID=sa;Password=Rajeevp727;";
        #endregion
        #region Get_ALL
        [Fact]
        public async Task Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/contact");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        #endregion

        #region Get_By_Id
        [Fact]
        public async Task Get_By_Id()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/contact?id=3002");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        #endregion

        #region Post
        [Fact]
        public async Task Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/contact", new StringContent(JsonConvert.SerializeObject(new Contact
                {
                    EmployeeId = 10,
                    MobileCountryCode = 91,
                    Mobile = 7032075893,
                    AlternateMobileCountryCode = 91,
                    AlternateMobile = 8019129831,
                    WorkNumberCountryCode = 91,
                    WorkNumber = 0,
                    WorkExtension = 0,
                    HomeCountryCode = 91,
                    HomeNumber = 7032075893,
                    HomeExtension = 91,
                    CompanyMobileCountryCode = 91,
                    CompanyMobile = 0,
                    Active = true,
                    CreatedBy = 741,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 741,
                    ModifiedDate = DateTime.Now
                }), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.Created);
            }
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("/api/Contact/2005");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }
        #endregion


        #region Update_Data_Validation
        [Fact]
        public async Task Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                Contact contact;
                var response = await client.PutAsync("/api/contact?id=3002", new StringContent(JsonConvert.SerializeObject(contact = new Contact
                {
                    Id = 3002,
                    EmployeeId = 4,
                    MobileCountryCode = 91,
                    Mobile = 7032075893,
                    AlternateMobileCountryCode = 91,
                    AlternateMobile = 8019129831,
                    WorkNumberCountryCode = 91,
                    WorkNumber = 7032075893,
                    WorkExtension = 91,
                    HomeCountryCode = 91,
                    HomeNumber = 7032075893,
                    HomeExtension = 91,
                    CompanyMobileCountryCode = 91,
                    CompanyMobile = 91,
                    Active = true,
                    CreatedBy = 741,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 741,
                    ModifiedDate = DateTime.Now
                }), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Get Method

                //DataContractJsonSerializer deSerializer = new DataContractJsonSerializer(typeof(Contact));
                //Contact resp = (Contact)deSerializer.ReadObject(response);
                //HttpResponseMessage response1 = await client.GetAsync(URL);
                HttpResponseMessage responseget = await client.GetAsync("/api/Contact/1");
                var Getcontact = await responseget.Content.ReadAsStringAsync();
                //List<Contact> getList = JsonConvert.DeserializeObject<List<Contact>>(Getcontact);

                //var getList = JsonConvert.DeserializeObject<List<Contact>>(Getcontact);
                //var Getcontact = await responseget.Content.ReadAsAsync<Contact>();
                //var getList = JsonConvert.DeserializeObject(Getcontact.ToString());

                List<Contact> getList = new List<Contact>();
                getList = JsonConvert.DeserializeObject<List<Contact>>(Getcontact);

                //var getList = JsonConvert.DeserializeObject<List<Contact>>(Getcontact,
                //       new JsonSerializerSettings
                //       {
                //           NullValueHandling = NullValueHandling.Ignore
                //       });


                //foreach (var item in getList)
                //{
                //    if (item != null)
                //    {
                //        Assert.Equal(item.EmployeeId, contact.EmployeeId);
                //        Assert.Equal(item.MobileCountryCode, contact.MobileCountryCode);
                //        Assert.Equal(item.Mobile, contact.Mobile);
                //        Assert.Equal(item.AlternateMobileCountryCode, contact.AlternateMobileCountryCode);
                //        Assert.Equal(item.AlternateMobile, contact.AlternateMobile);
                //        Assert.Equal(item.WorkNumberCountryCode, contact.WorkNumberCountryCode);
                //        Assert.Equal(item.WorkNumber, contact.WorkNumber);
                //        Assert.Equal(item.WorkExtension, contact.WorkExtension);
                //        Assert.Equal(item.HomeCountryCode, contact.HomeCountryCode);
                //        Assert.Equal(item.HomeNumber, contact.HomeNumber);
                //        Assert.Equal(item.HomeExtension, contact.HomeExtension);
                //        Assert.Equal(item.CompanyMobileCountryCode, contact.CompanyMobileCountryCode);
                //        Assert.Equal(item.CompanyMobile, contact.CompanyMobile);
                //        Assert.Equal(item.Active, contact.Active);
                //        Assert.Equal(item.CreatedBy, contact.CreatedBy);
                //        Assert.Equal(item.CreatedDate, contact.CreatedDate);
                //        Assert.Equal(item.CreatedDate, contact.CreatedDate);
                //        Assert.Equal(item.CreatedBy, contact.CreatedBy);
                //        Assert.Equal(item.ModifiedDate, contact.ModifiedDate);
                //        response.EnsureSuccessStatusCode();
                //        response.StatusCode.Should().Be(HttpStatusCode.OK);
                //    }
                //}
            }
        }
        #endregion


        #region Try
        //        //[Fact]
        //        //public void Add_InvalidObjectPassed_ReturnsBadRequest()
        //        //{
        //        //    // Arrange
        //        //    var nameMissingItem = new ShoppingItem()
        //        //    {
        //        //        Manufacturer = "Guinness",
        //        //        Price = 12.00M
        //        //    };
        //        //    _controller.ModelState.AddModelError("Name", "Required");
        //        //    // Act
        //        //    var badResponse = _controller.Post(nameMissingItem);
        //        //    // Assert
        //        //    Assert.IsType<BadRequestObjectResult>(badResponse);
        //        //}

        //        //    [Fact]
        //        ////[5:21 PM] Nenavath Loka Ranjan
        //        //public async void InvalidBytePassed_ReturnsBadRequest()
        //        //{
        //        //    var controller = new ContactController();
        //        //    var missingItem = new Contact()
        //        //    {
        //        //        Mobile = 1703207589312344,
        //        //    };
        //        //    controller.ModelState.AddModelError("Moible", "Required");
        //        //    var badResponse = await controller.contact(missingItem);
        //        //    Assert.IsType<BadRequestResult>(badResponse);
        //        //    //Assert.
        //        //}


        //        //[Fact]
        //        //public void PostTestSuccessful()
        //        //{
        //        //    var controller = new ContactController();

        //        //    //var repo = new ContactRepository();

        //        //    //Guid guid = Guid.NewGuid();

        //        //    Contact cont = new Contact()
        //        //    {
        //        //        Mobile = 7032075893012345,
        //        //    };

        //        //    var actionResult = controller.contact(cont);

        //        //    Assert.NotNull(actionResult);
        //        //    Assert.IsType<BadRequestResult>(actionResult);
        //        //    Assert.True(actionResult.IsCompletedSuccessfully);
        //        //}

        //    }
        //}
        #endregion

        #region Test_Contact_MobileCountryCode_Fail_Case
        [Fact]
        public Task Test_Contact_MobileCountryCode_Fail_Case()
        {
            var cont = new Contact
            {
                Id = 4,
                EmployeeId = 2,
                //MobileCountryCode = 91,
                Mobile = 7032075893,
                AlternateMobileCountryCode = +91,
                AlternateMobile = 8019129831,
                WorkNumberCountryCode = +91,
                WorkNumber = 7032075893,
                WorkExtension = +91,
                HomeCountryCode = +91,
                HomeNumber = 7032075893,
                HomeExtension = +91,
                CompanyMobileCountryCode = +91,
                CompanyMobile = 7032075893,
                Active = true,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(cont);
            Validator.TryValidateObject(cont, validationContext, result);
                Assert.Null(result[0]);
            return Task.CompletedTask;
        }
        #endregion
    }
        }