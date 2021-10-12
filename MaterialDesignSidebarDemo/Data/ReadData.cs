using System.IO;
using System.Linq;
using System.Reflection;

namespace MaterialDesignSidebarDemo.Data
{
    public class ReadData
    {
        protected ReadData()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Format: "{Namespace}.{Folder}.{filename}.{Extension}"</param>
        /// <returns></returns>
        public static string ReadResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            if (!name.StartsWith(nameof(MaterialDesignSidebarDemo)))
            {
                resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
