﻿//@CodeCopy
//MdStart
using CSharpCodeGenerator.Logic.Common;
using CSharpCodeGenerator.Logic.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeGenerator.ConApp
{
    internal partial class Writer
    {
        #region Class-Constructors
        static Writer()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        #endregion Class-Constructors
        public static bool WriteToGroupFile { get; set; } = true;
        public static void WriteAll(string solutionPath, ISolutionProperties solutionProperties, IEnumerable<IGeneratedItem> generatedItems)
        {
            solutionPath.CheckNotNullOrEmpty(nameof(solutionPath));
            solutionProperties.CheckArgument(nameof(solutionProperties));
            generatedItems.CheckArgument(nameof(generatedItems));

            var tasks = new List<Task>();

            #region WriteLogicCode
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.BusinessEntity);

                Console.WriteLine("Write Logic-Business-Entities...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.ModuleEntity);

                Console.WriteLine("Write Logic-Modules-Entities...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.PersistenceEntity);

                Console.WriteLine("Write Logic-Persistence-Entities...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.ShadowEntity);

                Console.WriteLine("Write Logic-Shadow-Entities...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItem = generatedItems.Single(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.DbContext);

                Console.WriteLine("Write Logic-DataContext-DbContext...");
                WriteItems(projectPath, new IGeneratedItem[] { writeItem });
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.LogicBusinessController);

                Console.WriteLine("Write Logic-Business-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.LogicPersistenceController);

                Console.WriteLine("Write Logic-Persistence-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.LogicShadowController);

                Console.WriteLine("Write Logic-Shadow-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.LogicProjectName);
                var writeItem = generatedItems.Single(e => e.UnitType == UnitType.Logic && e.ItemType == ItemType.Factory);

                Console.WriteLine("Write Logic-Factory...");
                WriteItems(projectPath, new IGeneratedItem[] { writeItem });
            }));
            #endregion WriteLogicCode

            #region WriteTransfer
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.TransferProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Transfer && e.ItemType == ItemType.BusinessModel);

                Console.WriteLine("Write Transfer-Business-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.TransferProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Transfer && e.ItemType == ItemType.ModuleModel);

                Console.WriteLine("Write Transfer-Modules-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.TransferProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Transfer && e.ItemType == ItemType.PersistenceModel);

                Console.WriteLine("Write Transfer-Persistence-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.TransferProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Transfer && e.ItemType == ItemType.ShadowModel);

                Console.WriteLine("Write Transfer-Shadow-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.TransferProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Transfer && e.ItemType == ItemType.ThridPartyModel);

                Console.WriteLine("Write Transfer-ThirdParty-Models...");
                WriteItems(projectPath, writeItems);
            }));
            #endregion WriteTansfer

            #region WriteAdapter
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AdaptersProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.Adapters && e.ItemType == ItemType.Factory);

                Console.WriteLine("Write Adapters-Factory...");
                WriteItems(projectPath, writeItems);
            }));
            #endregion WriteTransfer

            #region WriteWebApi
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.WebApiProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.WebApi && e.ItemType == ItemType.WebApiBusinessController);

                Console.WriteLine("Write WebApi-Business-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.WebApiProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.WebApi && e.ItemType == ItemType.WebApiPersistenceController);

                Console.WriteLine("Write WebApi-Persistence-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.WebApiProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.WebApi && e.ItemType == ItemType.WebApiShadowController);

                Console.WriteLine("Write WebApi-Shadow-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            #endregion WriteWebApi

            #region AspMvc
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.BusinessModel);

                Console.WriteLine("Write AspMvc-Business-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.ModuleModel);

                Console.WriteLine("Write AspMvc-Modules-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.PersistenceModel);

                Console.WriteLine("Write AspMvc-Persistence-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.ShadowModel);

                Console.WriteLine("Write AspMvc-Shadow-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.ThridPartyModel);

                Console.WriteLine("Write AspMvc-ThridParty-Models...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.AspMvcBusinessController);

                Console.WriteLine("Write AspMvc-Business-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.AspMvcPersistenceController);

                Console.WriteLine("Write AspMvc-Persistence-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            tasks.Add(Task.Factory.StartNew(() =>
            {
                var projectPath = Path.Combine(solutionPath, solutionProperties.AspMvcProjectName);
                var writeItems = generatedItems.Where(e => e.UnitType == UnitType.AspMvc && e.ItemType == ItemType.AspMvcShadowController);

                Console.WriteLine("Write AspMvc-Shadow-Controllers...");
                WriteItems(projectPath, writeItems);
            }));
            #endregion AspMvc

            Task.WaitAll(tasks.ToArray());
        }

        #region Create translations
        private record Translation(string AppName, string KeyLanguage, string Key, string ValueLanguage, string Value);
        private static Translation ToTranslation(string line, string separator)
        {
            var data = line.Split(separator);
            return new Translation(data[0], data[1], data[2], data[3], data[4]);
        }
        private static string ToCsv(Translation translation, string separator)
        {
            return $"{translation.AppName}{separator}{translation.KeyLanguage}{separator}{translation.Key}{separator}{translation.ValueLanguage}{separator}{translation.Value}";
        }
        public static void WriteTranslations(string solutionPath, IGeneratedItem generatedItem)
        {
            generatedItem.CheckArgument(nameof(generatedItem));

            var separator = ";";
            var fileName = $"{generatedItem.FullName}{generatedItem.FileExtension}";
            var filePath = Path.Combine(solutionPath, fileName);
            var resultItems = new List<Translation>();

            if (File.Exists(filePath))
            {
                resultItems.AddRange(File.ReadAllLines(filePath).Select(l => ToTranslation(l, separator)));
            }
            foreach (var line in generatedItem.SourceCode)
            {
                var entry = ToTranslation(line, separator);
                var existEntry = resultItems.FirstOrDefault(e => e.AppName.Equals(entry.AppName)
                                                              && e.KeyLanguage.Equals(entry.KeyLanguage)
                                                              && e.Key.Equals(entry.Key));

                if (existEntry == null)
                {
                    resultItems.Add(entry);
                }
            }
            File.WriteAllLines(filePath, resultItems.Select(t => ToCsv(t, separator)), Encoding.Default);
        }
        #endregion Create translations

        #region Create properties
        private record Property(string AppName, string EntityName, string PropertyName, string Attribute, string Value);
        private static string ToCsv(Property property, string separator)
        {
            return $"{property.AppName}{separator}{property.EntityName}{separator}{property.PropertyName}{separator}{property.Attribute}{separator}{property.Value}";
        }

        private static Property ToProperty(string line, string separator)
        {
            var data = line.Split(separator);
            return new Property(data[0], data[1], data[2], data[3], data[4]);
        }
        public static void WriteProperties(string solutionPath, IGeneratedItem generatedItem)
        {
            generatedItem.CheckArgument(nameof(generatedItem));

            var separator = ";";
            var fileName = $"{generatedItem.FullName}{generatedItem.FileExtension}";
            var filePath = Path.Combine(solutionPath, fileName);
            var resultItems = new List<Property>();

            if (File.Exists(filePath))
            {
                resultItems.AddRange(File.ReadAllLines(filePath).Select(l => ToProperty(l, separator)));
            }

            foreach (var line in generatedItem.SourceCode)
            {
                var entry = ToProperty(line, separator);
                var existEntry = resultItems.FirstOrDefault(e => e.AppName.Equals(entry.AppName)
                                                              && e.EntityName.Equals(entry.EntityName)
                                                              && e.PropertyName.Equals(entry.PropertyName)
                                                              && e.Attribute.Equals(entry.Attribute));

                if (existEntry == null)
                {
                    resultItems.Add(entry);
                }
            }
            File.WriteAllLines(filePath, resultItems.Select(p => ToCsv(p, separator)), Encoding.Default);
        }
        #endregion Create properties

        #region Write methods
        public static void WriteItems(string projectPath, IEnumerable<IGeneratedItem> generatedItems)
        {
            if (WriteToGroupFile)
            {
                WriteGeneratedCodeFile(projectPath, StaticLiterals.GeneratedCodeFileName, generatedItems);
            }
            else
            {
                WriteCodeFiles(projectPath, generatedItems);
            }
        }
        public static void WriteGeneratedCodeFile(string projectPath, string fileName, IEnumerable<IGeneratedItem> generatedItems)
        {
            generatedItems.CheckArgument(nameof(generatedItems));

            if (generatedItems.Any())
            {
                var idx = 0;
                var count = generatedItems.Count();
                var subPath = new StringBuilder();
                var subPaths = generatedItems.Select(e => Path.GetDirectoryName(e.SubFilePath));
                var minSubPath = subPaths.MinBy(e => e.Length);

                minSubPath ??= String.Empty;

                while (idx < minSubPath.Length
                       && count == generatedItems.Where(e => idx < e.SubFilePath.Length && e.SubFilePath[idx] == minSubPath[idx]).Count())
                {
                    subPath.Append(minSubPath[idx++]);
                }

                var fullFilePath = default(string);

                if (subPath.Length == 0)
                    fullFilePath = Path.Combine(projectPath, fileName);
                else
                    fullFilePath = Path.Combine(projectPath, subPath.ToString(), fileName);

                WriteGeneratedCodeFile(fullFilePath, generatedItems);
            }
        }
        public static void WriteGeneratedCodeFile(string fullFilePath, IEnumerable<IGeneratedItem> generatedItems)
        {
            generatedItems.CheckArgument(nameof(generatedItems));

            var lines = new List<string>();
            var directory = Path.GetDirectoryName(fullFilePath);

            foreach (var item in generatedItems)
            {
                lines.AddRange(item.SourceCode);
            }

            if (lines.Any())
            {
                var sourceLines = new List<string>(lines);

                if (Directory.Exists(directory) == false)
                {
                    Directory.CreateDirectory(directory);
                }

                sourceLines.Insert(0, $"//{StaticLiterals.GeneratedCodeLabel}");
                File.WriteAllLines(fullFilePath, sourceLines);
            }
        }
        public static void WriteCodeFiles(string projectPath, IEnumerable<IGeneratedItem> generatedItems)
        {
            generatedItems.CheckArgument(nameof(generatedItems));

            foreach (var item in generatedItems)
            {
                var sourceLines = new List<string>(item.SourceCode);
                var filePath = Path.Combine(projectPath, item.SubFilePath);

                sourceLines.Insert(0, $"//{StaticLiterals.GeneratedCodeLabel}");
                WriteCodeFile(filePath, sourceLines);
            }
        }
        public static void WriteCodeFile(string filePath, IEnumerable<string> source)
        {
            source.CheckArgument(nameof(source));

            var canCreate = true;
            var path = Path.GetDirectoryName(filePath);
            var generatedCode = StaticLiterals.GeneratedCodeLabel;

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                var header = lines.FirstOrDefault(l => l.Contains(StaticLiterals.GeneratedCodeLabel)
                                  || l.Contains(StaticLiterals.CustomizedAndGeneratedCodeLabel));

                if (header != null)
                {
                    File.Delete(filePath);
                }
                else
                {
                    canCreate = false;
                }
            }
            else if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            if (canCreate && source.Any())
            {
                File.WriteAllLines(filePath, source);
            }
        }
        #endregion Write methods
    }
}
//MdEnd
