using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Service;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;
using oneparalyzer.ServiceCenter.Domain.Exceptions;
using AutoMapper;
using oneparalyzer.ServiceCenter.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace oneparalyzer.ServiceCenter.UseCases.Implementations
{
    public class ServiceUseCase : IServiceUseCase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceUseCase(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(AddServiceDTO serviceDTO)
        {
            var service = _context.Services.FirstOrDefault(x => x.Title == serviceDTO.Title);
            if (service != null)
            {
                throw new EntityAlreadyExistsException($"Entity 'Service' where 'Title' = {serviceDTO.Title} already exist");
            }
            service = _mapper.Map<Service>(serviceDTO);
            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GetServiceDTO> GetAll()
        {
            var services = _context.Services;
            var servicesDTO = _mapper.Map<IEnumerable<GetServiceDTO>>(services);
            return servicesDTO;
        }

        public async Task RemoveAsync(RemoveServiceDTO serviceDTO)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceDTO.Id);
            if (service == null)
            {
                throw new EntityNotFoundException($"Entity 'Service' where 'Id' = {serviceDTO.Id} not found");
            }
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateServiceDTO serviceDTO)
        {
            var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceDTO.Id);
            if (service == null)
            {
                throw new EntityNotFoundException($"Entity 'Service' where 'Id' = {serviceDTO.Id} not found");
            }
            service = await _context.Services.FirstOrDefaultAsync(x => 
                x.Title == serviceDTO.Title && x.Id != serviceDTO.Id);
            if (service != null)
            {
                throw new EntityAlreadyExistsException($"Entity 'Service' where 'Title' = {serviceDTO.Title} already exist");
            }
            service = _mapper.Map<Service>(service);
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
        }
    }
}
