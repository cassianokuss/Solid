using DI.Dominio.Servicos.Documento.Validacoes;

namespace DI.Dominio.Servicos.Documento.Factory
{
    using Entidades;

    public interface IValidaXmlFactory
    {
        IValidaXml ObterValidador(TipoDocumento tipo);
    }
}
