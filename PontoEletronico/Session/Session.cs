﻿using System;
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
    }
}