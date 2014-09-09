namespace DI.Dominio.Servicos.Documentos.Validacoes
{
    public interface ValidadorDeXml : EstrategiaPorTipoDeDocumento
    {
        void Validar(string documento);
    }
}