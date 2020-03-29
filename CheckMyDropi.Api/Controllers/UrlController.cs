using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CheckMyDropi.Api.Core.DTOs;
using CheckMyDropi.Api.Data.Context;
using CheckMyDropi.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CheckMyDropi.Api.Controllers
{
    [Route("api/v1/url")]
    public class UrlController : Controller
    {

        private readonly DroppyContext _context;
        private readonly ILogger<HomeController> _logger;
        public UrlController(DroppyContext context, ILogger<HomeController> logger) : base()
        {
            _context = context;
            _logger = logger;
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
            _logger.LogInformation("{0} - Updating database {1}", DateTime.Now,HttpContext.TraceIdentifier);
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            var webRequest = WebRequest.Create(@"https://raw.githubusercontent.com/littl3field/DodgyDomainsBot/master/COVID-Dodgy-Domains.txt");
            string strContent = null;
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var reader = new StreamReader(content))
            {
                strContent = reader.ReadToEnd();
            }
            //Console.WriteLine(strContent);
            string[] news = strContent.Split('\n');
            foreach (string n in news)
            {
                if (!_context.MaliciousLink.Where(x => x.Url == n).Any())
               {
                    _context.MaliciousLink.Add(new Data.Entities.MaliciousLink() { Url = n, Created = DateTime.Now });
                }
            }
            //_context.MaliciousLink.Add(new Data.Entities.MaliciousLink() { Url=});
            stopwatch.Stop();
            
            _context.SaveChanges();
            _logger.LogInformation("{0} - Updating database elapsed {2} {1}", DateTime.Now,HttpContext.TraceIdentifier, stopwatch.Elapsed);
            return new StatusCodeResult(202);
        }

    }
}