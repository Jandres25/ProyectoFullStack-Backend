using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIClientes.Data;
using APIClientes.Modelos;
using APIClientes.Repositorio;
using APIClientes.Modelos.Dto;
using Microsoft.AspNetCore.Authorization;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorRepositorio _proveedorRepositorio;
        protected ResponseDto _response;
        public ProveedoresController(IProveedorRepositorio proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
            _response = new ResponseDto();
        }
        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            try
            {
                var lista = await _proveedorRepositorio.GetProveedores();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Clientes";
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }
        // GET: api/Proveedores/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _proveedorRepositorio.GetProveedorById(id);
            if (proveedor == null)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "El Proveedor No Existe";
                return NotFound(_response);
            }
            _response.Result = proveedor;
            _response.DisplayMessage = "Informcación del Proveedor";
            return Ok(_response);
        }
        // PUT: api/Proveedores/1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, ProveedorDto proveedorDto)
        {
            try
            {
                ProveedorDto model = await _proveedorRepositorio.CreateUpdate(proveedorDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "Error al Actualizar el Registro";
                _response.ErrrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(ProveedorDto proveedorDto)
        {
            try
            {
                ProveedorDto model = await _proveedorRepositorio.CreateUpdate(proveedorDto);
                _response.Result = model;
                return CreatedAtAction("GetProveedor", new { id = model.IdProveedor }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.DisplayMessage = "Error al Crear el Registro";
                _response.ErrrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        // DELETE: api/Proveedores/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            try
            {
                bool estaEliminado = await _proveedorRepositorio.DeleteProveedor(id);
                if (estaEliminado)
                {
                    _response.Result = estaEliminado;
                    _response.DisplayMessage = "El Proveedor ha sido Eliminado con Exito";
                    return Ok(_response);
                }
                else
                {
                    _response.IsSucess = false;
                    _response.DisplayMessage = "Error al Eliminar Proveedor";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.ErrrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
