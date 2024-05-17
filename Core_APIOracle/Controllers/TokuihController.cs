using AutoMapper;
using DaihoWebAPI.Data;
using DaihoWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DaihoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TokuihController : ControllerBase
    {
        private readonly OraDbContext _context;
      
        private readonly ITokuihRepository tokuihRepository;
        private readonly IMapper mapper;
        public TokuihController(ITokuihRepository tokuihRepository , IMapper mapper, OraDbContext context)
        {
            this.tokuihRepository = tokuihRepository;
            this.mapper = mapper;
            _context = context;

        }
     

        [HttpGet]
        public async Task<IActionResult> GetAllTokuih()
        {
            var tokuih= await tokuihRepository.GetAllAsync();
            /*var tokuihDTOs = new List<Models.DTO.Tokuih>();
            tokuih.ToList().ForEach(tokuih =>
            {
                var tokuihDTO = new Models.DTO.Tokuih()
                {
                    ITM_CD = tokuih.ITM_CD,
                    CST_CD = tokuih.CST_CD,
                    CO_CD = tokuih.CO_CD,
                    CST_ITM_CD = tokuih.CST_ITM_CD,
                    CST_ITM_NM= tokuih.CST_ITM_NM
                };
                tokuihDTOs.Add(tokuihDTO);
            }); */
            var tokuihDTOs= mapper.Map<List<Models.DTO.Tokuih>>(tokuih);
            return Ok(tokuihDTOs);
        }

        [HttpGet]
        [Route("{ITM_CD}")]
        //[ActionName("GetTokuihAsync")]
        public async Task<IActionResult> GetTokuihAsync(string ITM_CD)
        {
            //var result = await (from b in _context.Tokuihs
            //                      where b.ITM_CD == ITM_CD
            //                      //orderby b.CItmCd
            //                      select b).ToListAsync();
            var result= await tokuihRepository.GetTokuihAsync(ITM_CD);
            return Ok(result);
           // return Ok();


        }
       /* [HttpPost]
        public async Task<IActionResult>AddTokuihAsync(Models.HM_TOKUIH_ALL tokuih)
        {
            await tokuihRepository.AddSync(tokuih);
            //return await tokuih(nameof(GetTokuihAsync), new {itm_cd=tokuih.ITM_CD},tokuih);

        }*/

    }
}
