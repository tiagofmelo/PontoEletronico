using System;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using PontoEletronico.Models;

namespace PontoEletronico.Session
{
    public static class Session
    {
        public static HttpCookie ArmazenaToken(TokenModel tokenModel)
        {
            HttpCookie httpCookie = new HttpCookie("tokenModel");

            var sessionToken = JsonConvert.SerializeObject(tokenModel);

            //httpCookie.Expires = DateTime.Now.AddTicks(tokenModel.expiresIn);
            httpCookie.HttpOnly = true;
            httpCookie.Value = sessionToken;

            return httpCookie;
        }

        public static TokenModel RetornaToken(HttpCookie httpCookie)
        {
            TokenModel tokenModel = new TokenModel();

            tokenModel = JsonConvert.DeserializeObject<TokenModel>(httpCookie.Value);

            return tokenModel;
        }

        public static HttpCookie ArmazenaTimesheet(TimesheetModel timesheetModel)
        {
            HttpCookie httpCookie = new HttpCookie("timesheetModel");

            var sessionTimesheet = JsonConvert.SerializeObject(timesheetModel);

            //httpCookie.Expires = DateTime.Now.AddTicks(tokenModel.expiresIn);
            httpCookie.HttpOnly = true;
            httpCookie.Value = sessionTimesheet;

            return httpCookie;
        }

        public static TimesheetModel RetornaTimesheet(HttpCookie httpCookie)
        {
            TimesheetModel timesheetModel = new TimesheetModel();

            timesheetModel = JsonConvert.DeserializeObject<TimesheetModel>(httpCookie.Value);

            return timesheetModel;
        }
    }
}