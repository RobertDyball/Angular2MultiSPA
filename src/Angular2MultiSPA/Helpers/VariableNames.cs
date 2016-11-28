using Humanizer;

namespace Angular2MultiSPA.Helpers
{
    public static class VariableNames
    {
        /// <summary>
        /// Create the angular binding variable name
        /// </summary>
        /// <remarks>
        /// If bind-pa (parent name) and bind-to (property name override) are not supplied, then the name of the variable used for 
        /// angular data-binding is taken directly from the view model property name.
        /// If parent (bind-pa) and override name (bind-to) are both supplied the angular data-bind variable is set to bindapa.bindto
        /// If the bind-to is supplied and bind-pa (parent) not supplied, then only the bind-to is used
        /// </remarks>
        /// <param name="bindPa">optional parent name</param>
        /// <param name="bindTo">optional property name, to override model property</param>
        /// <param name="propertyName">property name from viewModel property</param>
        /// <returns></returns>
        public static string GetDataBindVariableName(this string propertyName, string bindPa, string bindTo)
        {
            var varName = string.IsNullOrEmpty(bindTo) ? propertyName.Camelize() : bindTo;
            return (!string.IsNullOrEmpty(bindPa) && !string.IsNullOrWhiteSpace(bindPa)) ? string.Format("{0}.{1}", bindPa, varName) : varName;
        }
    }
}
