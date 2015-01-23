namespace JobApplications.Web.Models.Profile
{
    using System.ComponentModel.DataAnnotations;

    public class ProfileIndexViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 4)]
        [RegularExpression(@"^\w+$", ErrorMessage = "Allowed characters: a-zA-Z0-9_")]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Content does not match the New password field.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }
    }
}
