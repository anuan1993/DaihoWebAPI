using Core_APIOracle.Models;

using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DaihoWebAPI.Models;

namespace DaihoWebAPI.Utilities
{
    public class Helper
    {
        public static void PrintPdf(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' does not exist.");
            }

            // Start the process to print the PDF
            string filepath3 = @"C:\Users\robby\Downloads\TSMA_SUGIN_MAR.pdf";
            string printerName = "FF K553p for DocuCentre-IV C2263 PCL 6";
            try
            {
                // Path to your batch file
                string batchFilePath = @"C:\printLabel\start.bat";

                // Create a new process start info
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe", // The command prompt
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                // Start the process
                Process process = new Process { StartInfo = processStartInfo };
                process.Start();

                // Pass the path to the batch file to the command prompt
                process.StandardInput.WriteLine(batchFilePath);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Wait for the process to exit
                process.WaitForExit();

                // Check the exit code
                int exitCode = process.ExitCode;
                if (exitCode == 0)
                {
                    // Success
                    Console.WriteLine ("Batch file executed successfully.");
                }
                else
                {
                    // Error
                    Console.WriteLine( "Error executing batch file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine( $"An error occurred: {ex.Message}");
            }
        }

        public static string CreateHtmlTableFromEntity(MANUFACTURE_PRINT_LABEL entity)
        {
            // Start building the HTML table
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append("<table>");

            // Add table headers
            htmlBuilder.Append("<tr>");
            htmlBuilder.Append("<th>Column 1</th>");
            htmlBuilder.Append("<th>Column 2</th>");
            // Add more headers for each property in the entity
            // Example: htmlBuilder.Append("<th>" + entity.PropertyName + "</th>");
            htmlBuilder.Append("</tr>");

            // Add table row with entity data
            htmlBuilder.Append("<tr>");
            htmlBuilder.Append("<td>" + entity.PRINT_ID_H + "</td>");
            htmlBuilder.Append("<td>" + entity.ITM_CD + "</td>");
            // Add more cells for each property in the entity
            // Example: htmlBuilder.Append("<td>" + entity.PropertyName + "</td>");
            htmlBuilder.Append("</tr>");

            // Close the table
            htmlBuilder.Append("</table>");

            // Return the HTML table string
            return htmlBuilder.ToString();
        }

       

        public class ByteArrayConverter : JsonConverter<byte[]>
        {
            public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return Convert.FromBase64String(reader.GetString());
            }

            public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(Convert.ToBase64String(value));
            }
        }

       
    }
}
