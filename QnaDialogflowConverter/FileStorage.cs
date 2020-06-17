using Newtonsoft.Json;
using System;
using System.IO;

namespace LTRSimulation.Infrastructure.Files
{
    public class FileStorage
    {        
        public static void Write<T>(T entity, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(entity, Formatting.Indented);

            using (var writer = File.CreateText(fileName))
            {
                writer.Write(jsonString);
            }
        }
    }
}
