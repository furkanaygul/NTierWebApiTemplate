using AutoMapper;
using BaseProjectTemplate._1.EntityLayer.Concreate;
using BaseProjectTemplate._3.BusinessLayer.Abstract;
using BaseProjectTemplate._4.ServiceLayer.DTOs;
using BaseProjectTemplate._4.ServiceLayer.Interfaces;
using System.Security.Principal;

namespace BaseProjectTemplate._4.ServiceLayer.Managers
{
    public class ApiDemoManager : IApiDemoService
    {
        private readonly IDemoClassService _apiDemoService;
        private readonly IMapper _mapper;

        public ApiDemoManager(IDemoClassService apiDemoService, IMapper mapper)
        {
            _apiDemoService = apiDemoService;
            _mapper = mapper;
        }

        public async Task<DemoDto> CreateAsync(DemoDto Dto, string UserId)
        {
            Dto.Id = Guid.NewGuid(); // Ensure a new ID is set for the new DemoClass
            var entity = _mapper.Map<DemoClass>(Dto);
            await _apiDemoService.InsertAsync(entity, UserId);
            return _mapper.Map<DemoDto>(entity);
        }

        public async Task DeleteAsync(Guid Id, string UserId)
        {
            await _apiDemoService.DeleteAsync(Id, UserId);
        }

        public async Task<List<DemoDto>> GetAllAsync()
        {
            var entities = await _apiDemoService.GetAllAsync();
            return _mapper.Map<List<DemoDto>>(entities);
        }

        public async Task<DemoDto> GetByIdAsync(Guid Id)
        {
            var entity = await _apiDemoService.GetByIdAsync(Id);
            if (entity == null)
                return null;
            return _mapper.Map<DemoDto>(entity);
        }

        public async Task<DemoDto> UpdateAsync(Guid Id, DemoDto Dto, string UserId)
        {
            var entity = await _apiDemoService.GetByIdAsync(Id);
            if (entity == null)
                throw new Exception("Not Found");
            _mapper.Map(Dto, entity);
            await _apiDemoService.UpdateAsync(entity, UserId);
            return _mapper.Map<DemoDto>(entity);
        }
    }
}
