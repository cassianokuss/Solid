namespace DI.Dominio.Servicos.Documento.Factory
{
    using System.Linq;
    using Entidades;

    public class ValidaXmlFactory : IValidaXmlFactory
    {
        private readonly IValidaXml[] _validadores;

        public ValidaXmlFactory(params IValidaXml[] validadores)
        {
            _validadores = validadores;
        }

        public IValidaXml ObterValidador(TipoDocumento tipo)
        {
            return _validadores.FirstOrDefault(e => e.ValidarQuando(tipo));
        }
    }
}
