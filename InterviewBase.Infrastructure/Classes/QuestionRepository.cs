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
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _dbContext;
        public QuestionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> DeleteQuestion(int id)
        {
            var question = await _dbContext.QuestionList.FindAsync(id);
            if (question == null)
                return false;
            _dbContext.QuestionList.Remove(question);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<QuestionList>> GetAllQuestions()
        {
            var results = await _dbContext.QuestionList.ToListAsync();
            return results;
        }

        public async Task<QuestionList> InsertQuestions(QuestionList question)
        {
            var inserted = await _dbContext.AddAsync(question);
            await _dbContext.SaveChangesAsync();
            return inserted.Entity;
        }

        public async Task<QuestionList> UpdateQuestion(QuestionList questionList)
        {
            var updated = _dbContext.Update(questionList);
            await _dbContext.SaveChangesAsync();
            return updated.Entity;
        }
    }
}
