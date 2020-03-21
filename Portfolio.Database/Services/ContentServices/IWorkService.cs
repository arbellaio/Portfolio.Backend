using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Portfolio.Database.DataContext;
using Portfolio.Models.Content;

namespace Portfolio.Database.Services.ContentServices
{
    public interface IWorkService
    {
        Task<List<Content>> GetProjects();
        Task<bool> AddOrUpdateProjects(Content content);
    }

    public class WorkService : IWorkService
    {
        private readonly ApplicationDataContext _context;
        public WorkService(ApplicationDataContext context)
        {
            _context = context ?? throw new ArgumentNullException("DataContext Content");
        }


        public async Task<List<Content>> GetProjects()
        {
            return await _context.Contents.Include(x => x.ImagePaths).ToListAsync();
        }

        public async Task<bool> AddOrUpdateProjects(Content content)
        {
            if (content != null)
            {
                await _context.Contents.AddAsync(content);
                foreach (var imagePath in content.ImagePaths)
                {
                    await _context.ImagePaths.AddAsync(imagePath);
                }

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<Content> GetContentById(int id)
        {
            var contentInDb = await _context.Contents.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return contentInDb;
        }
    }
}
