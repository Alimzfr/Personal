using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public interface IContactService
    {
        Task<int> CreatMessage(UserMessageDto userMessage);
    }
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ContactService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CreatMessage(UserMessageDto userMessage)
        {
            var newMessage = _mapper.Map<UserMessageDto, UserMessage>(userMessage);
            _context.UserMessages.Add(newMessage);
            await _context.SaveChangesAsync();
            return newMessage.Id;
        }
    }
}
