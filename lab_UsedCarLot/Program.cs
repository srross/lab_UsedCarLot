
using lab_UsedCarLot;

var transType = string.Empty;
var buyCar = string.Empty;
var sellCar = string.Empty;
var searchCarList = string.Empty;

var repo = new CarRepository();

Console.WriteLine("Welcome to Big O's AutoBrokers!!");
var seedRepo = repo.SeedRepoList();
var currentInventory = new List<Car>(seedRepo);

while (transType == string.Empty)
{
    Console.Write("Would you like to do today? You can enter: 'BUY', 'SELL', 'SEARCH' or  any other keys to EXIT: ");

    transType = Console.ReadLine().ToLower();

    if (transType == "buy")
    {
        buyCar = "y";

        while (buyCar == "y")
        {
            if (currentInventory != null)
            {
                Console.WriteLine();
                foreach (var car in currentInventory)
                {
                    Console.WriteLine($"{currentInventory.IndexOf(car) + 1}. {car.ToString()}");
                }
            }

            Console.WriteLine();
            Console.Write("Please enter a car number: ");
            var carNum = 0;
            var isValidCarNum = int.TryParse(Console.ReadLine(), out carNum);

            if (isValidCarNum && (carNum > 0 && carNum <= currentInventory.Count()))
            {
                var carToBuy = repo.GetCar(carNum);

                Console.Write($"Would you like to buy the {carToBuy.year} {carToBuy.make} {carToBuy.model} (y/n)? ");
                buyCar = Console.ReadLine().ToLower();

                if (buyCar == "y")
                {
                    currentInventory = repo.RemoveCar(carToBuy);

                    Console.WriteLine();
                    Console.WriteLine($" Congratulations!!");
                    Console.WriteLine($" You're driving home in a {carToBuy.year} {carToBuy.make} {carToBuy.model}!!");
                    foreach (var c in currentInventory)
                    {
                        Console.WriteLine($"{currentInventory.IndexOf(c) + 1}. {c.ToString()}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Sorry, {carNum} is not available.");
                buyCar = Console.ReadLine().ToLower();
            }

            Console.Write("Would you like to buy another (y/n): ");
            buyCar = Console.ReadLine().ToLower();
            if (buyCar != "y")
            {
                transType = string.Empty;
            }
        }
    }
    else if (transType == "sell")
    {
        sellCar = "y";

        if (currentInventory != null)
        {
            Console.WriteLine();
        }

        while (sellCar == "y")
        {
            var condition = string.Empty;
            var year = 0;
            var make = string.Empty;
            var model = string.Empty;
            var price = 0.0m;
            var miles = 0;

            Console.WriteLine();
            Console.Write("What is the condition of the car you are selling (new/used)? ");
            condition = Console.ReadLine().ToLower();

            year = 0;
            Console.Write("Enter year: ");
            var validYearNum = int.TryParse(Console.ReadLine(), out year);

            Console.Write("Enter make:");
            make = Console.ReadLine().ToLower();

            Console.Write("Enter model: ");
            model = Console.ReadLine().ToLower();

            price = 0m;
            Console.Write("Enter price: ");
            var validPrice = decimal.TryParse(Console.ReadLine(), out price);

            miles = 0;

            if (condition == "used")
            {
                Console.Write("Enter mileage: ");
                var validMiles = int.TryParse(Console.ReadLine(), out miles);
            }

            if (condition != "new" && condition != "used"
                || year == 0
                || make == string.Empty
                || model == string.Empty
                || price == 0
                || condition == "used" && miles == 0
                )
            {
                condition = "One or more of your entries are invalid, please try again";
                Console.Write("One or more of your entries are invalid, please try again. ");
                continue;
            }
            else
            {              
                currentInventory = repo.AddCar(condition, make, model, year, price, miles);

                Console.WriteLine();
                Console.WriteLine($"Your {condition} {year} {make} {model} has been added to our inventory.");
                foreach (var car in currentInventory)
                {
                    Console.WriteLine($"{currentInventory.IndexOf(car) + 1}. {car.ToString()}");
                }
            }

            Console.WriteLine();
            Console.Write("Woud you like to sell another car (y/n)? ");
            sellCar = Console.ReadLine().ToLower();
            if (sellCar != "y")
            {
                transType = string.Empty;
            }
        }
    }
    else if (transType == "search")
    {
        searchCarList = "y";

        var searchCriteria = string.Empty;
        List<Car> filteredList = new List<Car>();

        while (searchCarList == "y")
        {
            Console.Write("Please enter search type (make or model): ");
            var searchType = Console.ReadLine().ToLower();

            if (searchType == "make" || searchType == "model")
            {
                Console.WriteLine();
                Console.Write($"What car {searchType} are you looking for? ");
                searchCriteria = Console.ReadLine().ToLower();

                if (currentInventory != null)
                {
                    filteredList = repo.filterCarsByMakeOrModel(currentInventory, searchType, searchCriteria);

                    if (filteredList.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Sorry, we are fresh out of {searchCriteria}s ");
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.Write("Sorry, we have no inventory at this time. ");
                }

                Console.WriteLine();
                foreach (var c in filteredList)
                {
                    Console.WriteLine($"{filteredList.IndexOf(c) + 1}. {c.ToString()}");
                }
            }
            else
            {
                Console.WriteLine();
                Console.Write("Please enter a valid search type (make/model): ");
            }

            Console.WriteLine();
            Console.Write("Would you like to try another search (y/n)? ");
            searchCarList = Console.ReadLine().ToLower();
        }
    }

    Console.WriteLine();
    Console.Write("Would you like to perform another transaction (y/n)? ");
    var anotherTrx = Console.ReadLine().ToLower();

    if (anotherTrx == "y")
    {
        transType = String.Empty;
    }
    else
    {
        transType = "quit";
    }
}
Console.WriteLine("Thanks for stopping by, Bye-bye!!");

Console.ReadLine();