namespace Angular2MultiSPA.ViewModels
{
    public class Category
    {
        public int Id { get; set; }

        /// <summary>
        /// Short name of category
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full description of category
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// Image representing category
        /// </summary>
        public string Image { get; set; }
    }
}
