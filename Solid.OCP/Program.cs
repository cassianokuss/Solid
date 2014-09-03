namespace Solid.OCP
{
    using Dominio.Entidades;
    using Dominio.Servicos;

    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            // Receber documento, validar, armazenar e enviar mensagem notificando

            IList<DocumentoXml> documentos = new List<DocumentoXml>();

            documentos.Add(new DocumentoXml()
            {
                Tipo = TipoDocumento.NFe,
                Conteudo = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFe>
"
            });

            documentos.Add(new DocumentoXml()
            {
                Tipo = TipoDocumento.NFCe,
                Conteudo = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFCe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</NFCe>
"
            });

            documentos.Add(new DocumentoXml()
            {
                Tipo = TipoDocumento.CTe,
                Conteudo = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<CTe>
    <Numero>123</Numero>
    <Valor>12345,67</Valor>
</CTe>
"
            });

            foreach (var documento in documentos)
            {
                ProcessaDocumento.Instancia(documento.Tipo).Processar(documento.Conteudo);
            }

            Console.ReadKey();
        }
    }
}
