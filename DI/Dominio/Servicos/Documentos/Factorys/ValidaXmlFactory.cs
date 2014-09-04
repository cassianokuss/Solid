namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Validacoes;
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
            return _validadores.FirstOrDefault(e => e.AplicavelQuando(tipo));
        }
    }
}
