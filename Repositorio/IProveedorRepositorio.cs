using APIClientes.Modelos.Dto;

namespace APIClientes.Repositorio
{
    public interface IProveedorRepositorio
    {
        Task<List<ProveedorDto>> GetProveedores();
        Task<ProveedorDto> GetProveedorById(int id);
        Task<ProveedorDto> CreateUpdate(ProveedorDto proveedordto);
        Task<bool> DeleteProveedor(int id);
    }
}
