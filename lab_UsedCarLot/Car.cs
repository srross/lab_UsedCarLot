namespace lab_UsedCarLot
{
    public class Car
    {
        public string condition { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal price { get; set; }


        // costructor loads up a default car
        public Car()
        {
            this.condition = "USED";
            this.make = "Jeep";
            this.model = "Rubicon";
            this.year = 2004;
            this.price = 18000m;
        }

        // constructor loads up a car selected by user
        public Car(string condition, string make, string model, int year, decimal price)
        {
            this.condition = condition;
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
        }

        // List all cars to the console
        public override string ToString()
        {
            return $"Condition: {condition}\tMake: {make}\tModel: {model}\tYear: {year}\tPrice: {price}";

        }
    }
}