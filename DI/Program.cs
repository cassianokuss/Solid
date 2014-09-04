using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using DI.Dominio.Repositorios;
using DI.Dominio.Servicos.Documento;
using DI.Dominio.Servicos.Documento.Factory;
using DI.Dominio.Servicos.Documento.Validacoes;
using DI.Infra;
using DI.Infra.Notificaoes;

namespace DI
{
    using Dominio.Entidades;
    using Dominio.Servicos;

    using System;
    using System.Collections.Generic;

    class Program
    {
        private static IWindsorContainer _container;

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

            ConfigurarDI();

            foreach (var documento in documentos)
            {
                _container.Resolve<IProcessa>().ProcessarDocumento(documento);
            }

            Console.ReadKey();
        }

        private static void ConfigurarDI()
        {
            _container = new WindsorContainer();
            _container.Kernel.Resolver.AddSubResolver(new ArrayResolver(_container.Kernel));

            _container
                .Register(Component.For<IRepositorioBase<Nfe>>().ImplementedBy<RepositorioBase<Nfe>>())
                .Register(Component.For<IRepositorioBase<Nfce>>().ImplementedBy<RepositorioBase<Nfce>>())
                .Register(Component.For<IRepositorioBase<Cte>>().ImplementedBy<RepositorioBase<Cte>>())

                .Register(Component.For<IProcessa>().ImplementedBy<Processa>())
                .Register(Component.For<IProcessaDocumentoFactory>().ImplementedBy<ProcessaDocumentoFactory>())
                .Register(Component.For<IProcessaDocumento>().ImplementedBy<ProcessaNfe>())
                .Register(Component.For<IProcessaDocumento>().ImplementedBy<ProcessaNfce>())
                .Register(Component.For<IProcessaDocumento>().ImplementedBy<ProcessaCte>())

                .Register(Component.For<IValidaXmlFactory>().ImplementedBy<ValidaXmlFactory>())
                .Register(Component.For<IValidaXml>().ImplementedBy<ValidaXmlNfe>())
                .Register(Component.For<IValidaXml>().ImplementedBy<ValidaXmlNfce>())
                .Register(Component.For<IValidaXml>().ImplementedBy<ValidaXmlCte>())

                .Register(Component.For<INotificacaoFactory>().ImplementedBy<NotificacaoFactory>())
                .Register(Component.For<INotificacao>().ImplementedBy<Email>())
                .Register(Component.For<INotificacao>().ImplementedBy<Sms>());
        }
    }
}
