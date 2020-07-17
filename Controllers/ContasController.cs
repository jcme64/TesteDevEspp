using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ExameApi.Models;
using ExameApi.Repository;
using System;
using System.Threading.Tasks;

namespace ExameApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    // [Authorize]
    public class ContasController : ControllerBase		
	{
		IContasRepository contasRepository;

		public ContasController(IContasRepository _contasRepository)
		{
            contasRepository = _contasRepository;
		}

        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> Obter(int idCliente)
        {
            try
            {
                var data = await contasRepository.GetAllByIdCliente(idCliente);

                if (data == null)
                {
                    var resultNotFound = new
                    {
                        code = 20000,
                        data = new {}
                    };
                    return Ok(resultNotFound);
                }
                else
                {
                    var result = new
                    {
                        code = 20000,
                        data 
                    };

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("IncluirConta")]
        public async Task<IActionResult> Add([FromBody] Conta model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await contasRepository.Add(model);
                    if (Id > 0)
                    {
                        var result = new
                        {

                            code = 20000,
                            data = new
                            {
                                id = Id,
                                mesage = "success"
                            }
                        };

                        return Ok(result);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

    }
}
