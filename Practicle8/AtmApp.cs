using Practicle8.UI;

namespace Practicle8
{
    internal class AtmApp
    {
        static void Main(string[] args)
        {
            
            AppScreen.Welcome();
            long cardNumber = Validator.Convert<long>("Card Number:");
            Console.WriteLine(cardNumber);
            
            
        }
    }
}