﻿using AutoMapper;
using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public UserRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
        }
        public async Task<User> Add(User user)
        {
            await _dbcontext.Set<User>().AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async void Delete(User user)
        {
            _dbcontext.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _dbcontext.Set<User>().FindAsync(id);
            if (user == null)
            {
                throw new Exception("User does not Exist");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _dbcontext.Set<User>().ToListAsync();
            return users;
        }

        public async void Update(User user)
        {
            var exuser = await _dbcontext.Set<User>().FindAsync(user.Id);
            if(exuser == null)
            {
                throw new Exception("User does not Exist");
            }
            _mapper.Map(user, exuser);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
