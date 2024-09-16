using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Data.Repositories;
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
        
        private readonly IMapper mapper;
        private readonly IValidator<CreateEducationDto> validator;
        private readonly IRepository<Education> educationR;

        public EducationService(IRepository<Education> educationR, IMapper mapper, IValidator<CreateEducationDto> validator)
        {
            this.educationR = educationR;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task Archive(int id)
        {
            var product = await educationR.GetById(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);


            product.Archived = true;
            await educationR.Save();
        }

        public async Task Create(CreateEducationDto model)
        {
            // TODO: validate model

            await educationR.Insert(mapper.Map<Education>(model));
            await educationR.Save();
        }

        public async Task Delete(int id)
        {
            var product = await educationR.GetById(id);
   
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            await educationR.Delete(product);
            await educationR.Save();
        }

        public async Task Edit(EditEducationDto model)
        {
            // TODO: validate model

            await educationR.Update(mapper.Map<Education>(model));
            await educationR.Save();
        }

        public async Task<EducationDto?> Get(int id)
        {
            var product = await educationR.GetById(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);


            // load related table data
            //await ctx.Entry(product).Reference(x => x.Category).LoadAsync();

            return mapper.Map<EducationDto>(product);
        }

        public async Task<IEnumerable<EducationDto>> GetAll()
        {
            return mapper.Map<List<EducationDto>>(await educationR.GetAll()); 
        }

        public async Task Restore(int id)
        {
            var product = await educationR.GetById(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = false;
            await educationR.Save();
        }
    }
}

