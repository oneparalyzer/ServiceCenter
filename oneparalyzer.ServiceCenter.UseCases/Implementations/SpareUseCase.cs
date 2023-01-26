using AutoMapper;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.Domain.Entities;
using oneparalyzer.ServiceCenter.Domain.Exceptions;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Spare;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;


namespace oneparalyzer.ServiceCenter.UseCases.Implementations
{
    public class SpareUseCase : ISpareUseCase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SpareUseCase(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task AddAsync(AddSpareDTO spareDTO)
        {
            var spare = _context.Spares.FirstOrDefault(x => x.Title == spareDTO.Title);
            if (spare != null)
            {
                throw new EntityAlreadyExistsException($"Entity 'Service' where 'Title' = {spareDTO.Title} already exist");
            }
            spare = _mapper.Map<Spare>(spareDTO);
            await _context.Spares.AddAsync(spare);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GetSpareDTO> GetAll()
        {
            var spare = _context.Spares;
            var spareDTO = _mapper.Map<IEnumerable<GetSpareDTO>>(spare);
            return spareDTO;
        }

        public async Task RemoveAsync(RemoveSpareDTO spareDTO)
        {
            var spare = await _context.Spares.FirstOrDefaultAsync(x => x.Id == spareDTO.Id);
            if (spare == null)
            {
                throw new EntityNotFoundException($"Entity 'Spare' where 'Id' = {spareDTO.Id} not found");
            }
            _context.Spares.Remove(spare);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSpareDTO spareDTO)
        {
            var spare = await _context.Spares.FirstOrDefaultAsync(x => x.Id == spareDTO.Id);
            if (spare == null)
            {
                throw new EntityNotFoundException($"Entity 'Spare' where 'Id' = {spareDTO.Id} not found");
            }
            spare = await _context.Spares.FirstOrDefaultAsync(x =>
                x.Title == spareDTO.Title && x.Id != spareDTO.Id);
            if (spare != null)
            {
                throw new EntityAlreadyExistsException($"Entity 'Spare' where 'Title' = {spareDTO.Title} already exist");
            }
            spare = _mapper.Map<Spare>(spareDTO);
            _context.Spares.Update(spare);
            await _context.SaveChangesAsync();
        }
    }
}
