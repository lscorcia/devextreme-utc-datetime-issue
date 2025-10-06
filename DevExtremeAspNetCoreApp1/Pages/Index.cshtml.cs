using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeAspNetCoreApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevExtremeAspNetCoreApp1.Pages {
    public class IndexModel : PageModel {
        public void OnGet() {

        }

        public IActionResult OnGetGet(DataSourceLoadOptions loadOptions)
        {
            return new JsonResult(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

        public IActionResult OnGetExportCsv()
        {
            byte[] csvFile = Encoding.UTF8.GetBytes(SampleData.Orders.ToCsv());
            return new FileContentResult(csvFile, "text/csv");
        }
    }
}
