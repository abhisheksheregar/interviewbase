using interviewbase.Core.DTO;
using interviewbase.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewBase.Application.Repository
{
    public interface ITopicsRepository
    {

        Task<List<Topics>> GetTopics();

        Task<Topics> InsertTopic(Topics topicDto);
    }
}
