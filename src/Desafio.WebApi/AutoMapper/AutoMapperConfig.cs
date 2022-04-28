using AutoMapper;
using Desafio.Domain.Entidades;
using Desafio.Domain.ValueObject;
using Desafio.WebApi.ViewModels;

namespace Desafio.WebApi.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Domain to VM
            CreateMap<Marca, MarcaViewModel>()
                .ForMember(d => d.Nome, o => o.MapFrom(s => s.Nome.Valor));
            CreateMap<Proprietario, ProprietarioViewModel>()
                .ForMember(d => d.Nome, o => o.MapFrom(s => s.Nome.Valor))
                .ForMember(d => d.City, o => o.MapFrom(s => s.Endereco.City))
                .ForMember(d => d.Cep, o => o.MapFrom(s => s.Endereco.Cep))
                .ForMember(d => d.State, o => o.MapFrom(s => s.Endereco.State))
                .ForMember(d => d.Street, o => o.MapFrom(s => s.Endereco.Street))
                .ForMember(d => d.Service, o => o.MapFrom(s => s.Endereco.Service))
                .ForMember(d => d.NeighborHood, o => o.MapFrom(s => s.Endereco.NeighborHood));
            CreateMap<Veiculo, VeiculoViewModel>();

            // VM to Domain
            CreateMap<MarcaViewModel, Marca>()
                .ConstructUsing(p => new Marca(new Nome(p.Nome), p.Status));
            CreateMap<ProprietarioViewModel, Proprietario>()
                .ConstructUsing(p => new Proprietario(new Nome(p.Nome), p.Documento, p.Email, new Endereco(p.Cep, p.State, p.NeighborHood, p.Street, p.Service, p.City), p.Status));
            CreateMap<VeiculoViewModel, Veiculo>()
                .ConstructUsing(p => new Veiculo(p.ProprietarioId, p.Renavam, p.MarcaId, p.Modelo, p.AnoFabricacao, p.AnoModelo, p.Quilometragem, p.Valor, p.Status));

        }
    }
}
