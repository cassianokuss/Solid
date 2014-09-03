using Solid.SRP.Infra;

namespace Solid.SRP.Dominio.Servicos.Documento
{
    using Entidades;
    using Repositorios;

    public class ProcessaCte
    {
        private readonly ValidaXmlCte _validacao;
        private readonly Ctes _ctes;
        private readonly Email _email;

        public ProcessaCte()
        {
            _validacao = new ValidaXmlCte();
            _ctes = new Ctes();
            _email = new Email();
        }

        public void Processar(DocumentoXml doc)
        {
            _validacao.Validar(doc.Conteudo);
            var cte = new Cte()
                {
                    PropriedadesDoCTe = doc.Conteudo
                };

            _ctes.ArmazenarCte(cte);
            _email.EnviarEmail("Cte enviado! " + doc.Conteudo);
        }
    }
}