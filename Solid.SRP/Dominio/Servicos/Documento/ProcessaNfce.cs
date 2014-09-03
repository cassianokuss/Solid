using Solid.SRP.Infra;

namespace Solid.SRP.Dominio.Servicos.Documento
{
    using Entidades;
    using Repositorios;

    public class ProcessaNfce
    {
        private readonly ValidaXmlNfce _validacao;
        private readonly Nfces _Nfces;
        private readonly Email _email;

        public ProcessaNfce()
        {
            _validacao = new ValidaXmlNfce();
            _Nfces = new Nfces();
            _email = new Email();
        }

        public void Processar(DocumentoXml doc)
        {
            _validacao.Validar(doc.Conteudo);
            var nfce = new Nfce()
                {
                    PropriedadesDaNFCe = doc.Conteudo
                };

            _Nfces.ArmazenarNfce(nfce);
            _email.EnviarEmail("Nfce enviada! " + doc.Conteudo);
        }
    }
}