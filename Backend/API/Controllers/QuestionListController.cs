
using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using interviewbase.Infrastructure;
using InterviewBase.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interviewbase.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class QuestionListController : ControllerBase
  {

   private readonly IQuestionService _questionService;
    public QuestionListController(IQuestionService questionService)
    {
            _questionService = questionService;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionList>>> GetAllQuestions()
    {
      var results = _questionService.GetAllQuestions();
      return Ok(results);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionList>> InsertQuestions([FromBody] QuestionListDTO questionListDto)
    {
      var question = await _questionService.InsertQuestions(questionListDto);
      return Ok(question);
    }


    [HttpPut]
    public  async Task<ActionResult<QuestionList>> UpdateQuestion([FromBody] QuestionListDTO questionListDTO)
    {
      if (questionListDTO.Id == 0)
      {
        return BadRequest();
      }
      var questionList = await _questionService.UpdateQuestion(questionListDTO);
      return Ok(questionList);
      
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteQuestion(int id)
    {
     var result=await _questionService.DeleteQuestion(id);
      return Ok(result);
    }
}
}

