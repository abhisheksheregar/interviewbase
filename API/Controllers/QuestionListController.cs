using interviewbase.DTO;
using interviewbase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interviewbase.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class QuestionListController : ControllerBase
  {
    private readonly AppDbContext _dbContext;
    public QuestionListController(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionList>>> GetAllQuestions()
    {
      var results = await _dbContext.QuestionList.ToListAsync();
      return Ok(results);
    }

    [HttpPost]
    public async Task<ActionResult<QuestionList>> InsertQuestions([FromBody] QuestionListDTO questionListDto)
    {
      QuestionList question = new QuestionList()
      {
        questions = questionListDto.Questions,
        answers = questionListDto.Answers,
        topic_id = questionListDto.TopicId
      };
      var inserted = await _dbContext.AddAsync(question);
      await _dbContext.SaveChangesAsync();
      return Ok(question);
    }


    [HttpPut]
    public  async Task<ActionResult<QuestionList>> UpdateQuestion([FromBody] QuestionListDTO questionListDTO)
    {
      if (questionListDTO.Id == 0)
      {
        return BadRequest();
      }
      var questionList = new QuestionList()
      {
        id = questionListDTO.Id,
        questions = questionListDTO.Questions,
        answers = questionListDTO.Answers,
        topic_id = questionListDTO.TopicId
      };
      var updated =  _dbContext.Update(questionList);
      await _dbContext.SaveChangesAsync();
      return Ok(questionList);
      
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteQuestion(int id)
    {
      var result = await _dbContext.QuestionList.FindAsync(id);
      if(result==null)
      {
        return NotFound();
      }
       _dbContext.QuestionList.Remove(result);
      _dbContext.SaveChangesAsync();
      return true;
    }
}
}

