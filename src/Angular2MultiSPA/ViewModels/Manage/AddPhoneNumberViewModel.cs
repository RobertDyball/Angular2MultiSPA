using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels.Manage {
    public class AddPhoneNumberViewModel {
        [Required]
        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}
