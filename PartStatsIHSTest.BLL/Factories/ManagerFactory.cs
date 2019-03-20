using System;
using System.Collections.Generic;
using Autofac;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Utils;

namespace PartStatsIHSTest.BLL.Factories
{
    public class ManagerFactory : IManagerFactory
    {
        private Dictionary<string, IFileManager> managers;

        public ManagerFactory()
        {
            IContainer container = AutofacRegistration.Build();

            managers = new Dictionary<string, IFileManager>();
            managers.Add(Constans.FileSystem, container.Resolve<FileSystemManager>());
            managers.Add(Constans.Http, container.Resolve<HttpFileManager>());
        }

        public IFileManager Create(string context)
        {
            if (managers.ContainsKey(context))
                return managers[context];

            throw new Exception("File manager not found");
        }
    }
}
