using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Test.Models
{
    public class Address
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter EmployeeID")]
        [Display(Name = "Emp Id", Prompt = "Enter EmployeeID", Description = "Please Enter EmployeeID")]
        [Column(TypeName = "bigint")]
        public Int64 EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter Type")]
        [Display(Name = "Type", Prompt = "Enter Type", Description = "Please Enter Type")]
        public bool Type { get; set; }

        [Required(ErrorMessage = "Please enter Line1")]
        [Display(Name = "Line1", Prompt = "Enter Line1", Description = "Please Enter Line1")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Line1 should be minimum 10 characters and a maximum of 50 characters")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Please enter Line2")]
        [Display(Name = "Line2", Prompt = "Enter Line2", Description = "Please Enter Line2")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Line2 should be minimum 10 characters and a maximum of 50 characters")]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Please enter City")]
        [Display(Name = "City", Prompt = "Enter City", Description = "Please Enter City")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "City should be minimum 5 characters and a maximum of 20 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter State")]
        [Display(Name = "State", Prompt = "Enter State", Description = "Please Enter State")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "State should be minimum 5 characters and a maximum of 20 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter Country")]
        [Display(Name = "Country", Prompt = "Enter Country", Description = "Please Enter Country")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Country should be minimum 5 characters and a maximum of 50 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter ZipCode")]
        [Display(Name = "ZipCode", Prompt = "Enter ZipCode", Description = "Please Enter ZipCode")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "ZipCode should be minimum 5 characters and a maximum of 10 characters")]
        public string zipCode { get; set; }

        [Required(ErrorMessage = "Please enter if Active")]
        [Display(Name = "Active", Prompt = "Enter if Active", Description = "Please Enter if Active")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "CreatedBy cannot be blank")]
        [Display(Name = "CreatedBy", Prompt = "CreatedBy", Description = "CreatedBy cannot eb blank")]
        [Column(TypeName = "bigint")]
        public Int64 CreatedBy { get; set; }

        [Required(ErrorMessage = "Please enter CreatedDate")]
        [Display(Name = "CreatedDate", Prompt = "Enter CreatedDate", Description = "Please Enter CreatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "ModifiedBy cannot be blank")]
        [Display(Name = "ModifiedBy", Prompt = "ModifiedBy", Description = "ModifiedBy cannot be blank")]
        [Column(TypeName = "bigint")]
        public Int64? ModifiedBy { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }
    }
}
