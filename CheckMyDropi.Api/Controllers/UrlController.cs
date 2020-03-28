using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CheckMyDropi.Api.Core.DTOs;
using CheckMyDropi.Api.Data.Context;
using CheckMyDropi.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckMyDropi.Api.Controllers
{
    [Route("api/v1/url")]
    public class UrlController : Controller
    {

        private readonly DroppyContext _context;
        public UrlController(DroppyContext context) : base()
        {
            _context = context;
        }


        [HttpGet]
        [Route("Test")]
        public async Task<ActionResult> Test()
        {
            MaliciousLink link = new MaliciousLink() { IdMaliciousLink = 1, Url = "test link" };
            await _context.MaliciousLink.AddAsync(link);
            _context.SaveChanges();
            return Json(link);

        }
        [HttpGet]
        [Route("{url}/check")]
        public async Task<UrlStatusDTO> CheckUrl(string url)
        {
            var result = await _context.MaliciousLink.Where(x => url.Equals(x.Url)).ToListAsync();
            if (result == null || !result.Any())
            {
                return new UrlStatusDTO(true, 0, url, false);
            }

            return new UrlStatusDTO(true, result.First().IdMaliciousLink, url, true);
        }
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult> All()
        {
            var urls = await _context.MaliciousLink.ToListAsync();
            return Json(urls);
        }
        [HttpGet]
        [Route("Update")]
        public IActionResult Update()
        {
            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/littl3field/DodgyDomainsBot/master/COVID-Dodgy-Domains.txt");
            string strContent = null;
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                strContent = reader.ReadToEnd();
            }
            Console.WriteLine(strContent);
            string[] news = strContent.Split('\n');
            foreach (string n in news)
            {
                if (!_context.MaliciousLink.Where(x => x.Url == n).Any())
               {
                    _context.MaliciousLink.Add(new Data.Entities.MaliciousLink() { Url = n });
                }
            }
            //_context.MaliciousLink.Add(new Data.Entities.MaliciousLink() { Url=});
            _context.SaveChanges();
            return new StatusCodeResult(202);
        }

    }
}