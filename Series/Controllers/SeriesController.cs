using Microsoft.AspNetCore.Mvc;
using Series.Core.Entidades;
using Series.Models.Input;
using Series.Models.View;
using Series.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Series.Controllers
{   
    [Route("[controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesContext _dbcontext;
        public SeriesController(SeriesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        // GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var todasseries = _dbcontext.Series.Where(s => s.Ativo);

            var viewtodasseries = todasseries
                .Select(s => new ViewSerie(s.Ano, s.Titulo, s.Descricao, s.Genero, s.Id));

            return Ok(viewtodasseries);
        }

        [HttpGet("get-by-id")]
        public IActionResult Get(int id)
        {
            var serie = _dbcontext.Series.SingleOrDefault(s => s.Id == id);

            if(serie == null || !serie.Ativo )
            {
                return NotFound();
            } else
            {
                var viewserie = new ViewSerie
                    (serie.Ano, serie.Titulo, serie.Descricao, serie.Genero, serie.Id);
                return Ok(viewserie);
            }

        }

        [HttpGet("get-by-genero")]
        public IActionResult GetAll(Genero genero)
        {
            var seriesdestegenero = _dbcontext.Series.Where(sdg => sdg.Genero == genero && sdg.Ativo);
            var viewseriesporgenero = seriesdestegenero
                .Select(sdg => new ViewSerie(sdg.Ano, sdg.Titulo, sdg.Descricao, sdg.Genero, sdg.Id));

            return Ok(viewseriesporgenero);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] CreateSerie inputModel)
        {
            Serie serie = new Serie
                (inputModel.Ano, inputModel.Titulo, inputModel.Descricao, inputModel.Genero);

            _dbcontext.Series.Add(serie);
            _dbcontext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = serie.Id }, inputModel);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateSerie inputModel)
        {
            var serie = _dbcontext.Series.SingleOrDefault(s => s.Id == id);

            if (serie == null)
                return NotFound();

            serie.Atualizar(inputModel.Ano, inputModel.Titulo, inputModel.Descricao, inputModel.Genero);
            _dbcontext.SaveChanges();

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var serie = _dbcontext.Series.SingleOrDefault(s => s.Id == id);

            if (serie == null)
                return NotFound();

            serie.Desativar();
            _dbcontext.SaveChanges();

            return NoContent();
        }

    }
}
