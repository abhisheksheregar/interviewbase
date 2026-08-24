using System.ComponentModel.DataAnnotations;

namespace interviewbase.Core.DTO
{
  public class TopicDTO
  {
    public int Id { get; set; }
    [Required]
    public string TopicName { get; set; }
  }
}
