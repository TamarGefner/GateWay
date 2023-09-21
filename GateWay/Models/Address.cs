using Newtonsoft.Json;

namespace GateWay.Models
{

    // Root TheTags = JsonConvert.DeserializeObject<Root>(response);
    public class Field
    {
        public string id { get; set; }
        public string type { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public string label { get; set; }
        public string notes { get; set; }
        public string type_override { get; set; }
    }

    public class Links
    {
        public string start { get; set; }
        public string next { get; set; }
    }

    public class Record
    {
        public int _id { get; set; }
        public int region_code { get; set; }
        public string region_name { get; set; }
        public int city_code { get; set; }
        public string city_name { get; set; }
        public string street_code { get; set; }
        public string street_name { get; set; }
        public string street_name_status { get; set; }
        public int official_code { get; set; }
    }

    public class Result
    {
        public bool include_total { get; set; }
        public int limit { get; set; }
        public string records_format { get; set; }
        public string resource_id { get; set; }
        public object total_estimation_threshold { get; set; }
        public List<Record> records { get; set; }
        public List<Field> fields { get; set; }
        public Links _links { get; set; }
        public int total { get; set; }
        public bool total_was_estimated { get; set; }
    }

    public class AddressRoot
    {
        public string help { get; set; }
        public bool success { get; set; }
        public Result result { get; set; }
    }

}
