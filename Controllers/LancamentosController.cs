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
    public class LancamentosController : ControllerBase
    {
        ILancamentosRepository lancamentosRepository;

        public LancamentosController(ILancamentosRepository _lancamentosRepository)
        {
            lancamentosRepository = _lancamentosRepository;
        }

        [HttpGet]
        [Route("Obter")]
        public async Task<IActionResult> Obter(int idConta)
        {
            try
            {
                var data = await lancamentosRepository.GetAllByIdConta(idConta);

                if (data == null)
                {
                    var resultNotFound = new
                    {
                        code = 20000,
                        data = new { }
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
        [Route("IncluirLancamento")]
        public async Task<IActionResult> Add([FromBody] Lancamento model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await lancamentosRepository.Add(model);
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
