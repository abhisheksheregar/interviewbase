using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Application.Repository
{
    public interface IQuestionRepository
    {

        Task<List<QuestionList>> GetAllQuestions();

        Task<QuestionList> InsertQuestions(QuestionList question);

        Task<QuestionList> UpdateQuestion(QuestionList question);

        Task<bool> DeleteQuestion(int id);

    }
}
