using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Test.Models
{
    public class Employee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter EmployeeID")]
        [Display(Name = "Emp Id", Prompt = "Enter EmployeeID", Description = "Please Enter EmployeeID")]
        [Column(TypeName = "bigint")]
        public Int64 EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter your FirstName")]
        [Display(Name = "First Name", Prompt = "Enter your First Name", Description = "Please Enter your First Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name should be minimum  3 characters and a maximum of 20 characters")]
        public string firstName { get; set; }

        //[Required(ErrorMessage = "Please enter your middleName")]
        //[Display(Name = "Middle Name", Prompt = "Enter Middle Name", Description = "Please Enter Middle Name")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "MiddleName should be minimum 3 characters and a maximum of 20 characters")]
        public string middleName { get; set; } 

        [Required(ErrorMessage = "please enter LastName")]
        [Display(Name = "Last Name", Prompt = "Enter Last Name", Description = "Please Enter Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "LastName   should be minimum 3 characters and a maximum of 20 characters")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Please Enter your CertificateDOB")]
        [Display(Name = "CertificateDOB", Prompt = "Enter CertificateDOB", Description = "Please Enter your CertificateDOB")]
        [Range(typeof(DateTime), "1/1/1947","1/1/2010")]
        public DateTime? CertificateDOB { get; set; }

        [Required(ErrorMessage = "please enter ActualBOD")]
        [Display(Name = "ActualBOD", Prompt = "Enter ActualBOD", Description = "Please EnterActualBOD")]
        [Range(typeof(DateTime), "1/1/1947", "1/1/2010")]
        public DateTime? ActualDOB { get; set; }

        [Required(ErrorMessage = "please enter DOJ")]
        [Display(Name = " DOJ", Prompt = "Enter  DOJ", Description = "Please Enter  DOJ")]
        [Range(typeof(DateTime), "1/1/1947", "1/1/2022")]
        public DateTime DOJ { get; set; }

        [Required(ErrorMessage = "Please enter Gender")]
        [Display(Name = "Gender", Prompt = "Enter Gender", Description = "Please EnterGender")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Please enter ReportingManagerId")]
        [Display(Name = "ReportingManagerID", Prompt = "Enter ReportingManagerId", Description = "Please Enter ReportingManagerId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "ReportingManagerId should be minimum 5 characters and a maximum of 50 characters")]
        public string ReportingManagerId { get; set; }

        [Required(ErrorMessage = "Please enter OfficeLocation")]
        [Display(Name = "OfficeLocation", Prompt = "Enter OfficeLocation", Description = "Please Enter OfficeLocation")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "OfficeLocation should be minimum 5 characters and a maximum of 50 characters")]
        public string OfficeLocation { get; set; }

        [Required(ErrorMessage = "Please check if Active Employee")]
        [Display(Name = "Active", Prompt = "Is Active", Description = "Please check if Active Employee")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Please enter your Company EmailId")]
        [Display(Name = "CompanyEmailId", Prompt = "Enter Company EmailId", Description = "Please Enter Company EmailId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Company EmailId should be minimum 5 characters and a maximum of 50 characters")]
        [EmailAddress]
        public string CompanyEmailId { get; set; }

        [Required(ErrorMessage = "please enter Personal EmailId")]
        [Display(Name = "PersonalEmailId", Prompt = "Enter Personal EmailId", Description = "Please Enter Personal EmailId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Personal EmailId should be minimum 5 characters and a maximum of 50 characters")]
        [EmailAddress]
        public string PersonalEmailId { get; set; }

        //[Required(ErrorMessage = "please enter SeperatedDate")]
        [Display(Name = "SeperatedDate", Prompt = "Enter SeperatedDate", Description = "Please Enter SeperatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime SeperatedDate { get; set; }

        [Required(ErrorMessage = "MaritalStatus cannot be NULL")]
        [Display(Name = "MaritalStatus", Prompt = "Enter your MaritalStatus", Description = "Please Enter your MaritalStatus")]
        public bool MaritalStatus { get; set; }

        [Required(ErrorMessage = "CreatedBy cannot be NULL")]
        [Display(Name = "CreatedBy", Prompt = "Enter CreatedBy", Description = "Please Enter CreatedBy")]
        public Int64 CreatedBy { get; set; }

        [Required(ErrorMessage = "Please enter CreatedDate")]
        [Display(Name = "CreatedDate", Prompt = "Enter CreatedDate", Description = "Please Enter CreatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "ModifiedBy", Prompt = "Enter ModifiedBy", Description = "Please Enter ModifiedBy")]
        public Int64 ModifiedBy { get; set; }

        [Display(Name = "ModifiedDate", Prompt = "Enter ModifiedDate", Description = "Please Enter ModifiedDate")]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
    }
}
