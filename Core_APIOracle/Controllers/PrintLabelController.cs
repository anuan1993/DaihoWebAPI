using Core_APIOracle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using DaihoWebAPI.Data;
using System.Drawing;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Authorization;

namespace Core_APIOracle.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    
    public class PrintLabelController : ControllerBase
    {
        private readonly OraDbContext _context;

        public PrintLabelController(OraDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await (from b in _context.MANUFACTURE_PRINT_LABEL
                                    //   where b.CST_CD == custCD
                                orderby b.PRINT_ID_H
                                select b).ToListAsync();

            #region
            // Define the CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Column1,Column2,Column3"); // Add headers

            foreach (var item in result)
            {
                csvContent.AppendLine($"{item.ITM_CD},{item.PRINT_DT},{item.PRINT_LOC}"); // Add data rows
            }
            // Convert the CSV content to bytes
            var csvBytes = Encoding.UTF8.GetBytes(csvContent.ToString());
            // Write the CSV content to a file at the specified path
            string filePath = @"C:\printLabel\manufacture_print_label.csv"; // Specify your desired path here
            System.IO.File.WriteAllBytes(filePath, csvBytes);

            // Return the file for download
            var memoryStream = new MemoryStream(csvBytes);
            File(memoryStream, "text/csv", "manufacture_print_label.csv");

            //string filepath = @"D:\Project\startNotepat.bat";
            //string filepath2 = @"D:\Project\apps\ConsoleApplication1.exe";

            //System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo
            //{
            //    FileName = filepath2,
            //    Verb = "runas" // This specifies that the process should be started with elevated privileges
            //};

            //try
            //{
            //    System.Diagnostics.Process.Start(processStartInfo);
            //    //string filepath3 = @"C:\Project\apps\sample.pdf";
            //    string filepath3 = @"C:\Users\robby\Downloads\TSMA_SUGIN_MAR.pdf";
            //    string printerName = "FF K553p for DocuCentre-IV C2263 PCL 6";
            //    DaihoWebAPI.Utilities.Helper.PrintPdf(filepath3, printerName);
            //   // PrintPdf( filepath3,printerName);
            //    return Ok();

            //}
            //catch (System.ComponentModel.Win32Exception ex)
            //{
            //    // Handle the exception, e.g., display an error message
            //    Console.WriteLine($"Error: {ex.Message}");
            //    return StatusCode(500); // Return an HTTP 500 error response
            //}                         
            #endregion
            return Ok(result);

        }

        [HttpGet]
        [Route("/Controller/printById")]
        public async Task<IActionResult> Get(string id)
        {
            var manufacturePrintLabels = await _context.MANUFACTURE_PRINT_LABEL
             .Where(item => item.PRINT_ID_H == id) // Assuming Id is the primary key property
             .ToListAsync();
            // Define the CSV content
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Column1,Column2,Column3"); // Add headers

            foreach (var item in manufacturePrintLabels)
            {
                csvContent.AppendLine($"{item.ITM_CD},{item.PRINT_DT},{item.PRINT_LOC}"); // Add data rows
            }
            // Convert the CSV content to bytes
            var csvBytes = Encoding.UTF8.GetBytes(csvContent.ToString());
            // Write the CSV content to a file at the specified path
            string filePath = @"C:\printLabel\manufacture_print_label.csv"; // Specify your desired path here
            System.IO.File.WriteAllBytes(filePath, csvBytes);

            // Return the file for download
            var memoryStream = new MemoryStream(csvBytes);
            File(memoryStream, "text/csv", "manufacture_print_label.csv");

            if (manufacturePrintLabels == null)
            {
                return NotFound(); // Return 404 Not Found if the record with the given ID is not found
            }

            return Ok(manufacturePrintLabels); // Return the found record
        }

        [HttpPost]
        public async Task<IActionResult> Post(MANUFACTURE_PRINT_LABEL MANUFACTURE_PRINT_LABEL)
        {
            var result = await _context.MANUFACTURE_PRINT_LABEL.AddAsync(MANUFACTURE_PRINT_LABEL);
            await _context.SaveChangesAsync();

            // Retrieve the added entity from the context
            var addedEntity = result.Entity;

            // Create HTML table from the entity data
            string htmlTable = DaihoWebAPI.Utilities.Helper.CreateHtmlTableFromEntity(addedEntity);

            // Convert HTML table to PDF
            //byte[] pdfBytes = DaihoWebAPI.Utilities.Helper.ConvertHtmlToPdf(htmlTable);

            // Return the PDF content as a file download
            string filePath = @"C:\printLabel\manufacture_print_label.pdf"; // Specify your desired path here
            //System.IO.File.WriteAllBytes(filePath, pdfBytes);
            DaihoWebAPI.Utilities.Helper.PrintPdf(filePath);
            //string filepath2 = @"D:\Project\apps\ConsoleApplication1.exe";
            //string filepath = @"C:\printLabel\startNotepat.bat";

            //   string str_Path = Server.MapPath(".") + "\\execute.bat";

            /*  System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo
              {
                  FileName = filepath,
                  Verb = "runas" // This specifies that the process should be started with elevated privileges
              };

              try
              {
                  ProcessStartInfo processInfo = new ProcessStartInfo(filepath);
                  processInfo.UseShellExecute = false;
                  Process batchProcess = new Process();
                  batchProcess.StartInfo = processInfo;
                  batchProcess.Start();
                  //   System.Diagnostics.Process.Start(processStartInfo);
                  //string filepath3 = @"C:\Project\apps\sample.pdf";
                  //string filepath3 = @"C:\Users\robby\Downloads\TSMA_SUGIN_MAR.pdf";
                  //string printerName = "FF K553p for DocuCentre-IV C2263 PCL 6";
                  //  DaihoWebAPI.Utilities.Helper.PrintPdf(filepath3, printerName);
                  // PrintPdf( filepath3,printerName);
                  return Ok();

              }
              catch (System.ComponentModel.Win32Exception ex)
              {
                  // Handle the exception, e.g., display an error message
                  Console.WriteLine($"Error: {ex.Message}");
                  return StatusCode(500); // Return an HTTP 500 error response
              }
              //return Ok(result.Entity);*/


            //return Content(htmlTable, "text/html");

            return Ok(result.Entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMANUFACTURE_PRINT_LABEL(string id, MANUFACTURE_PRINT_LABEL mANUFACTURE_PRINT_LABEL)
        {
            if (id != mANUFACTURE_PRINT_LABEL.PRINT_ID_H)
            {
                return BadRequest();
            }

            _context.Entry(mANUFACTURE_PRINT_LABEL).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MANUFACTURE_PRINT_LABELExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> MANUFACTURE_PRINT_LABEL(string id)
        {
            var existingCity = await _context.MANUFACTURE_PRINT_LABEL.FirstOrDefaultAsync(x => x.PRINT_ID_H == id);
            if (existingCity == null)
            {
                return null;
            }

            _context.MANUFACTURE_PRINT_LABEL.Remove(existingCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
       
        private bool MANUFACTURE_PRINT_LABELExists(string id)
        {
            return _context.MANUFACTURE_PRINT_LABEL.Any(e => e.PRINT_ID_H == id);
        }
    }
}
