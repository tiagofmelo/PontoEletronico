using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using PontoEletronico.Models;

namespace PontoEletronico.Session
{
    public interface ISession
    {
        HttpCookie ArmazenaToken(TokenModel tokenModel);
        TokenModel RetornaToken(HttpCookie httpCookie);
    }
}
