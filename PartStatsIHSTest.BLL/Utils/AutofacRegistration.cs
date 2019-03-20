using PartStatsIHSTest.BLL.Factories;
using PartStatsIHSTest.BLL.Interfacies;
using Autofac;


namespace PartStatsIHSTest.BLL.Utils
{
    public class AutofacRegistration
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileSystemManager>();
            builder.RegisterType<HttpFileManager>();
            builder.RegisterType<FileReaderFactory>().As<IFileReaderFactory>();
            builder.RegisterType<ManagerFactory>().As<IManagerFactory>();
            builder.RegisterType<FileValidate>().As<IFileValidate>();
            return builder.Build();
        }
    }
}
