using System;

/*
* Laundry App
* Presented by: Dario Ospina
* March 7, 2022
*/


namespace Laundry_app
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of Class LaundryApp
            LaundryApp laundryApp = new LaundryApp();

            // Adding Service Providers to a list of type Vehicle
            laundryApp.AddServiceProvider(new CarDriver("Dario", 10001, 23, 50.914988088392285, -114.10762954949365));
            laundryApp.AddServiceProvider(new CarDriver("Nathir ", 10002, 18, 50.91896624958428, -114.0773686259417));
            laundryApp.AddServiceProvider(new CarDriver("Laura", 10003, 22, 50.90204779327012, -114.08210197062976));
            laundryApp.AddServiceProvider(new TruckDriver("Peter", 10004, 17, 50.903617506562505, -114.10201469100704));
            laundryApp.AddServiceProvider(new TruckDriver("Paul", 10005, 13, 50.92006924724926, -114.09197250017202));
            laundryApp.AddServiceProvider(new CarDriver("Andrea", 10006, 17, 50.90031915561986, -114.06352000167175));
            laundryApp.AddServiceProvider(new TruckDriver("Dolly", 10007, 19, 50.89014124196806, -114.08543458957334));
            laundryApp.AddServiceProvider(new TruckDriver("James", 10008, 22, 50.895934161155694, -114.10174242069526));
            laundryApp.AddServiceProvider(new CarDriver("Jhon", 10009, 19, 50.90031915561986, -114.06352000167175));
            laundryApp.AddServiceProvider(new TruckDriver("Sean", 10010, 21, 50.90031915561986, -114.06352000167175));
            laundryApp.AddServiceProvider(new CarDriver("Carlos", 10011, 17, 50.90031915561986, -114.06352000167175));
            laundryApp.AddServiceProvider(new CarDriver("Jose", 10012, 21, 50.90031915561986, -114.06352000167175));

            // Adding Customers to a list of type Customer
            laundryApp.AddACustomer("Alex", 20001);
            laundryApp.AddACustomer("Maria", 20002);
            laundryApp.AddACustomer("Ana", 20003);

            // Calling the RequestService method
            laundryApp.RequestService(20002, 5, 50.912989597847925, -114.0488833455536, 50.912177847238034, - 114.07162847874318);
            laundryApp.RequestService(20003, 12, 50.95377159072059, -114.0924375174566, 50.95442041181889, -113.98566413750257);
            // The following ID doesn't exist, thus, the Program will retrieve a different message.
            laundryApp.RequestService(20005, 2, 50.90434926605356, -114.03491551379558, 50.891357146149836, -114.03457219103046);

            // Updating the location of the Service Provider identified with ID # 10001
            laundryApp.UpdateLocation<ServiceProvider>(10001, 50.90031915561986, -114.06352000167175, laundryApp.ListOfServiceProviders);
            // Calling the RequestService method to alter the list and produce a different output
            laundryApp.RequestService(20002, 5, 50.912989597847925, -114.0488833455536, 50.912177847238034, -114.07162847874318);
        }
    }
}
