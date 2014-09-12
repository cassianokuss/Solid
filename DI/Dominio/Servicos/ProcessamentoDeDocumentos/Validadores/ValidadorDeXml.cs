namespace DI.Dominio.Servicos.ProcessamentoDeDocumentos.Validadores
{
    public interface ValidadorDeXml : EstrategiaPorTipoDeDocumento
    {
        void Validar(string documento);
    }
}