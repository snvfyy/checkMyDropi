using CheckMyDropi.Api.Core.DTOs;
using CheckMyDropi.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckMyDropi.Api.Core
{
    public class UrlCheck
    {
        private readonly DroppyContext _context;

        public UrlCheck(DroppyContext context)
        {
            _context = context;
        }


       
    }
}
