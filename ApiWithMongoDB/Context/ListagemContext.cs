using ApiWithMongoDB.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithMongoDB.Context
{
    public class ListagemContext
    {
        private IConfiguration _configuration;

        public ListagemContext(IConfiguration config)
        {
            _configuration = config;
        }

        public T ObterItem<T>(string codigo)
        {
            MongoClient client = new MongoClient(_configuration.GetConnectionString("ConexaoListagem"));
            IMongoDatabase db = client.GetDatabase("DbListagem");
            var filter = Builders<T>.Filter.Eq("Codigo", codigo);
            return db.GetCollection<T>("Catalogo").Find(filter).FirstOrDefault();
        }
        public void AdicionarFilmeSerie()
        {
            MongoClient client = new MongoClient(_configuration.GetConnectionString("ConexaoListagem"));
            IMongoDatabase db = client.GetDatabase("DbListagem");
            var catalogo = db.GetCollection<Filme>("Catalogo");


            Filme filme0001 = new Filme();
            filme0001.Codigo = "0001";
            filme0001.DataLançamento = DateTime.Now;
            filme0001.Duracao = "120";
            filme0001.Nome = "Filme 0001";
            catalogo.InsertOne(filme0001);

            Filme filme0002 = new Filme();
            filme0002.Codigo = "0002";
            filme0002.DataLançamento = DateTime.Now;
            filme0002.Duracao = "90";
            filme0002.Nome = "Filme 0002";
            catalogo.InsertOne(filme0002);

            var catalogoSerie = db.GetCollection<Serie>("Catalogo");

            Serie serie = new Serie();
            serie.Codigo = "0004";
            serie.DataLançamento = DateTime.Now;
            serie.Episodios = new Episodio();
            serie.Episodios.Codigo = "EP04";
            serie.Episodios.Nome = "A volta dos que não foram";
            serie.Nome = "Stranger Things";
            serie.Tipo = "Terror";
            catalogoSerie.InsertOne(serie);

            Serie serie1 = new Serie();
            serie1.Codigo = "0005";
            serie1.DataLançamento = DateTime.Now;
            serie1.Episodios = new Episodio();
            serie1.Episodios.Codigo = "EP05";
            serie1.Episodios.Nome = "Segunda Chance";
            serie1.Nome = "Stranger Things";
            serie1.Tipo = "Terror";
            catalogoSerie.InsertOne(serie1);


        }
    }
}
