using AutoMapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.Interfaces;
using Desafio.Domain.Notificacoes;
using Desafio.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoController : MainController
    {
        private readonly IVeiculoService _service;
        private readonly IVeiculoRepository _repository;
        private readonly IMapper _mapper;

        public VeiculoController(
            INotificador notificador,
            IVeiculoService service,
            IVeiculoRepository repositorio,
            IMapper mapper) : base(notificador)
        {
            _repository = repositorio;
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<VeiculoViewModel>>> ObterTodos()
        {
            var veiculos = _mapper.Map<List<VeiculoViewModel>>(await _repository.Buscar());

            if (veiculos == null) return NotFound();

            return Ok(veiculos);
        }

        [HttpGet("{id:guid}")]

        public async Task<ActionResult<VeiculoViewModel>> ObterPorId([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest("O Id não pode ser vazio!");

            var veiculo = _mapper.Map<VeiculoViewModel>(await _repository.BuscarPorId(id));

            if (veiculo == null) return NotFound("Nenhum veiculo encontrado");

            return Ok(veiculo);
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoViewModel>> AdicionarVeiculo(
            [FromBody] VeiculoViewModel veiculo
            )
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                await _service.Adicionar(_mapper.Map<Veiculo>(veiculo));

                return CustomResponse(veiculo);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Houve um erro interno de servidor!");
            }
        }

        [HttpPut("atualizar-veiculo/{id:guid}")]
        public async Task<ActionResult<ProprietarioViewModel>> AtualizarVeiculo(
            [FromRoute] Guid id,
            [FromBody] VeiculoViewModel veiculo
            )
        {
            if (id != veiculo.Id)
            {
                NotificarErro("O Id informado não é o mesmo que foi passado na query");
                return CustomResponse(veiculo);
            }

            if (!ModelState.IsValid) return CustomResponse(veiculo);

            await _service.Atualizar(_mapper.Map<Veiculo>(veiculo));

            return CustomResponse(veiculo);
        }
    }
}
