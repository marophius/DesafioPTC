using AutoMapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : MainController
    {
        private readonly IMarcaService _service;
        private readonly IMarcaRepository _repository;
        private readonly IMapper _mapper;

        public MarcaController(
            IMarcaService service, 
            IMarcaRepository repository,
            INotificador notificador,
            IMapper mapper) : base(notificador)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MarcaViewModel>>> ObterTodas()
        {
            var marcas = _mapper.Map<List<MarcaViewModel>>(await _repository.BuscarMarcasVeiculos());

            if(marcas == null) return NotFound();

            return Ok(marcas);

        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MarcaViewModel>> ObterPorId([FromRoute] Guid id)
        {
            try
            {
                if(id == Guid.Empty) return NotFound("O Id não pode ser nulo");

                var marca = _mapper.Map<MarcaViewModel>(await _repository.BuscarPorId(id));

                if (marca == null) return NotFound();

                return Ok(marca);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<MarcaViewModel>> ObterPorNome(string nome)
        {
            try
            {
                if (string.IsNullOrEmpty(nome)) return NotFound("O Id não pode ser nulo");

                var marca = _mapper.Map<MarcaViewModel>(await _repository.BuscarPorNome(nome));

                if (marca == null) return NotFound();

                return Ok(marca);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("somente-ativos")]
        public async Task<ActionResult<MarcaViewModel>> ObterMarcasAtivas()
        {
            try
            {
                var marcas = _mapper.Map<List<MarcaViewModel>>(await _repository.SomenteAtivos());

                if(marcas == null) return NotFound("Nenhuma marca encontrada!");

                return Ok(marcas);

            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<MarcaViewModel>> AdicionarMarca([FromBody] MarcaViewModel marca)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                await _service.Adicionar(_mapper.Map<Marca>(marca));

                return CustomResponse(marca);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<MarcaViewModel>> AlterarStatus(Guid id, MarcaViewModel marca)
        {
            try
            {
                if (id != marca.Id)
                {
                    NotificarErro("O Id informado não é o mesmo que foi passado na query");
                    return CustomResponse(marca);
                }

                if (!ModelState.IsValid) return CustomResponse(marca);

                if (marca.Status == EStatus.Ativo)
                {
                    var marcaCancelada = await _repository.CancelarStatus(marca.Id);
                    return CustomResponse(marcaCancelada);
                }

                var marcaAtiva = await _repository.AtivarStatus(marca.Id);
                return CustomResponse(marcaAtiva);

            }catch(Exception ex)
            {
                return NotFound("Nenhuma marca encontrada com este Id!");
            }
        }
    }
}
