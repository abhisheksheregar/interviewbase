using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Application.Interfaces
{
    public interface ITopicsService
    {

        Task<List<TopicDTO>> GetTopics();
        Task<Topics> InsertTopic(TopicDTO topicDto);
    }
}
