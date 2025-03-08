using Application.Categories.Queries;
using Application.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Handlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery,CategoryDto>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;


        public GetCategoryQueryHandler(ICategoryRepository _categoryRepository , IMapper _mapper)
        {
            categoryRepository = _categoryRepository;
            mapper = _mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
          var category = await categoryRepository.GetByIdAsync(request.CategoryId);
            return mapper.Map<CategoryDto>(category);
        }
    }
}
