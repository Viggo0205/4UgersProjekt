using System.Text.Json;
//Victor
namespace _4UgersProjekt.Services
{
    public  abstract class JsonFileService<T>
    {

        public JsonFileService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;           
        }

        protected abstract string JsonFileName {  get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public void SaveJson(List<T> items)
        {
            using(FileStream jsonFileWriter = File.Create(JsonFileName))
            {
                Utf8JsonWriter jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                    {
                        SkipValidation = false,
                        Indented = true
                    });
                JsonSerializer.Serialize < T[]>(jsonWriter, items.ToArray());
            }
        }
        public IEnumerable<T> GetJsonItems() 
        { 
            using(StreamReader jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }


    }
}
