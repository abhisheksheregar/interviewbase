using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using InterviewBase.Application.Interfaces;
using InterviewBase.Application.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Application.Services
{
    public class QuestionService : IQuestionService
    {
        public readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionRepository) {
            _questionRepository = questionRepository;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            var result = await _questionRepository.DeleteQuestion(id);
            return result;
        }

        public async Task<List<QuestionList>> GetAllQuestions()
        {
            var results = await _questionRepository.GetAllQuestions();
            return results;
        }

        public async Task<QuestionList> InsertQuestions(QuestionListDTO questionListDto)
        {
            QuestionList question = new QuestionList()
            {
                questions = questionListDto.Questions,
                answers = questionListDto.Answers,
                topic_id = questionListDto.TopicId
            };
            var inserted = await _questionRepository.InsertQuestions(question);
            return inserted;
        }

        public async Task<QuestionList> UpdateQuestion(QuestionListDTO questionListDTO)
        {
            var questionList = new QuestionList()
            {
                id = questionListDTO.Id,
                questions = questionListDTO.Questions,
                answers = questionListDTO.Answers,
                topic_id = questionListDTO.TopicId
            };
            var updated = await _questionRepository.UpdateQuestion(questionList);
            return updated;
        }
    }
}
