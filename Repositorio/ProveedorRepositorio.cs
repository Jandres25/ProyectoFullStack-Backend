using APIClientes.Data;
using APIClientes.Modelos;
using APIClientes.Modelos.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Repositorio
{
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;
        public ProveedorRepositorio(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProveedorDto> CreateUpdate(ProveedorDto proveedorDto)
        {
            Proveedor proveedor = _mapper.Map<ProveedorDto, Proveedor>(proveedorDto);
            if (proveedor.IdProveedor > 0)
            {
                _db.Proveedores.Update(proveedor);
            }
            else
            {
                await _db.Proveedores.AddAsync(proveedor);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Proveedor, ProveedorDto>(proveedor);
        }

        public async Task<bool> DeleteProveedor(int id)
        {
            try
            {
                Proveedor proveedor = await _db.Proveedores.FindAsync(id);
                if (proveedor == null)
                {
                    return false;
                }
                _db.Proveedores.Remove(proveedor);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ProveedorDto> GetProveedorById(int id)
        {
            Proveedor proveedor = await _db.Proveedores.FindAsync(id);
            return _mapper.Map<ProveedorDto>(proveedor);
        }

        public async Task<List<ProveedorDto>> GetProveedores()
        {
            List<Proveedor> lista = await _db.Proveedores.ToListAsync();
            return _mapper.Map<List<ProveedorDto>>(lista);
        }
    }
}
