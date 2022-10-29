using Newtonsoft.Json;

namespace Weather.Cli
{
    public static class Storage
    {
        /// <summary>
        /// Saving an object to a file.
        /// </summary>
        /// <param name="data">Object</param>
        /// <param name="filePath">File path</param>
        /// <typeparam name="T">Object type</typeparam>
        /// <exception cref="Exception">When the method does not return an object</exception>
        public static void Save<T>(T data, string filePath)
        {
            try
            {
                var bytes = data.GetBytes();
                File.WriteAllBytes(filePath, bytes);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O error occurred while opening the file.\n" + ex.Message);
            }
        }
        
        /// <summary>
        /// Loading an object from a file.
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <typeparam name="T">Object type</typeparam>
        /// <returns></returns>
        /// <exception cref="Exception">When the method does not return an object</exception>
        public static T Load<T>(string filePath)
        {
            try
            {
                var fileContent = File.ReadAllBytes(filePath);
                var stringContent = System.Text.Encoding.Default.GetString(fileContent);
                var obj = JsonConvert.DeserializeObject<T>(stringContent);

                return obj;
            }
            catch (IOException ex)
            {
                Console.WriteLine("An I/O error occurred while opening the file.\n" + ex.Message);
            }

            throw new Exception("Something went wrong.");
        }
    }
}