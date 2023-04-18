using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PontoEletronico.Models
{
    public class TokenModel
    {
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
        public string tokenType { get; set; }
        public string expiresIn { get; set; }
        public string name { get; set; }
    }
}