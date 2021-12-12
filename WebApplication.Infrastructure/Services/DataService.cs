using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Core.Interfaces;
using WebApplication3.Core.Models;

namespace WebApplication.Infrastructure.Services
{
    public class DataService : IDataService
    {
        public async Task<List<Blog>> GetBlogListAsync()
        {
            // TODO: Update mock data to real data
            return await Task.Run(() => new List<Blog>
            {
                new Blog { Name = "My First Journey to Africa", Ratings = 4 },
                new Blog { Name = "My First History book", Ratings = 3 },
                new Blog { Name = "My First YouTube Video", Ratings = 5 },
            });
        }
    }
}
