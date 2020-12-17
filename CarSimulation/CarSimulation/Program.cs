using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarSimulation
{
    class Program
    {
        static ClientCalls client = new ClientCalls();
        static async Task Main(string[] args)
        {

            Car mycar = new Car(2, 500, 20, 0.2, 1);

            mycar.Car_Change_Direction(30);
            mycar.Desired_speed = 120.0;

            Timer mytimer = new Timer(Run_Car, mycar, 0, 1000);

            Communication Com_Modul = new Communication(mycar);
            Timer comtimer = new Timer(ServerComm, Com_Modul, 0, 1000);

            Console.ReadLine();
            Console.WriteLine("End");
        }
        static async void Run_Car(object my_car)
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
        static async void ServerComm(object my_comm)
        {
            Communication comm = (Communication)my_comm;

            var getData = await client.GetDataAsync();

            comm.Com_Set_Desired_Speed(getData.sentSpeed);
            comm.Com_Set_Wheel(getData.sentSteeringWheelAngle);
            comm.Com_Set_Gear(getData.sentisReverse);

            if (getData.sentIsReset)
                comm.Com_Reset_Car();

            PostData postData = new PostData();

            postData.postX = comm.Com_Get_X_Position();
            postData.postY = comm.Com_Get_Y_Position();
            postData.postOrientation = comm.Com_Get_Orientation();

            string reuslt2 = await client.PostDataAsync(postData);
        }

    }
}
