namespace lab_UsedCarLot
{
    public class CarRepository
    {
        Car newCar = new Car();
        List<Car> carRepo = new List<Car>();

        public CarRepository()
        {

        }

        public List<Car> SeedRepoList()
        {
            Console.WriteLine();

            // seeding data
            carRepo.Add(new Car("NEW", "Kia", "Sedona", 2007, 3000m));
            carRepo.Add(new UsedCar("USED", "Dodge", "Charger", 2014, 15000m, 80000));
            carRepo.Add(new Car("NEW", "Ford", "F150", 2020, 24000m));
            carRepo.Add(new UsedCar("USED", "Buick", "Skylark", 2007, 3000m, 180000));
            carRepo.Add(new Car("NEW", "Ford", "Focus", 2022, 35000m));
            carRepo.Add(new UsedCar("USED", "Pontiac", "Sundance", 1998, 2000m, 300000));
            return carRepo;
        }

        public Car GetCar(int carNum)
        {
            Car car = carRepo[carNum - 1];
            return car;
        }

        // BUY/REMOVE car from repo
        public List<Car> RemoveCar(Car car)
        {
            carRepo.Remove(car);

            return carRepo;
        }

        // SELL/ ADD car to repo
        public List<Car> AddCar(string condition, string make, string model, int year, decimal price, double mileage)
        {
            if (mileage == 0)
            {
                carRepo.Add(new Car(condition.ToUpper(), make, model, year, price));
            }
            else
            {
                carRepo.Add(new UsedCar(condition.ToUpper(), make, model, year, price, mileage));
            }

            return carRepo;
        }

        public List<Car> filterCarsByMakeOrModel(List<Car> inventoryList, string searchType, string criteria)
        {
            List<Car> filteredList = new List<Car>();

            var searchCriteria = criteria;

            switch (searchType)
            {
                case "make":
                    filteredList = inventoryList.Where(x => x.make.ToLower() == criteria).ToList();
                    break;

                case "model":
                    filteredList = inventoryList.Where(x => x.model.ToLower() == criteria).ToList();

                    break;
                default:
                    Console.WriteLine($"Sorry, {criteria} is not an available search option.");
                    break;
            }

            return filteredList;
        }

        // STRETCH methods
        public void GetCarListByYear()
        {

        }

        public void GetCarListByPrice()
        {

        }

        public void GetCarListByMileage()
        {

        }
    }
}