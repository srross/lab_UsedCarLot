namespace lab_UsedCarLot
{
    internal class UsedCar : Car
    {
        public double mileage { get; set; }

        public UsedCar(string condition, string make, string model, int year, decimal price, double mileage)
            : base(condition, make, model, year, price)
        {
            this.mileage = mileage;
        }

        public override string ToString()
        {
            return $"Condition: {condition}\tMake: {make}\tModel: {model}\tYear: {year}\tPrice: {price}\tMileage: {mileage}";
        }
    }
}
