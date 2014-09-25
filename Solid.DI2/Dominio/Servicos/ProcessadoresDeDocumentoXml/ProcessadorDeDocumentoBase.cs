namespace Solid.DI2.Dominio.Servicos.ProcessadoresDeDocumentoXml
{
    using System;
    using Entidades;
    using Validadores;

    public abstract class ProcessadorDeDocumentoBase : ProcessadorDeDocumento
    {
        public Fabrica<ValidadorDeDocumento, TipoDeDocumento> FabricaDeValidadorDeDocumento { get; set; }

        public virtual void Processar(string conteudo)
        {
            Console.WriteLine(conteudo);
        }
    }
}