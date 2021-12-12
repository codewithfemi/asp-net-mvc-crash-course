using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Core.Models;

namespace WebApplication3.Core.Interfaces
{
    public interface IDataService
    {
        Task<List<Blog>> GetBlogListAsync();
    }
}
