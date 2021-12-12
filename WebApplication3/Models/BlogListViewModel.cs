using System;

namespace WebApplication3.Models
{
    public class BlogListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Ratings { get; set; }

        public string GetStarRatings()
        {
            switch(Ratings)
            {
                case 1: return "*";
                case 2: return "**";
                case 3: return "***";
                case 4: return "****";
                case 5: return "*****";
                default: return string.Empty;
            }
        }
    }
}
