namespace Cars.JsonImporter
{

    using Cars.Models;

    class JsonCar
    {
        public int Year;

        public TransmissionType TransmissionType;

        public string ManufacturerName;

        public string Model;

        public decimal Price;

        public class Dealer { string Name; string City; };
    }
}
