namespace DI.Dominio.Servicos.Documentos.Factorys
{
    using Validacoes;
    using Entidades;

    public interface IValidaXmlFactory
    {
        IValidaXml ObterValidador(TipoDocumento tipo);
    }
}
