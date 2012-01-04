﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HttpServer;

namespace Rests
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username">Username to verify</param>
    /// <param name="password">Password to verify</param>
    /// <returns>Returning a restobject with a null error means a successful verification.</returns>
    public delegate RestObject VerifyD(string username, string password);
    public class SecureRest : Rest
    {
        public Dictionary<string, object> Tokens { get; protected set; }
        public event VerifyD Verify;
        public SecureRest(IPAddress ip, int port)
            : base(ip, port)
        {
            Tokens = new Dictionary<string, object>();
            Register(new RestCommand("/token/create/{username}/{password}", NewToken) { RequiresToken = false });
            Register(new RestCommand("/token/destroy/{token}", DestroyToken) { RequiresToken = true });
        }

        object DestroyToken(RestVerbs verbs, IParameterCollection parameters)
        {
            var token = verbs["token"];
            try
            {
                Tokens.Remove(token);
            }
            catch (Exception)
            {
                return new Dictionary<string, string> { { "status", "400" }, { "error", "The specified token queued for destruction failed to be deleted." } };
            }
            return new Dictionary<string, string> { { "status", "200" }, { "response", "Requested token was successfully destroyed." } };
        }

        object NewToken(RestVerbs verbs, IParameterCollection parameters)
        {
            var user = verbs["username"];
            var pass = verbs["password"];

            RestObject obj = null;
            if (Verify != null)
                obj = Verify(user, pass);

            if (obj == null)
                obj = new RestObject("401") { Error = "Invalid username/password combination provided. Please re-submit your query with a correct pair." };

            if (obj.Error != null)
                return obj;

            string hash;
            var rand = new Random();
            var randbytes = new byte[32];
            do
            {
                rand.NextBytes(randbytes);
                hash = randbytes.Aggregate("", (s, b) => s + b.ToString("X2"));
            } while (Tokens.ContainsKey(hash));

            Tokens.Add(hash, user);

            obj["token"] = hash;
            return obj;
        }



        protected override object ExecuteCommand(RestCommand cmd, RestVerbs verbs, IParameterCollection parms)
        {
            if (cmd.RequiresToken)
            {
                var strtoken = parms["token"];
                if (strtoken == null)
                    return new Dictionary<string, string> { { "status", "401" }, { "error", "Not authorized. The specified API endpoint requires a token." } };

                object token;
                if (!Tokens.TryGetValue(strtoken, out token))
                    return new Dictionary<string, string> { { "status", "403" }, { "error", "Not authorized. The specified API endpoint requires a token, but the provided token was not valid." } };
            }
            return base.ExecuteCommand(cmd, verbs, parms);
        }
    }
}
