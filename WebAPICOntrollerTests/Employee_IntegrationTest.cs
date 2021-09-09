using System;
using WebAPI_Test.Controllers;
using WebAPI_Test.Repositories;
using System.Threading.Tasks;
using Xunit;
using WebAPI_Test.Models;
using System.Net;
using FluentAssertions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace WebAPIControllerTests
{
        // Using xUnit and TestServer

    public class Employee_IntegrationTest
    {
        #region Get_All
        [Fact]
        public async Task Test_Get_AllAsync()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/employees");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        #endregion

        #region getByID
        [Fact]
        public async Task test_GetByIdAsync()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("/api/employees?id=1");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        #endregion

        #region Test_Post
        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("/api/employees", new StringContent(JsonConvert.SerializeObject(new Employee()
                { 
                            EmployeeId = 20,
                            firstName = "RAJEEV",
                            middleName = "Patlolla",
                            lastName = "REDDY",
                            CertificateDOB = DateTime.Parse("2021-08-25T11:27:28.95"),
                            ActualDOB = DateTime.Parse("2021-08-25T11:27:28.95"),
                            DOJ = DateTime.Parse("2021-08-25T11:27:28.95"),
                            Gender = true,
                            ReportingManagerId = "SANDEEP@MOT", 
                            OfficeLocation = "DALLAS CENTER,RAIDURG",
                            Active = true,
                            CompanyEmailId = "RAJEEV.REDDY@OTIVITYLABS.COM",
                            PersonalEmailId = "MRRAJEEVP727@GMAIL.COM",
                            SeperatedDate = DateTime.Parse("2021-08-25T11:27:28.95"),
                            MaritalStatus = false,
                            CreatedBy = 741,
                            CreatedDate = DateTime.Now,
                            ModifiedBy = 741,
                            ModifiedDate = DateTime.Now
                        }), Encoding.UTF8, "application/json")) ;
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.Created);
            }
        }
        #endregion

        #region Test_Delete
        [Fact]
        public async Task Test_Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("/api/Employees/2019");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
        #endregion

        #region Test_Put
        [Fact]
        public async Task Test_Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PutAsync("/api/employees?id=1", new StringContent(JsonConvert.SerializeObject(new Employee
                {
                    id = 1,
                    EmployeeId = 3,
                    firstName = "RAJEEV",
                    middleName = "Patolla",
                    lastName = "REDDY",
                    CertificateDOB = DateTime.Parse("2021-08-25T00:00:00"),
                    ActualDOB = DateTime.Parse("2021-08-25T00:00:00"),
                    DOJ = DateTime.Parse("2021-08-25T11:27:28.95"),
                    Gender = true,
                    ReportingManagerId = "SANDEEP@MOTIVITYLABS.COM",
                    OfficeLocation = "DALLAS CENTER, RAIDURG, Hyderabad",
                    Active = true,
                    CompanyEmailId = "RAJEEV.REDDY@OTIVITYLABS.COM",
                    PersonalEmailId = "MRRAJEEVP727@GMAIL.COM",
                    SeperatedDate = DateTime.Parse("2021-08-25T11:27:28.95"),
                    MaritalStatus = false,
                    CreatedBy = 741,
                    CreatedDate = DateTime.Now,
                    ModifiedBy = 741,
                    ModifiedDate = DateTime.Now
                }), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.NoContent);
            }
        }
        #endregion

        #region Test_Employee_FirstName_Fail_Case
        [Fact]
        public Task Test_Employee_FirstName_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                //firstName = "Rjeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_MiddleName_Fail_Case
        [Fact]
        public Task Test_Employee_MiddleName_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rjeev",
                //middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_LastName_Fail_Case
        [Fact]
        public Task Test_Employee_LastName_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                //lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_CertificateDOB_Fail_Case
        [Fact]
        public Task Test_Employee_CertificateDOB_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                //CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ActualDOB_Fail_Case
        [Fact]
        public Task Test_Employee_ActualDOB_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                //ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_DOJ_Fail_Case
        [Fact]
        public Task Test_Employee_DOJ_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                //DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_Gender_Fail_Case
        [Fact]
        public Task Test_Employee_Gender_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                //Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ReportingManagerId_Fail_Case
        [Fact]
        public Task Test_Employee_ReportingManagerId_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                //ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_OfficeLocation_Fail_Case
        [Fact]
        public Task Test_Employee_OfficeLocation_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                //OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_IsActive_Fail_Case
        [Fact]
        public Task Test_Employee_IsActive_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                //Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_CompanyEmailId_Fail_Case
        [Fact]
        public Task Test_Employee_CompanyEmailId_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                //CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_PersonalEmailId_Fail_Case
        [Fact]
        public Task Test_Employee_PersonalEmailId_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                //PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_SeperatedDate_Fail_Case
        [Fact]
        public Task Test_Employee_SeperatedDate_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                //SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_MaritalStatus_Fail_Case
        [Fact]
        public Task Test_Employee_MaritalStatus_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                //MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_CreatedBy_Fail_Case
        [Fact]
        public Task Test_Employee_CreatedBy_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                //CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_CreatedDate_Fail_Case
        [Fact]
        public Task Test_Employee_CreatedDate_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                //CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ModifiedBy_Fail_Case
        [Fact]
        public Task Test_Employee_ModifiedBy_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                //ModifiedBy = 741,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ModifiedDate_Fail_Case
        [Fact]
        public Task Test_Employee_ModifiedDate_Fail_Case()
        {
            var emp = new Employee
            {
                EmployeeId = 1,
                firstName = "Rajeev",
                middleName = "",
                lastName = "Reddy",
                CertificateDOB = DateTime.Parse("2021-08-25"),
                ActualDOB = DateTime.Parse("2021-08-25"),
                DOJ = DateTime.Parse("2021-08-25"),
                Gender = true,
                ReportingManagerId = "sandeep@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "Rajeev.Reddy@motivitylabs.com",
                PersonalEmailId = "mrrajeevp727@gmail.com",
                SeperatedDate = DateTime.Parse("2021-06-30"),
                MaritalStatus = false,
                CreatedBy = 741,
                CreatedDate = DateTime.Now,
                ModifiedBy = 741,
                //ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            Assert.NotNull(result[0]);
            return Task.CompletedTask;
        }
        #endregion
    }
}
