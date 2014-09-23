namespace Solid.DI2.Dominio.Servicos.Processadores
{
    using System;

    public abstract class ProcessadorDeDocumentoBase : ProcessadorDeDocumento
    {
        public virtual void Processar(string conteudo)
        {
            Console.WriteLine(conteudo);
        }
    }
}