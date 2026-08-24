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
  public class TopicController : ControllerBase
  {
    private readonly ITopicsService _topicsService;
    public TopicController(ITopicsService topicsService)
    {
      _topicsService=topicsService; 
    }

    [HttpGet]
    public async Task<ActionResult<List<TopicDTO>>> GetTopics()
    {
      var list = await _topicsService.GetTopics();
      return Ok(list);
    }


    [HttpPost]
    public async Task<ActionResult<Topics>> InsertTopic([FromBody] TopicDTO topicDto)
    {
      var topic=_topicsService.InsertTopic(topicDto);
      return Ok(topic);
    }
  }
}
