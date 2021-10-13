//@CodeCopy
//MdStart
using CommonBase.Extensions;
using CSharpCodeGenerator.Logic.Contracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.Logic
{
    public static class Generator
    {
        public static IEnumerable<IGeneratedItem> Generate(string solutionName, string contractsFilePath, Common.UnitType appUnitTypes)
        {
            var result = new ConcurrentBag<IGeneratedItem>();
            var entityGenerator = Factory.GetEntityGenerator(solutionName, contractsFilePath);
            var dataContextGenerator = Factory.GetDataContextGenerator(solutionName, contractsFilePath);
            var controllerGenerator = Factory.GetControllerGenerator(solutionName, contractsFilePath);
            var factoryGenerator = Factory.GetFactoryGenerator(solutionName, contractsFilePath);
            var transferGenerator = Factory.GetTransferGenerator(solutionName, contractsFilePath);
            var aspMvcGenerator = Factory.GetAspMvcGenerator(solutionName, contractsFilePath);
            var tasks = new List<Task>();

            #region Logic
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Business-Entities...");
                generatedItems.AddRange(entityGenerator.CreateBusinessEntities());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Modules-Entities...");
                generatedItems.AddRange(entityGenerator.CreateModulesEntities());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Persistence-Entities...");
                generatedItems.AddRange(entityGenerator.CreatePersistenceEntities());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Shadow-Entities...");
                generatedItems.AddRange(entityGenerator.CreateShadowEntities());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Business-Controllers...");
                generatedItems.AddRange(controllerGenerator.CreateBusinessControllers());
                result.AddRangeSafe(generatedItems);
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Persistence-Controllers...");
                generatedItems.AddRange(controllerGenerator.CreatePersistenceControllers());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Shadow-Controllers...");
                generatedItems.AddRange(controllerGenerator.CreateShadowControllers());
                result.AddRangeSafe(generatedItems);
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItem = default(IGeneratedItem);

                Console.WriteLine("Create Factory...");
                generatedItem = factoryGenerator.CreateLogicFactory();
                result.AddSafe(generatedItem);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItem = default(IGeneratedItem);

                Console.WriteLine("Create DataContext-DbContext...");
                generatedItem = dataContextGenerator.CreateDbContext();
                result.Add(generatedItem);
            }));
            #endregion Logic

            #region Transfer
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Transfer-Business...");
                generatedItems.AddRange(transferGenerator.CreateBusinessModels());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Transfer-Modules...");
                generatedItems.AddRange(transferGenerator.CreateModulesModels());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Transfer-Persistence...");
                generatedItems.AddRange(transferGenerator.CreatePersistenceModels());
                result.AddRangeSafe(generatedItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create Transfer-Shadow...");
                generatedItems.AddRange(transferGenerator.CreateShadowModels());
                result.AddRangeSafe(generatedItems);
            }));
            #endregion Transfer

            #region Adapters
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItem = default(IGeneratedItem);

                Console.WriteLine("Create Adapters-Factory...");
                generatedItem = factoryGenerator.CreateAdapterFactory();
                result.AddSafe(generatedItem);
            }));
            #endregion Adapters 

            #region WebApi
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var generatedItems = new List<IGeneratedItem>();

                Console.WriteLine("Create WebApi-Controllers...");
                generatedItems.AddRange(controllerGenerator.CreateWebApiControllers());
                result.AddRangeSafe(generatedItems);
            }));
            #endregion WebApi

            #region AspMvc
            if ((appUnitTypes & Common.UnitType.AspMvc) > 0)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var generatedItems = new List<IGeneratedItem>();

                    Console.WriteLine("Create AspMvc-Business-Models...");
                    generatedItems.AddRange(aspMvcGenerator.CreateBusinessModels());
                    result.AddRangeSafe(generatedItems);
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var generatedItems = new List<IGeneratedItem>();

                    Console.WriteLine("Create AspMvc-Modules-Models...");
                    generatedItems.AddRange(aspMvcGenerator.CreateModulesModels());
                    result.AddRangeSafe(generatedItems);
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var generatedItems = new List<IGeneratedItem>();

                    Console.WriteLine("Create AspMvc-Persistence-Models...");
                    generatedItems.AddRange(aspMvcGenerator.CreatePersistenceModels());
                    result.AddRangeSafe(generatedItems);
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var generatedItems = new List<IGeneratedItem>();

                    Console.WriteLine("Create AspMvc-Shadow-Models...");
                    generatedItems.AddRange(aspMvcGenerator.CreateShadowModels());
                    result.AddRangeSafe(generatedItems);
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    var generatedItems = new List<IGeneratedItem>();

                    Console.WriteLine("Create AspMvc-Controllers...");
                    generatedItems.AddRange(controllerGenerator.CreateAspMvcControllers());
                    result.AddRangeSafe(generatedItems);
                }));
            }
            #endregion AspMvc

            Task.WaitAll(tasks.ToArray());
            return result;
        }

        public static void DeleteGenerationFiles(string path)
        {
            Console.WriteLine("Delete all generation files...");
            foreach (var searchPattern in Logic.StaticLiterals.SourceFileExtensions.Split("|"))
            {
                var deleteFiles = GetGenerationFiles(path, searchPattern, new[] { StaticLiterals.GeneratedCodeLabel });

                foreach (var item in deleteFiles)
                {
                    File.Delete(item);
                }
            }
        }
        private static IEnumerable<string> GetGenerationFiles(string path, string searchPattern, string[] labels)
        {
            var result = new List<string>();

            foreach (var file in Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories))
            {
                var lines = File.ReadAllLines(file, Encoding.Default);

                if (lines.Any() && labels.Any(l => lines.First().Contains(l)))
                {

                    result.Add(file);
                }
            }
            return result;
        }
    }
}
//MdEnd
