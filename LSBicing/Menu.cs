using System;

namespace LSBicing
{
    class Menu
    {
        int choice;

        public Menu()
        {
            System.Console.WriteLine("Please, type the number of the desired option:");
            System.Console.WriteLine("1. Geolocation services");
            System.Console.WriteLine("2. Closer bike station");
            System.Console.WriteLine("3. Route creation");
            System.Console.WriteLine("4. Bike station visualization");
            var choice_ = Console.ReadLine();
            SetChoice(choice_);
        }
        public int GetChoice(){
            return this.choice;
        }
        public void SetChoice(string newChoice){
            this.choice = Convert.ToInt32(newChoice);
        }

    }
}
