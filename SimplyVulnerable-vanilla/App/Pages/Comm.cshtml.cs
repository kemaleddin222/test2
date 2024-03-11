using App.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Net.Http;
using System;
using System.Diagnostics;
using System.Xml;


namespace App.Pages
{
    public class CommModel : PageModel
    {
        private readonly ILogger<CommModel> _logger;

        private readonly IDBWrite _db;


        public CommModel(ILogger<CommModel> logger, IDBWrite db)
        {
            _logger = logger;
            IDBWrite _db = db;


        }


// open red.
        public void OnPost()
        {
          XmlDocument parser = new XmlDocument();
          parser.XmlResolver = new XmlUrlResolver(); // Noncompliant
          parser.LoadXml("xxe.xml");
        }


// ssrf
        public void OnGet()
        {
            String response = _db.WriteToDB(Request.Form["some_value"]);

            String name = Request.Query["some_value"];
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = name;
            p.Start();
        }
    }
}