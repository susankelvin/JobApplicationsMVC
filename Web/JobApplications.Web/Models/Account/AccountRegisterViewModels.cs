namespace JobApplications.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class AccountRegisterViewModel
    {
        [Required]
        [MinLength(4, ErrorMessage = "{0} should have at least {1} characters")]
        [MaxLength(20, ErrorMessage = "{0} should have at most {1} characters")]
        [RegularExpression(@"^[\w@%\.]+$", ErrorMessage = "Allowed characters: a-zA-Z0-9_@%.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 4)]
        [RegularExpression(@"^\w+$", ErrorMessage = "Allowed characters: a-zA-Z0-9_")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Content does not match the Password field.")]
        public string ConfirmPassword { get; set; }
    }
}
