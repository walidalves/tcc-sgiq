using Sgiq.Dados.Models;
using Sgiq.Negocio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sgiq.Negocio.Servicos
{
    class ProjetoBo:NegocioBase
    {
        


        public ProjetoBo(): base()
        {
            
        }

        public IEnumerable<ProjetoListarViewModel> Listar()
        {
            var projetos = this.Db.Projeto.AsEnumerable();

            var projetosVm = new List<ProjetoListarViewModel>();

            var result = Db.Projeto.AsQueryable().AsEnumerable();

            
            foreach (var projeto in result)
            {
                var cliente = projeto.PartesInteressadasProjeto.Where(pi => pi.Papel.Nome.ToLower() == "cliente").FirstOrDefault();
                var gerenteProjetos = projeto.PartesInteressadasProjeto.Where(pi => pi.Papel.Nome.ToLower() == "gerente de projetos").FirstOrDefault();
                var projetoVM = new ProjetoListarViewModel {
                    Id = projeto.ProjetoId,
                    Nome = projeto.Nome,
                    Cliente = cliente.ParteInteressada.Nome,
                    GerenteProjeto = gerenteProjetos.ParteInteressada.Nome,
                    Situacao = projeto.SituacaoProjeto.Nome
                };
            }

            return projetosVm;
        }
    }
}
