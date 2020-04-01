using Alimzfr.DataLayer.Data;
using Alimzfr.DomainLayer.Entities;
using Alimzfr.ModelLayer.Models;
using Alimzfr.ServiceLayer.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Alimzfr.ServiceLayer.Services
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public ContactService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> CreatComment(UserCommentDto userComment)
        {
            var newComment = _mapper.Map<UserCommentDto, UserComment>(userComment);
            _context.userComments.Add(newComment);
            await _context.SaveChangesAsync();
            return newComment.Id;
        }
    }
}
