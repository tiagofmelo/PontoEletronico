using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PontoEletronico.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Usuário obrigatório")]
        public string userID { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string accessKey { get; set; }

        public string grantType { get => "password"; }
    }
}