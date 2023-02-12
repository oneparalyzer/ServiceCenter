using AutoMapper;
using Microsoft.EntityFrameworkCore;
using oneparalyzer.ServiceCenter.DataAccess.Interfaces;
using oneparalyzer.ServiceCenter.Domain.Entities;
using oneparalyzer.ServiceCenter.Domain.Exceptions;
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

        public async Task AddAsync(AddClientDTO clientDTO)
        {
            Client client;

            if (string.IsNullOrWhiteSpace(clientDTO.Email))
            {
                client = await _context.Clients.FirstOrDefaultAsync(x =>
                    x.PhoneNumber == clientDTO.PhoneNumber);
            }
            else
            {
                client = await _context.Clients.FirstOrDefaultAsync(x =>
                    x.PhoneNumber == clientDTO.PhoneNumber || x.Email == clientDTO.Email);
            }

            if (client != null)
            {
                throw new EntityAlreadyExistsException($"Entity 'Client' where 'PhoneNumber' = {clientDTO.PhoneNumber} or 'Email' = {clientDTO.Email} already exist");
            }

            client = _mapper.Map<Client>(clientDTO);
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GetClientDTO> GetAll()
        {
            var clients = _context.Clients;
            var clientsDTO = _mapper.Map<IEnumerable<GetClientDTO>>(clients);
            return clientsDTO;
        }

        public async Task RemoveAsync(RemoveClientDTO clientDTO)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientDTO.Id);
            if (client == null)
            {
                throw new EntityNotFoundException($"Entity 'Client' where 'Id' = {clientDTO.Id} not found");
            }
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateClientDTO clientDTO)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == clientDTO.Id);
            if (client == null)
            {
                throw new EntityNotFoundException($"Entity 'Client' where 'Id' = {clientDTO.Id} not found");
            }
            _context.Clients.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
