namespace DI
{
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Dominio.Entidades;
    using Dominio.Servicos;
    using Dominio.Servicos.ProcessamentoDeDocumentos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

            var fabricaDeProcessadorDeDocumento = new Fabrica<ProcessadorDeDocumento, TipoDeDocumento>(container, new EspecificacaoPorTipoDeDocumento());
            container.Register(fabricaDeProcessadorDeDocumento.Registrar<ProcessadorDeNfce>(new TipoDeDocumento { TipoDoc = TipoDoc.NFCe }).LifestyleTransient());
            container.Register(fabricaDeProcessadorDeDocumento.Registrar<ProcessadorDeCte>(new TipoDeDocumento { TipoDoc = TipoDoc.CTe }).LifestyleTransient());

            container.Register(Component.For<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>().Instance(fabricaDeProcessadorDeDocumento));

            var f = container.Resolve<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>();
            var proc = f.Resolve(new TipoDeDocumento { TipoDoc = TipoDoc.CTe });
            var proc2 = f.Resolve(new TipoDeDocumento { TipoDoc = TipoDoc.CTe });
            proc2.Teste = "sdfsdfsd";
        }
    }

    public class Fabrica<TTipo, TCondicao> where TTipo : class
    {
        readonly WindsorContainer _container;
        readonly IDictionary<string, TCondicao> _registros;
        readonly IEspecificacao<TCondicao> _especificacao;

        public Fabrica(WindsorContainer container, IEspecificacao<TCondicao> especificacao)
        {
            _container = container;
            _registros = new Dictionary<string, TCondicao>();
            _especificacao = especificacao;
        }

        public ComponentRegistration<TTipo> Registrar<T>(TCondicao tipoDoc) where T : TTipo
        {
            var key = typeof(T).FullName;
            _registros.Add(key, tipoDoc);
            return Component.For<TTipo>().Named(key).ImplementedBy<T>();
        }

        public TTipo Resolve(TCondicao tipo)
        {
            var registro = _registros.FirstOrDefault(o => _especificacao.Comparar(o.Value, tipo));
            return _container.Resolve<TTipo>(registro.Key);
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

    public interface IEspecificacao<T>
    {
        bool Comparar(T item1, T item2);
    }

    public class EspecificacaoPorTipoDeDocumento : IEspecificacao<TipoDeDocumento>
    {
        public bool Comparar(TipoDeDocumento item1, TipoDeDocumento item2)
        {
            return item1.TipoDoc == item2.TipoDoc && ((item1.Versao != 0 && item1.Versao == item2.Versao) || (item1.Versao == 0));
        }
    }
}