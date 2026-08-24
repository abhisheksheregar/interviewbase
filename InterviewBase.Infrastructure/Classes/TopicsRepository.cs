using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using interviewbase.Infrastructure;
using InterviewBase.Application.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Infrastructure.Classes
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly AppDbContext _dbContext;
        public TopicsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Topics>> GetTopics()
        {
            var result = await _dbContext.Topics.ToListAsync();
            return result;
        }

        public async Task<Topics> InsertTopic(Topics topic)
        {
            var result = await _dbContext.AddAsync(topic);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
