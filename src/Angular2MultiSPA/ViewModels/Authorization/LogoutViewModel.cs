using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Angular2MultiSPA.ViewModels.Authorization {
    public class LogoutViewModel {
        [BindNever]
        public IDictionary<string, string> Parameters { get; set; }
    }
}
