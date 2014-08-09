﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using GistClient.FileSystem;
using RestSharp;
using RestSharp.Deserializers;

namespace GistClient.Client
{
    public static class GistClient
    {
        private static readonly RestClient Client;

        static GistClient(){
            Client =  new RestClient("https://api.github.com");
        }

        public static Dictionary<String,String> SendRequest(RestRequest request){
            var response = Client.Execute(request);
            HandleResponse(response);
            var deserializer = new JsonDeserializer();
            var jsonResponse = deserializer.Deserialize<Dictionary<String, String>>(response);
            return jsonResponse;
        }

        public static void SetAuthentication(String username, String password){
            Client.Authenticator = new HttpBasicAuthenticator(username,password.Decrypt());
        }

        public static void HandleResponse(IRestResponse response){
            var firstOrDefault = response.Headers.FirstOrDefault(x => x.Name == "Status");
            var statusValue = firstOrDefault.Value.ToString();
            if (!statusValue.Contains("201")){
                throw new Exception(statusValue);
            }
        }
    }
}
