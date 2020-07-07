using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWithMongoDB.Context;
using ApiWithMongoDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListagemController : ControllerBase
    {
        private ListagemContext _list;

        public ListagemController(ListagemContext list)
        {
            _list = list;
        }
       [HttpGet("filmes/{codigo}")]
       public ActionResult <Filme> GetFilme(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return BadRequest();

           return  _list.ObterItem<Filme>(codigo);
        }
        [HttpGet("series/{codigo}")]
        public ActionResult<Serie> GetSerie(string codigo)
        {
            if (string.IsNullOrEmpty(codigo)) return BadRequest();

            return _list.ObterItem<Serie>(codigo);
        }
        [HttpGet]
        public void AdicionarFilmeSerie()
        {
            _list.AdicionarFilmeSerie();
        }
    }
}
