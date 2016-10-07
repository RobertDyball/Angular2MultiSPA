using System;
using OpenIddict;

namespace Angular2MultiSPA.Models {
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : OpenIddictUser<Guid>
    {
        public string GivenName { get; set; }
    }
}
