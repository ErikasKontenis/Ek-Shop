using System.Collections.Generic;

namespace Ek.Shop.Application.Classifiers
{
    public class CategoryNavigationDto
    {
        public Dictionary<string, string> Characteristics { get; set; }

        public int Id { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public int? ParentId { get; set; }

        public string Type { get; set; }

        public string Url { get; set; }
    }
}
