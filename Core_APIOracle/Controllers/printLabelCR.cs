using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jp.co.fit.vfreport;
using jp.co.fit.UCXSingle;
using System.Text;

namespace Core_APIOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class printLabelCr : ControllerBase
    {
       
        private readonly HttpClient _httpClient;

        public printLabelCr()
        {
            // Initialize HttpClient directly
            _httpClient = new HttpClient();
        }
        [HttpPost]
        public async Task<IActionResult> printLabelSVF()
        {
            String host = "52.199.102.145";      // Universal Connect/X server host name
            int port = 44080;         // Universal Connect/X server port number
            String resultFileName = "D:/Project/apps/sample.pdf";  // Name of the output file to be generated
            String settingName = "JOB063";      // Job ID
            String sourceName = "C:/printLabel/sample_header_en.csv";  // Data file name

            UCXSingle ucs = new UCXSingle();

            try
            {
                // Convert the file name to a byte array using UTF-8 encoding
                byte[] fileNameBytes = Encoding.UTF8.GetBytes(resultFileName);
                string fileNameString = Encoding.UTF8.GetString(fileNameBytes);
                // Specifies the host name and port number of the Universal Connect/X server. 
                ucs.setUniConXServer(host, port);

                // Specifies the Job ID. 
                ucs.setSettingName(settingName);

                // Specifies the data file name. 
                ucs.setSourceName(sourceName);

                // Does not delete the data file when the process completes successfully. 
                ucs.setUndeleteSourceFile(true);

                // Does not delete the data file when the process terminates abnormally. 
                ucs.setUndeleteSourceFileIfError(true);
               
                // Specifies the name of the output file to be generated. 
                
                ucs.setResultFileName(fileNameString);
                ucs.setHeaderTransferEncodeSupported(true);

                // Runs a transaction according to the specified job settings. 
                ucs.doTransaction();

                // Displays the execution result of UCXSingle. 
                Console.WriteLine("UCXSingle execution result:  " + ucs.getUCXSingleResult());

                // Displays the execution result of Universal Connect/X. 
                Console.WriteLine("Universal Connect/X execution result:  " + ucs.getUniConXResult());

                // Retrieves a list of output files and displays the list. 
                Console.WriteLine("Output file list");
                int i = 0;
                foreach (string fname in ucs.getCreatedFileNameList())
                {
                    Console.WriteLine("[" + i + "]" + fname);
                    i++;
                }

                return Ok("ok");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }
     
        }
}
