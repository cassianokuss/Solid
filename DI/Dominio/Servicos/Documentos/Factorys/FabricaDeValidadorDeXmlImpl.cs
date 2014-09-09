namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Validacoes;
    using System.Linq;
    using Entidades;

    public class FabricaDeValidadorDeXmlImpl : FabricaDeValidadorDeXml
    {
        private readonly ValidadorDeXml[] _validadores;

        public FabricaDeValidadorDeXmlImpl(params ValidadorDeXml[] validadores)
        {
            _validadores = validadores;
        }

        public ValidadorDeXml ObterValidador(TipoDocumento tipo)
        {
            return _validadores.FirstOrDefault(e => e.AplicarQuando(tipo));
        }
    }
}
