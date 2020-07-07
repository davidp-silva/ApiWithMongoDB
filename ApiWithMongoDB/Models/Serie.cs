using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithMongoDB.Models
{
    public class Serie
    {
        public ObjectId _id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime DataLançamento { get; set; }
        public Episodio Episodios { get; set; }


    }
    public class Episodio
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }
    }
}
