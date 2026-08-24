using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<List<QuestionList>> GetAllQuestions();

        Task<QuestionList> InsertQuestions(QuestionListDTO questionListDto);

        Task<QuestionList> UpdateQuestion(QuestionListDTO questionListDTO);

        Task<bool> DeleteQuestion(int id);
    }
}
