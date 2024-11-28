﻿using PicPayChallenge.Domain.DTOs;
using PicPayChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Application.DTOs
{
    public class ClientResult : IClientResult
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
        public string Cpf { get ; set ; }
        public string Email { get ; set ; }

        public static ClientResult FromDomain(Client client)
        {
            return new ClientResult
            {
                Id = client.Id,
                Cpf = client.Cpf,
                Name = client.Name,
                Email = client.Email,
            };
        }
    }
}