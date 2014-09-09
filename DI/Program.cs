namespace DI
{
    using System;
    using System.Collections.Generic;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Dominio.Repositorios;
    using Infra.Notificaoes;
    using Dominio.Entidades;
    using Dominio.Servicos;
    using Dominio.Servicos.Documentos;
    using Dominio.Servicos.Documentos.Factorys;
    using Dominio.Servicos.Documentos.Validacoes;

    class Program
    {
        private static IWindsorContainer _container;

        static void Main(string[] args)
        {
            // Receber documento, validar, armazenar e enviar mensagem notificando

            #region Documentos
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
                Tipo = TipoDocumento.NFe,
                Conteudo = @"
<?xml version=""1.0"" encoding=""UTF-8"" ?> 
<NFxe>
    <Numero>999</Numero>
    <Valor>99999,67</Valor>
</NFxe>
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

            #endregion

            ConfigurarDI();

            foreach (var documento in documentos)
            {
                try
                {
                    _container.Resolve<Processa>().ProcessarDocumento(documento);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("****************" + ex.Message + "****************\n");
                }
            }

            Console.ReadKey();
        }

        private static void ConfigurarDI()
        {
            _container = new WindsorContainer();
            _container.Kernel.Resolver.AddSubResolver(new ArrayResolver(_container.Kernel));

            _container
                .Register(Component.For<Repositorio<Nfe>>().ImplementedBy<RepositorioBase<Nfe>>())
                .Register(Component.For<Repositorio<Nfce>>().ImplementedBy<RepositorioBase<Nfce>>())
                .Register(Component.For<Repositorio<Cte>>().ImplementedBy<RepositorioBase<Cte>>())

                .Register(Component.For<Processa>().ImplementedBy<ProcessaImpl>().LifeStyle.Singleton)
                .Register(Component.For<IProcessadorDeDocumentoFactory>().ImplementedBy<FabricaDeProcessadorDeDocumentoImpl>().LifeStyle.Singleton)
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeNfe>())
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeNfce>())
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeCte>())

                .Register(Component.For<FabricaDeValidadorDeXml>().ImplementedBy<FabricaDeValidadorDeXmlImpl>().LifeStyle.Singleton)
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlNfe>())
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlNfce>())
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlCte>())

                .Register(Component.For<FabricaDeNotificador>().ImplementedBy<FabricaDeNotificadorImpl>().LifeStyle.Singleton)
                .Register(Component.For<INotificacao>().ImplementedBy<Email>())
                .Register(Component.For<INotificacao>().ImplementedBy<Sms>());
        }
    }
}
