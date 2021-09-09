using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Test.Models
{
    public class Contact
    { 
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter EmployeeID")]
        //[Display(Name = "Emp Id", Prompt = "Enter EmployeeID", Description = "Please Enter EmployeeID")]
        //[Column(TypeName = "bigint")]
        public Int64 EmployeeId { get; set; }

        //[Required(ErrorMessage = "Please enter your MobileCountryCode")]
        //[Display(Name = "MobileCountryCode", Prompt = "Enter your MobileCountryCode", Description = "Please Enter your MobileCountryCode")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte MobileCountryCode { get; set; }

        //[Required(ErrorMessage = "Please enter your Mobile Number")]
        //[Display(Name = "Mobile Number", Prompt = "Enter your Mobile Number", Description = "Please Enter your Mobile Number")]
        //[MinLength(10)]
        //[MaxLength(10)]
        public Int64 Mobile { get; set; }

        //[Required(ErrorMessage = "Please enter your AlternateMobileCountryCode")]
        //[Display(Name = "AlternateMobileCountryCode", Prompt = "Enter your AlternateMobileCountryCode", Description = "Please Enter your AlternateMobileCountryCode")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte AlternateMobileCountryCode { get; set; }

        //[Required(ErrorMessage = "Please enter your AlternateMobile")]
        //[Display(Name = "AlternateMobile", Prompt = "Enter your AlternateMobile", Description = "Please Enter your AlternateMobile")]
        //[MinLength(10)]
        //[MaxLength(10)]
        public Int64 AlternateMobile { get; set; }

        //[Required(ErrorMessage = "Please enter your WorkNumberCountryCode")]
        //[Display(Name = "WorkNumberCountryCode", Prompt = "Enter your WorkNumberCountryCode", Description = "Please Enter your WorkNumberCountryCode")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte WorkNumberCountryCode { get; set; }

        //[Required(ErrorMessage = "Please enter your WorkNumber")]
        //[Display(Name = "WorkNumber", Prompt = "Enter your WorkNumber", Description = "Please Enter your WorkNumber")]
        //[MinLength(10)]
        //[MaxLength(10)]
        public Int64 WorkNumber { get; set; }

        //[Required(ErrorMessage = "Please enter your WorkExtension")]
        //[Display(Name = "WorkExtension", Prompt = "Enter your WorkExtension", Description = "Please Enter your WorkExtension")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte WorkExtension { get; set; }

        //[Required(ErrorMessage = "Please enter your HomeCountryCode")]
        //[Display(Name = "HomeCountryCode", Prompt = "Enter your HomeCountryCode", Description = "Please Enter your HomeCountryCode")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte HomeCountryCode { get; set; }

        //[Required(ErrorMessage = "Please enter your HomeNumber")]
        //[Display(Name = "HomeNumber", Prompt = "Enter your HomeNumber", Description = "Please Enter your HomeNumber")]
        //[MinLength(10)]
        //[MaxLength(10)]
        public Int64 HomeNumber { get; set; }

        //[Required(ErrorMessage = "Please enter your HomeExtension")]
        //[Display(Name = "HomeExtension", Prompt = "Enter your HomeExtension", Description = "Please Enter your HomeExtension")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte HomeExtension { get; set; }

        //[Required(ErrorMessage = "Please enter your CompanyMobileCountryCode")]
        //[Display(Name = "CompanyMobileCountryCode", Prompt = "Enter your CompanyMobileCountryCode", Description = "Please Enter your CompanyMobileCountryCode")]
        //[MinLength(2)]
        //[MaxLength(3)]
        public byte CompanyMobileCountryCode { get; set; }

        //[Required(ErrorMessage = "Please enter your CompanyMobile")]
        //[Display(Name = "CompanyMobile", Prompt = "Enter your CompanyMobile", Description = "Please Enter your CompanyMobile")]
        //[MinLength(10)]
        //[MaxLength(10)]
        public Int64 CompanyMobile { get; set; }

        //[Required(ErrorMessage = "Is Active")]
        //[Display(Name = "Is Active", Prompt = "Is Active?", Description = "Is Active?")]
        public bool Active { get; set; }

        //[Required(ErrorMessage = "CreatedBy")]
        //[Display(Name = "CreatedBy", Prompt = "CreatedBy?", Description = "CreatedBy?")]
        //[MinLength(5)]
        //[MaxLength(5)]
        public Int64 CreatedBy { get; set; }

        //[Required(ErrorMessage = "Please enter your CreatedDate")]
        //[Display(Name = "CreatedDate", Prompt = "Enter your CreatedDate", Description = "Please Enter your CreatedDate")]
        //[Range(typeof(DateTime), "1/1/1947", "1/1/2030")]
        public DateTime CreatedDate { get; set; }

        //[Required(ErrorMessage = "ModifiedBy")]
        //[Display(Name = "ModifiedBy", Prompt = "ModifiedBy", Description = "ModifiedBy")]
        //[MinLength(5)]
        //[MaxLength(5)]
        public Int64 ModifiedBy { get; set; }

        //[Required(ErrorMessage = "ModifiedDate")]
        //[Display(Name = "ModifiedDate", Prompt = "ModifiedDate", Description = "ModifiedDate")]
        //[DataType(DataType.DateTime)]
        //[Range(typeof(DateTime), "1/1/1947", "1/1/2030")]
        public DateTime ModifiedDate { get; set; }

    }
}
