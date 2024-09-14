using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ConsumosController : ControllerBase
    {
        private readonly AppDbContext _context;

        //construtor
        public ConsumosController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //indo no banco de dados
            var model = await _context.Consumos.ToListAsync();
            return Ok(model);
        }



         [HttpPost]
        public async Task<ActionResult> Create(Consumo model)
        {
           

            _context.Consumos.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int Id)
        {
           var model = await _context.Consumos
           .FirstOrDefaultAsync(c => c.Id == Id);

           if(model == null) return NotFound();
           
           GerarLinks(model);
           return Ok(model);

        }


       
         [HttpPut("{id}")]
        public async Task<ActionResult> Update(int Id, Consumo model)
        {
           if(Id != model.Id) return BadRequest();
           var modeloDb = await _context.Consumos.AsNoTracking()
           .FirstOrDefaultAsync(c => c.Id == Id);

           if(modeloDb == null) return NotFound();

           _context.Consumos.Update(model);
           await _context.SaveChangesAsync();
           return NoContent();

        }



         [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
           var model = await _context.Consumos.FindAsync(Id);

           if(model == null) return NotFound();
           _context.Consumos.Remove(model);
           await _context.SaveChangesAsync();
           return NoContent();
        }



        private void GerarLinks(Consumo model)
        {
            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "self", metodo: "GET"));

            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "update", metodo: "PUT"));

            model.Links.Add(new LinkDto(model.Id,Url.ActionLink() ,rel: "delete", metodo: "Delete"));
        }


    }
}