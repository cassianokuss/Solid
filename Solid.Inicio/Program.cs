using System;
using System.Collections.Generic;

namespace Solid.Inicio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Receber documento, validar, armazenar e enviar mensagem notificando

            #region Documentos
            IList<Documento> documentos = new List<Documento>();

            documentos.Add(new Documento()
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

            documentos.Add(new Documento()
            {
                Tipo = TipoDocumento.NFe,
                Conteudo = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFxe>
    <Numero>999</Numero>
    <Valor>99999,67</Valor>
</NFxe>
"
            });

            documentos.Add(new Documento()
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

            documentos.Add(new Documento()
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

            #endregion

            var processaDocumento = new ProcessaDocumento();

            foreach (var documento in documentos)
            {
                processaDocumento.Processar(documento);
            }

            Console.ReadKey();
        }
    }
}
