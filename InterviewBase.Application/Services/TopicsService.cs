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
    public class TopicsService : ITopicsService
    {
        public readonly ITopicsRepository _topicsRepository;
        public TopicsService(ITopicsRepository topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }
        public async Task<List<TopicDTO>> GetTopics()
        {
            var result = await _topicsRepository.GetTopics();
            List<TopicDTO> list = new List<TopicDTO>();
            foreach (var data in result)
            {
                list.Add(new TopicDTO()
                {
                    Id = data.id,
                    TopicName = data.topic_name,
                });
            }
            return list;
        }

        public async Task<Topics> InsertTopic(TopicDTO topicDto)
        {
            var topic = new Topics()
            {
                topic_name = topicDto.TopicName,
            };
            var result = await _topicsRepository.InsertTopic(topic);
            return result;
        }
    }
}
