using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Serialization__Deserialization
{
    internal class Program 
    {
          public static string PathString;
    
        static void Main(string[] args)
        {
            Add("NUra");
            
        PathString = Path.GetFullPath(Path.Combine("..", "..", "..", "Files", "names.json"));

            List<string> list = new List<string> { "nurana", "turkane", "gulnare" };
            var result = JsonConvert.SerializeObject(list);
            
            using (StreamWriter sw = new(PathString))
            {
                sw.Write(result);
            }

            
          
            }
       static void Add(string name)

        {
            string result;
            using StreamReader sr = new(PathString);
            {
                result = sr.ReadToEnd();

            }
            List<string> list = JsonConvert.DeserializeObject<List<string>>(result);
            sr.Close();


            list.Add(name);

            string newResult = JsonConvert.SerializeObject(list);

            using (StreamWriter sw = new StreamWriter(PathString))
            {
                sw.WriteLine(newResult);
            }

        }
        bool search(string name)
        {
            string result;
            using StreamReader sr = new(PathString);
            {
                result = sr.ReadToEnd();

            }
            List<string> list = JsonConvert.DeserializeObject<List<string>>(result);
            sr.Close();

            if (list.Exists(e => name.Equals(name)))
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        void Delete(int index)
        {
            string result;
            using StreamReader sr = new(PathString);
            {
                result = sr.ReadToEnd();

            }
            List<string> list = JsonConvert.DeserializeObject<List<string>>(result);
            sr.Close();
            list.RemoveAt(index);
            string newResult = JsonConvert.SerializeObject(list);

            using (StreamWriter sw = new StreamWriter(PathString))
            {
                sw.WriteLine(newResult);
            }
        }
       

    }
}
