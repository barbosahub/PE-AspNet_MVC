using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace AspNetMvc.Models
{
    public class ClienteModels
    {
       
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public String Nome { get; set; }

        [BsonElement("email")]
        [Required(ErrorMessage = "Email é obrigatório")]
        public String Email { get; set; }

        [BsonElement("cpf")]
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public String Cpf { get; set; }

        [BsonElement("_class")]
        public String _Class { get; set; }
    }
}