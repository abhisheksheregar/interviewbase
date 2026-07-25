using System.ComponentModel.DataAnnotations;

namespace interviewbase.DTO
{
  public class QuestionListDTO
  {
    public int Id { get; set; }
    [Required]
    public string Questions { get; set; }
    [Required]
    public string Answers { get; set; }
    [Required]
    public int TopicId { get; set; }
  }
}
