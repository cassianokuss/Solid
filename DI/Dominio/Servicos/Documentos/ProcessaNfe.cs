using DI.Dominio.Servicos.Documentos.Factorys;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;

namespace DI.Dominio.Servicos.Documentos
{
    public class ProcessaNfe : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Nfe> _nfes;
        private readonly INotificacao _notificacao;

        public ProcessaNfe(IRepositorioBase<Nfe> nfes, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.NFe);
            _nfes = nfes;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.NFe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfe = new Nfe()
                {
                    PropriedadesDaNFe = conteudo
                };

            _nfes.Armazenar(nfe);
            _notificacao.Enviar("NFe enviada! " + conteudo);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFe;
        }
    }
}