using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.ViewModels.Account {
    public class ForgotPasswordViewModel {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
