using DI.Dominio.Servicos.Documentos.Factorys;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;

namespace DI.Dominio.Servicos.Documentos
{
    public class ProcessaNfce : IProcessaDocumento
    {
        private readonly IValidaXml _validacao;
        private readonly IRepositorioBase<Nfce> _nfces;
        private readonly INotificacao _notificacao;

        public ProcessaNfce(IRepositorioBase<Nfce> nfces, IValidaXmlFactory validaXmlFactory, INotificacaoFactory notificacaoFactory)
        {
            _validacao = validaXmlFactory.ObterValidador(TipoDocumento.NFCe);
            _nfces = nfces;
            _notificacao = notificacaoFactory.ObterNotificacao(TipoDocumento.NFCe);
        }

        public void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = conteudo
                };

            _nfces.Armazenar(nfce);
            _notificacao.Enviar("Nfce enviada! " + conteudo);
        }

        public bool AplicavelQuando(TipoDocumento tipo)
        {
            return tipo == TipoDocumento.NFCe;
        }
    }
}