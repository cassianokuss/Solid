using Solid.SRP.Infra;

namespace Solid.SRP.Dominio.Servicos.Documento
{
    using Entidades;
    using Repositorios;

    public class ProcessaNfe
    {
        private readonly ValidaXmlNfe _validacao;
        private readonly Nfes _nfes;
        private readonly Email _email;

        public ProcessaNfe()
        {
            _validacao = new ValidaXmlNfe();
            _nfes = new Nfes();
            _email = new Email();
        }

        public void Processar(DocumentoXml doc)
        {
            _validacao.Validar(doc.Conteudo);
            var nfe = new Nfe()
                {
                    PropriedadesDaNFe = doc.Conteudo
                };

            _nfes.ArmazenarNfe(nfe);
            _email.EnviarEmail("NFe enviada! " + doc.Conteudo);
        }
    }
}