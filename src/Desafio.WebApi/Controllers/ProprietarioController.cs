using AutoMapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Enums;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.Domain.ValueObject;
using Desafio.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Desafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : MainController
    {
        private readonly IProprietarioService _service;
        private readonly IProprietarioRepository _repository;
        private readonly IMapper _mapper;
        public ProprietarioController(
            INotificador notificador,
            IProprietarioService service,
            IProprietarioRepository repository,
            IMapper mapper) : base(notificador)
        {
            _service = service;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProprietarioViewModel>>> ObterTodos()
        {
            var proprietarios = _mapper.Map<List<ProprietarioViewModel>>(await _repository.Buscar());

            if (proprietarios == null) return NotFound("");

            return Ok(proprietarios);
        }

        [HttpGet("{id:guid}")]

        public async Task<ActionResult<ProprietarioViewModel>> ObterPorId([FromRoute]Guid id)
        {
            if (id == Guid.Empty) return BadRequest("O Id não pode ser vazio!");

            var proprietario = _mapper.Map<ProprietarioViewModel>(await _repository.BuscarPorId(id));

            if (proprietario == null) return NotFound("Nenhum proprietário encontrado");

            return Ok(proprietario);
        }

        [HttpGet("{documento:int}")]
        public async Task<ActionResult<ProprietarioViewModel>> ObterPorDocumento([FromRoute] int documento)
        {
            if (documento == 0) return BadRequest("O documento não pode ser vazio!");

            var proprietario = _mapper.Map<ProprietarioViewModel>(await _repository.BuscarPorDocumento(documento));

            if (proprietario == null) return NotFound("Nenhum proprietário encontrado");

            return Ok(proprietario);
        }

        [HttpGet("somente-ativos")]
        public async Task<ActionResult<ProprietarioViewModel>> ObterProprietariosAtivos()
        {
            try
            {
                var proprietarios = _mapper.Map<List<ProprietarioViewModel>>(await _repository.SomenteAtivos());

                if (proprietarios == null) return NotFound("Nenhuma proprietario encontrado!");

                return Ok(proprietarios);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Houve um erro interno de servidor!");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProprietarioViewModel>> AdicionarProprietario(
            [FromBody] ProprietarioViewModel proprietario
            )
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                await _service.Adicionar(_mapper.Map<Proprietario>(proprietario));

                return CustomResponse(proprietario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Houve um erro interno de servidor!");
            }
        }

        [HttpPut("alterar-status/{id:guid}")]
        public async Task<ActionResult<ProprietarioViewModel>> AlterarStatus(
            [FromRoute]Guid id, 
            [FromBody]ProprietarioViewModel proprietario
            )
        {
            try
            {
                if (id != proprietario.Id)
                {
                    NotificarErro("O Id informado não é o mesmo que foi passado na query");
                    return CustomResponse(proprietario);
                }

                if (!ModelState.IsValid) return CustomResponse(proprietario);

                if (proprietario.Status == EStatus.Ativo)
                {
                    var proprietarioCancelado = _mapper.Map<ProprietarioViewModel>(await _repository.CancelarStatus(id));
                    return CustomResponse(proprietarioCancelado);
                }

                var proprietarioAtivo = _mapper.Map<ProprietarioViewModel>(await _repository.AtivarStatus(id));
                return CustomResponse(proprietarioAtivo);

            }catch (Exception ex)
            {
                return NotFound("Nenhum proprietário encontrado com este Id");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> AtualizarProprietario(
            [FromRoute] Guid id,
            [FromBody] ProprietarioViewModel proprietario
            )
        {
            try
            {
                if (id != proprietario.Id)
                {
                    NotificarErro("O Id informado não é o mesmo que foi passado na query");
                    return CustomResponse(proprietario);
                }

                if (!ModelState.IsValid) return CustomResponse(proprietario);

                await _service.Atualizar(_mapper.Map<Proprietario>(proprietario));

                return Ok("Proprietário atualizado!");

            }catch (Exception ex)
            {
                return NotFound("Nenhum proprietário encontrado!");
            }
        }
    }
}
