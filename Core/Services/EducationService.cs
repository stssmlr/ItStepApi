using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class EducationService : IEducationService
    {
        private readonly ITStepDbContext ctx;
        private readonly IMapper mapper;
        private readonly IValidator<CreateEducationDto> validator;

        public EducationService(ITStepDbContext ctx, IMapper mapper, IValidator<CreateEducationDto> validator)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task Archive(int id)
        {
            var product = await ctx.Educations.FindAsync(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);


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
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

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
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);


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
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = false;
            await ctx.SaveChangesAsync();
        }
    }
}

