namespace GateWay.Models
{

    public class WeatherMain
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; } // Main weather description (e.g., "Clear")
        public string Description { get; set; } // Detailed weather description (e.g., "clear sky")
    }

    public class WeatherResponse
    {
        public WeatherMain Main { get; set; }
        public List<WeatherDescription> Weather { get; set; }
    }


}


