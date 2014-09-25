namespace Solid.DI2
{
    using Dominio.Entidades;
    using Dominio.Servicos.ProcessadoresDeDocumentoXml;
    using Dominio.Servicos.Validadores;
    using SimpleInjector;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var container = new Container();

            var fabricaDeProcessadorDeDocumento = new FabricaImpl<ProcessadorDeDocumento, TipoDeDocumento>(container, new EspecificacaoPorTipoDeDocumento());
            fabricaDeProcessadorDeDocumento.Register<ProcessadorDeDocumentoNfe>(new TipoDeDocumento { TipoDoc = TipoDoc.NFe });
            fabricaDeProcessadorDeDocumento.Register<ProcessadorDeDocumentoCte>(new TipoDeDocumento { TipoDoc = TipoDoc.CTe });

            container.RegisterInitializer<ProcessadorDeDocumentoBase>(p => p.FabricaDeValidadorDeDocumento = container.GetInstance<Fabrica<ValidadorDeDocumento, TipoDeDocumento>>());

            var fabricaDeValidadoresDeDocumento = new FabricaImpl<ValidadorDeDocumento, TipoDeDocumento>(container, new EspecificacaoPorTipoDeDocumento());
            fabricaDeValidadoresDeDocumento.Register<ValidadorDeDocumentoNfe>(new TipoDeDocumento { TipoDoc = TipoDoc.NFe });
            fabricaDeValidadoresDeDocumento.Register<ValidadorDeDocumentoCteVersao1>(new TipoDeDocumento { TipoDoc = TipoDoc.NFe, Versao = 1 });
            fabricaDeValidadoresDeDocumento.Register<ValidadorDeDocumentoCteVersao2>(new TipoDeDocumento { TipoDoc = TipoDoc.NFe, Versao = 2 });

            container.RegisterSingle<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>(fabricaDeProcessadorDeDocumento);
            container.RegisterSingle<Fabrica<ValidadorDeDocumento, TipoDeDocumento>>(fabricaDeValidadoresDeDocumento);

            var fab = container.GetInstance<Fabrica<ProcessadorDeDocumento, TipoDeDocumento>>();

            var xxx = fab.CriarInstancia(new TipoDeDocumento { TipoDoc = TipoDoc.NFe, Versao = 1 });
            xxx.Processar("Teste");
        }
    }

    public interface Fabrica<TTipo, TCondicao>
    {
        TTipo CriarInstancia(TCondicao tipo);
    }

    public class FabricaImpl<TTipo, TCondicao> : Fabrica<TTipo, TCondicao>
        where TTipo : class
    {
        private readonly Dictionary<TCondicao, InstanceProducer> _producers = new Dictionary<TCondicao, InstanceProducer>();
        private readonly Container _container;
        private readonly IEspecificacao<TCondicao> _especificacao;

        public FabricaImpl(Container container, IEspecificacao<TCondicao> especificacao)
        {
            _container = container;
            _especificacao = especificacao;
        }

        public TTipo CriarInstancia(TCondicao tipo)
        {
            var key = _producers.Keys.FirstOrDefault(o => _especificacao.Comparar(o, tipo));
            return (TTipo)_producers[key].GetInstance();
        }

        public void Register<T1>(TCondicao tipo, Lifestyle lifestyle = null) where T1 : class, TTipo
        {
            lifestyle = lifestyle ?? Lifestyle.Transient;

            var registration = lifestyle.CreateRegistration<TTipo, T1>(_container);

            var producer = new InstanceProducer(typeof(Fabrica<TTipo, TCondicao>), registration);

            _producers.Add(tipo, producer);
        }
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
