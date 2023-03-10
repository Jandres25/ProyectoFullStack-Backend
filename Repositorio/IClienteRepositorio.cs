using APIClientes.Modelos.Dto;

namespace APIClientes.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<List<ClienteDto>> GetClientes();
        Task<ClienteDto> GetClienteById(int id);
        Task<ClienteDto> CreateUpdate(ClienteDto clientedto);
        Task<bool> DeleteCliente(int id);
    }
}
