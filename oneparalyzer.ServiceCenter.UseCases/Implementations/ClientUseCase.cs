using AutoMapper;
using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.UseCases.DTOs.Client;
using oneparalyzer.ServiceCenter.UseCases.Interfaces;

namespace oneparalyzer.ServiceCenter.UseCases.Implementations
{
    public class ClientUseCase : IClientUseCase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientUseCase(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddAsync(AddClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetClientDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(RemoveClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateClientDTO clientDTO)
        {
            throw new NotImplementedException();
        }
    }
}
