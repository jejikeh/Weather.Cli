using System.Text;
using Newtonsoft.Json;

namespace Weather.Cli
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get an array of object bytes
        /// </summary>
        /// <param name="data">object</param>
        /// <returns></returns>
        public static byte[] GetBytes(this object? data)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
        }
        
        /// <summary>
        /// Save the object
        /// </summary>
        /// <param name="data">object</param>
        /// <param name="filePath">file path</param>
        /// <returns></returns>
        public static void Save(this object? data, string filePath)
        {
            Storage.Save(data, filePath);
        }
    }
}