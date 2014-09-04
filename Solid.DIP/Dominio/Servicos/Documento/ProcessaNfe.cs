namespace Solid.DIP.Dominio.Servicos.Documento
{
    using Entidades;
    using Infra;
    using Repositorios;

    public class ProcessaNfe : ProcessaDocumento
    {
        private readonly ValidaXmlNfe _validacao;
        private readonly Nfes _nfes;
        private readonly Notificacao _notificacao;

        public ProcessaNfe()
        {
            _validacao = new ValidaXmlNfe();
            _nfes = new Nfes();
            _notificacao = new Email();
        }

        public override void Processar(string conteudo)
        {
            _validacao.Validar(conteudo);
            var nfe = new Nfe()
                {
                    PropriedadesDaNFe = conteudo
                };

            _nfes.ArmazenarNfe(nfe);
            _notificacao.Enviar("NFe enviada! " + conteudo);
        }
    }
}