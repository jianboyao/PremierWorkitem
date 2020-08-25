using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PremierWorkitem.Pages
{
    public class testModel : PageModel
    {
        public IActionResult OnGet(string type,string caseid)
        {
            
            var blogs = System.IO.File.ReadAllText("Blogs/blogs.json", System.Text.Encoding.UTF8);
            var articles = JsonConvert.DeserializeObject<List<Article>>(blogs);
            var caselog = System.IO.File.ReadAllText("Blogs/caseAndlog.json", System.Text.Encoding.UTF8);
            var caselogEntity = JsonConvert.DeserializeObject<List<CaseDetail>>(caselog);
            if (caselogEntity!=null)
            {
                caseDetail = caselogEntity.First();
            }
           
            if (caselogEntity.Where(c => c.CaseId == caseid).Count() <= 0)
            {
                return NotFound();
            }
            article = articles.Find(c => c.subType == type);
            return Page();
        
        }
        public string Header = "日志收集方式";
        public Article article;
        public CaseDetail caseDetail;
       
  
    }
    public class Article
    {
        public string Title;
        public List<Des> Content;
        public DateTime dateTime;
        public string type;
        public string subType;

    }
  
    public class Des
    {
        public int index { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
    }
    public enum LogType
    {
        IIS_log

    }
    public class CaseDetail
    {
        public string CaseId { get; set; }
        public List<string> logTypes { get; set; }
        public string description { get; set; }
        public string createDate { get; set; }
    }
    public class logDescription { 
    
    }
}
