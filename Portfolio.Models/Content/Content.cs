using Portfolio.Models.Image;
using System.Collections.Generic;

namespace Portfolio.Models.Content
{
    public class Content
    {
        public int Id { get; set; }
        public string ContentMaterial { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public virtual List<ImagePath> ImagePaths { get; set; }
    }
}
