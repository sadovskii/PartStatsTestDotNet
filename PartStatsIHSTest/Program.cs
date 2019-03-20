using Autofac;
using PartStatsIHSTest.BLL.Factories;
using PartStatsIHSTest.BLL.Interfacies;
using PartStatsIHSTest.BLL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PartStatsIHSTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var param1 = string.Empty;
            var param2 = string.Empty;

            if (args.Length >= 2)
            {
                param1 = args[0];
                param2 = args[1];
            }
            else
            {
                Console.WriteLine("Укажите параметры:");
                Console.Write("<input_mode>");
                param1 = Console.ReadLine();
                Console.Write("<input_address>");
                param2 = Console.ReadLine();
            }

            IContainer container = AutofacRegistration.Build();
            var app = container.Resolve<IManagerFactory>();

            var fileManager = app.Create(param1);
            fileManager.Work(param2);

            Console.WriteLine(Resource.WorkCompleted);

            if (fileManager.Exceptions != null && fileManager.Exceptions.Count != 0)
            {
                Console.WriteLine(Resource.ErrorList);
                foreach (var a in fileManager.Exceptions)
                    Console.WriteLine(a.Message);
            }

            Console.ReadKey();
        }
    }
}
