using AutoMapper;
using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintMaterialLabelController : ControllerBase
    {
        private readonly IPrintLabelRepository printLabelRepository;

        [HttpGet]
        public async Task<IActionResult> getAllOrders()
        {
            var orders = await printLabelRepository.GetAllAsync();
         
            //var tokuihDTOs = mapper.Map<List<Models.DTO.Tokuih>>(tokuih);
            return Ok(orders);
        }
    }
}
