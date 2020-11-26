using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the total distance of the cup from the starting point ");
            double total_Distance = double.Parse(Console.ReadLine());

            double start_location = 0;
            double gravity = 9.8;
            double covered_distance = 0;

            int triedCount = 1;
            int total_possibilities = 1;

            bool fallen_In_cup = false;

            while (fallen_In_cup==false)
            {
                Console.WriteLine($"{triedCount} The start location is {start_location}");

                if (triedCount > total_possibilities)
                {
                    try
                    {
                        throw new CustomerException("Game is finished because you tried over the acceptance lavel .");
                    }
                    catch (CustomerException ex)
                    {
                        Console.WriteLine($"Error message {ex.Message}");
                        break;
                    }

                }
                Console.WriteLine("Enter the size of angle: ");
                double angle = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter the velocity of the ball ");
                double velocity = double.Parse(Console.ReadLine());

                double angle_In_Radianns = (Math.PI / 180) * angle;

                double distance = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angle_In_Radianns);
                Console.WriteLine($"This time cover distance is {distance}");
                
                covered_distance = covered_distance + distance;
                //total_Distance = total_Distance - covered_distance;

                //Console.WriteLine($"Now the latest distance of the cup is {total_Distance}");
                Console.WriteLine($"At {angle} and {velocity} m/s the ball should travel {covered_distance} meters and tried {triedCount} times");

                start_location = start_location + distance;

                

                double new_Distance = 0;

                if (covered_distance >= total_Distance)
                {
                    new_Distance = covered_distance - total_Distance;
                    if (new_Distance > 200)
                    {
                        try
                        {
                            throw new CustomerException("Game is finished because you are more than two hundred meters far away from the cup .");
                        }
                        catch(CustomerException ex)
                        {
                            Console.WriteLine($"Error message {ex.Message}");
                            break;
                        }
                        
                    }
                    else
                    {
                        total_Distance = new_Distance;

                        Console.WriteLine("Is the ball fallen in the cup ");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "yes")
                        {
                            fallen_In_cup = true;
                            Console.WriteLine($"The ball should travel {covered_distance} meters and tried {triedCount} times");
                            break;
                        }
                        else
                        {
                            triedCount++;
                            continue;
                        }
                    }
                }
                triedCount++;
                Console.WriteLine("--------------------------");

            }

            

            Console.ReadLine();
        }
    }
}
