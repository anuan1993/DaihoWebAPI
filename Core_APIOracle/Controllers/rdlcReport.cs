using Core_APIOracle.Models;
using DaihoWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Reporting.WebForms;
using System.Data;
using System.Text;
using System.Web;

namespace Core_APIOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class rdlcReport : ControllerBase
    {
        private readonly OraDbContext _context;
        public rdlcReport(OraDbContext context)
        {
            _context = context;
        }

        [HttpGet("GenerateReport")]
 
        public async Task<IActionResult> Get(string PROD_ITM_GRP_CD)
        {
            try
            {
                // Fetch data from your data source (e.g., database)
                var products = await (from b in _context.Products
                                      where b.PROD_ITM_GRP_CD == PROD_ITM_GRP_CD
                                      orderby b.ITM_CD
                                      select b).Take(10).ToListAsync();

                // Convert data to HTML string for printing
                string htmlContent = ConvertDataToHtml(products);

                // Return the HTML content as response
                return Content(htmlContent, "text/html");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to generate report: {ex.Message}");
            }
        }

        private async Task<DataTable> FetchData(string PROD_ITM_GRP_CD)
        {
            // Fetch data from your data source (e.g., database)
            var products = await (from b in _context.Products
                                  where b.PROD_ITM_GRP_CD == PROD_ITM_GRP_CD
                                  orderby b.ITM_CD
                                  select b).Take(10).ToListAsync(); 

            // Create DataTable and define columns
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ITM_CD", typeof(string)); // Adjust column types as needed
            dataTable.Columns.Add("ITM_NM", typeof(string)); // Adjust column types as needed
            // Add more columns as needed

            // Populate DataTable with query results
            foreach (var product in products)
            {
                dataTable.Rows.Add(product.ITM_CD, product.ITM_NM); // Adjust column names as needed
                // Add more columns as needed
            }

            return dataTable;
        }

        private string ConvertDataToHtml(IEnumerable<ProductsInfo> products)
        {
            // Create HTML string
            StringBuilder htmlBuilder = new StringBuilder();

            // Add HTML header
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html lang=\"en\">");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("<meta charset=\"UTF-8\">");
            htmlBuilder.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            htmlBuilder.AppendLine("<title>Product Report</title>");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body>");

            // Add table to display product data
            htmlBuilder.AppendLine("<table border=\"1\">");
            htmlBuilder.AppendLine("<tr>");
            htmlBuilder.AppendLine("<th>ITM_CD</th>");
            htmlBuilder.AppendLine("<th>ITM_NM</th>");
            // Add more table headers as needed
            htmlBuilder.AppendLine("</tr>");

            // Add rows for each product
            foreach (var product in products)
            {
                htmlBuilder.AppendLine("<tr>");
                htmlBuilder.AppendLine($"<td>{product.ITM_CD}</td>");
                htmlBuilder.AppendLine($"<td>{product.ITM_NM}</td>");
                // Add more table cells for other properties
                htmlBuilder.AppendLine("</tr>");
            }

            // Close table and HTML body
            htmlBuilder.AppendLine("</table>");
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            return htmlBuilder.ToString();
        }
    }

    
}

