using System;
using System.Threading;

namespace CarSimulation
{
    class Program
    {

        static void Main(string[] args)
        {

            Car mycar = new Car(2, 500, 20, 0.2, 1);
            mycar.Car_Change_Direction(30);
            mycar.Desired_speed = 120.0;
            Timer mytimer = new Timer(Run_Car, mycar, 0, 1000);
            Communication Com_Modul = new Communication(mycar);

            Console.ReadLine();
            Console.WriteLine("End");
        }
        static void Run_Car(object my_car)
        {
            Car car = (Car)my_car;
            car.Car_Refresh();
            Console.WriteLine("Speed=");
            Console.WriteLine(car.Car_Get_Speed());
            Console.WriteLine("X=");
            Console.WriteLine(car.Car_Get_XPos());
            Console.WriteLine("Y=");
            Console.WriteLine(car.Car_Get_YPos());
        }

    }
}
