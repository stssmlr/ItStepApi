using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EducationService : IEducationService
    {
        private readonly ITStepDbContext ctx;
        private readonly IMapper mapper;

        public EducationService(ITStepDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task Archive(int id)
        {
            var product = await ctx.Educations.FindAsync(id);
            if (product == null) return; // TODO: exception

            product.Archived = true;
            await ctx.SaveChangesAsync();
        }

        public async Task Create(CreateEducationDto model)
        {
            // TODO: validate model

            ctx.Educations.Add(mapper.Map<Education>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await ctx.Educations.FindAsync(id);
            if (product == null) return; // TODO: exception

            ctx.Educations.Remove(product);
            await ctx.SaveChangesAsync();
        }

        public async Task Edit(EditEducationDto model)
        {
            // TODO: validate model

            ctx.Educations.Update(mapper.Map<Education>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task<EducationDto?> Get(int id)
        {
            var product = await ctx.Educations.FindAsync(id);
            if (product == null) return null;

            // load related table data
            await ctx.Entry(product).Reference(x => x.Category).LoadAsync();

            return mapper.Map<EducationDto>(product);
        }

        public async Task<IEnumerable<EducationDto>> GetAll()
        {
            return mapper.Map<List<EducationDto>>(await ctx.Educations.ToListAsync());
        }

        public async Task Restore(int id)
        {
            var product = await ctx.Educations.FindAsync(id);
            if (product == null) return; // TODO: exception

            product.Archived = false;
            await ctx.SaveChangesAsync();
        }
    }
}

