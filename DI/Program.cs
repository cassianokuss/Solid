namespace DI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel;
    using Castle.MicroKernel.Context;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Dominio.Repositorios;
    using Dominio.Entidades;
    using Dominio.Servicos;
    using Dominio.Servicos.ProcessamentoDeDocumentos;
    using Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas;
    using Dominio.Servicos.ProcessamentoDeDocumentos.Notificadores;
    using Dominio.Servicos.ProcessamentoDeDocumentos.Validadores;
    using Component = Castle.MicroKernel.Registration.Component;

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

        static void ConfigurarDI()
        {
            //_container = new WindsorContainer();
            /*
            _container.Kernel.Resolver.AddSubResolver(new ArrayResolver(_container.Kernel));

            _container
                .Register(Component.For<Repositorio<Nfe>>().ImplementedBy<RepositorioBase<Nfe>>())
                .Register(Component.For<Repositorio<Nfce>>().ImplementedBy<RepositorioBase<Nfce>>())
                .Register(Component.For<Repositorio<Cte>>().ImplementedBy<RepositorioBase<Cte>>())

                .Register(Component.For<Processa>().ImplementedBy<ProcessaImpl>().LifeStyle.Singleton)
                .Register(Component.For<FabricaDeProcessadorDeDocumento>().ImplementedBy<FabricaDeProcessadorDeDocumentoImpl>().LifeStyle.Singleton)
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeNfe>())
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeNfce>())
                .Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeCte>())

                .Register(Component.For<FabricaDeValidadorDeXml>().ImplementedBy<FabricaDeValidadorDeXmlImpl>().LifeStyle.Singleton)
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlNfe>())
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlNfce>())
                .Register(Component.For<ValidadorDeXml>().ImplementedBy<ValidadorDeXmlCte>())

                .Register(Component.For<FabricaDeNotificador>().ImplementedBy<FabricaDeNotificadorImpl>().LifeStyle.Singleton)
                .Register(Component.For<Notificador>().ImplementedBy<NotificadorPorEmail>())
                .Register(Component.For<Notificador>().ImplementedBy<NotificadorPorSms>());*/

            var container = new WindsorContainer();

            // var fabricaDeProcessadorDeDocumento = new FabricaImpl<ProcessadorDeDocumento, TipoDocumento>(container, new EspecificacaoPorTipoDeDocumento());
            // fabricaDeProcessadorDeDocumento.Register<ProcessadorDeNfe>(TipoDocumento.NFe);

            container.Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeNfe>().UsingFactoryMethod((x, b, c) => Fabrica.Obter(new TipoDeDocumento { TipoDoc = TipoDoc.NFe, Versao = 1 }, container, c)));
            container.Register(Component.For<ProcessadorDeDocumento>().ImplementedBy<ProcessadorDeCte>().UsingFactoryMethod((x, b, c) => Fabrica.Obter(new TipoDeDocumento { TipoDoc = TipoDoc.CTe, Versao = 1 }, container, c)));

            var a = container.Resolve<ProcessadorDeDocumento>(new TipoDeDocumento { TipoDoc = TipoDoc.NFe, Versao = 1 });

        }
    }

    public class Fabrica
    {
        public static ProcessadorDeDocumento Obter(TipoDeDocumento tipo, WindsorContainer container, CreationContext context)
        {
            if (tipo == null)
            {
                return container.Resolve<ProcessadorDeNfe>();
            }

            return container.Resolve<ProcessadorDeCte>();
        }
    }

    public class TipoDeDocumento
    {
        public TipoDoc TipoDoc { get; set; }
        public int Versao { get; set; }
    }

    public enum TipoDoc
    {
        NFe,
        NFCe,
        CTe
    }
}
