using System.ComponentModel.DataAnnotations;

namespace Angular2MultiSPA.Helpers
{
    public enum BooleanDisplayOptions
    {
        [Display(Name = "True/False")]
        tf = 0,

        [Display(Name = "Yes/No")]
        yn = 1,

        [Display(Name = "Checkbox")]
        cb = 2
    }
}
