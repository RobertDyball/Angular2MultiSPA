namespace Angular2MultiSPA.Helpers
{
    public static class AttributeHelpers
    {
        /// <summary>
        /// Handles attribute used for true/yes/show are true and false/no/hide are returned as false, default if null or unmatched is false
        /// </summary>
        /// <remarks>Abbreviations are acceptable, t/true, s/show, y/yes all return true. And f/false, n/no, or h/hide all return false.</remarks>
        /// <param name="show"></param>
        /// <returns>boolean true or false</returns>
        public static bool IsTrue(this string show)
        {
            if (string.IsNullOrEmpty(show))
            {
                return false;
            }

            switch (show.ToLowerInvariant())
            {
                case "t":
                case "true":
                case "y":
                case "yes":
                case "s":
                case "show":
                    return true;

                case "f":
                case "false":
                case "n":
                case "no":
                case "h":
                case "hide":
                    return false;

                default:
                    return false;
            };
        }
    }
}
