﻿using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _dbcontext;

        public SkillService(DevFreelaDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbcontext.Skills;

            var skillsViewModel = skills.
                Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
