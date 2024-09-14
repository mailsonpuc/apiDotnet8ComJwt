using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using mf_apis_web_services_fuel_manager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_apis_web_services_fuel_manager.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VeiculosController : ControllerBase
    {
        private readonly AppDbContext _context;

        //construtor
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //indo no banco de dados
            var model = await _context.Veiculos.ToListAsync();
            return Ok(model);
        }


       [HttpPost]
        public async Task<ActionResult> Create(Veiculo model)
        {
            if(model.AnoFabricacao <= 0 || model.AnoModelo <= 0){
                return BadRequest(new {message = "Ano de fabricação e Ano de modelo são obrigatorio e devem ser maiores do que zero"});
            }

            _context.Veiculos.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }
        



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int Id)
        {
           var model = await _context.Veiculos
           .Include(t => t.Usuarios).ThenInclude(t => t.Usuario)
           .Include(t => t.Consumos)
           .FirstOrDefaultAsync(c => c.Id == Id);

           if(model == null) return NotFound();
           GerarLinks(model);
           return Ok(model);

        }


         [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, Veiculo model)
        {
           if(Id != model.Id) return BadRequest();
           var modeloDb = await _context.Veiculos.AsNoTracking()
           .FirstOrDefaultAsync(c => c.Id == Id);

           if(modeloDb == null) return NotFound();

           _context.Veiculos.Update(model);
           await _context.SaveChangesAsync();
           return NoContent();

        }



         [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
           var model = await _context.Veiculos.FindAsync(Id);

           if(model == null) return NotFound();
           _context.Veiculos.Remove(model);
           await _context.SaveChangesAsync();
           return NoContent();
        }


        private void GerarLinks(Veiculo model)
        {
            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "self", metodo: "GET"));

            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "update", metodo: "PUT"));

            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "delete", metodo: "Delete"));
        }


        [HttpPost("{id}/usuarios")]
        public async Task<ActionResult> AddUsuario(int id, VeiculoUsuarios model)
        {
            if(id != model.VeiculoId) return BadRequest();

            _context.VeiculosUsuarios.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new {id = model.VeiculoId }, model);

        }


        [HttpDelete("{id}/usuarios/{usuarioId}")]
        public async Task<ActionResult> DeleteUsuario(int id, int usuarioId)
        {
            var model = await _context.VeiculosUsuarios
            .Where(c => c.VeiculoId == id && c.UsuarioId == usuarioId)
            .FirstOrDefaultAsync();

            if(model == null) return NotFound();

            _context.VeiculosUsuarios.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}