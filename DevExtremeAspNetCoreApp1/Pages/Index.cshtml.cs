using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeAspNetCoreApp1.Helpers;
using DevExtremeAspNetCoreApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DevExtremeAspNetCoreApp1.Pages {
    public class IndexModel : PageModel {
        public void OnGet() {

        }

        public IActionResult OnGetGet(DataSourceLoadOptions loadOptions)
        {
            return new JsonResult(DataSourceLoader.Load(SampleData.Orders, loadOptions));
        }

        public IActionResult OnPostAdd(string values)
        {
            var newItem = new SampleOrder();
            newItem.OrderID = (SampleData.Orders.Max(t => (int?)t.OrderID) ?? 0) + 1;

            JsonConvert.PopulateObject(values, newItem);

            SampleData.Orders.Add(newItem);

            return new OkObjectResult(newItem);
        }

        public IActionResult OnPutEdit(int key, string values)
        {
            var item = SampleData.Orders.Single(t => t.OrderID == key);

            JsonConvert.PopulateObject(values, item);

            return new OkObjectResult(item);
        }

        public IActionResult OnDeleteDelete(int key)
        {
            SampleData.Orders.RemoveAll(t => t.OrderID == key);

            return new OkResult();
        }

        public IActionResult OnGetExportCsv()
        {
            byte[] csvFile = Encoding.UTF8.GetBytes(SampleData.Orders.ToCsv());
            return new FileContentResult(csvFile, "text/csv");
        }
    }
}
