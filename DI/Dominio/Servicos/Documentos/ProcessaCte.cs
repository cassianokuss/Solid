using DI.Dominio.Servicos.Documentos.Factorys;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;

namespace DI.Dominio.Servicos.Documentos
{
    public class ProcessaCte : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Cte> _ctes;
        private readonly INotificacao _notificacao;

        public ProcessaCte(IRepositorioBase<Cte> ctes, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.CTe);
            _ctes = ctes;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.CTe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = conteudo
                };

            _ctes.Armazenar(cte);
            _notificacao.Enviar("Cte enviado! " + conteudo);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.CTe;
        }
    }
}