using interviewbase.DTO;
using interviewbase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interviewbase.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
    [Authorize]
  public class TopicController : ControllerBase
  {
    private readonly AppDbContext _dbContext;
    public TopicController(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    [HttpGet]
    public async Task<ActionResult<List<TopicDTO>>> GetTopics()
    {
      var result = await _dbContext.Topics.ToListAsync();
      List<TopicDTO> list = new List<TopicDTO>();
      foreach (var data in result)
      {
        list.Add(new TopicDTO()
        {
          Id = data.id,
          TopicName = data.topic_name,
        });
      }
      return Ok(list);
    }


    [HttpPost]
    public async Task<ActionResult<Topics>> InsertTopic([FromBody] TopicDTO topicDto)
    {
      var topic = new Topics()
      {
        topic_name = topicDto.TopicName,
      };
     var result= await _dbContext.AddAsync(topic);
      await _dbContext.SaveChangesAsync();
      return Ok(topic);
    }
  }
}
