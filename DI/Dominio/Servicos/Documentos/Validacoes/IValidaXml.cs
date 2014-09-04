namespace DI.Dominio.Servicos.Documento.Validacoes
{
    using Entidades;

    public interface IValidaXml
    {
        void Validar(string documento);
        bool ValidarQuando(TipoDocumento tipo);
    }
}