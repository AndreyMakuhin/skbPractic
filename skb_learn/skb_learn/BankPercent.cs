using System;


namespace skb_learn
{
    class BankPercent
    {

        static bool processInput(out double value)
        {
            if (double.TryParse(Console.ReadLine(), out value) && value > 0)
            {
                return true;
            }
            Console.WriteLine("Неверный формат ввода(должно быть положительное число)\n");
            return false;
        }

        static bool processInput(out int value)
        {
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
            {                
                return true;               
            }
            Console.WriteLine("Неверный формат ввода(должно быть положительное целое число)\n");
            return false;
        }

        static void Main(string[] args)
        {
            double money;
            double percent;
            int months;

            //ввод денег
            do
            {
                Console.WriteLine("Введите сумму денег: ");
            } while (!processInput(out money));

            do
            {
                Console.WriteLine("Введите сумму процентную ставку: ");
            } while (!processInput(out percent));

            do
            {
                Console.WriteLine("Введите количество месяцев: ");
            } while (!processInput(out months));          

            Console.WriteLine(CalculateSum(money, percent, months));

        }

        static double CalculateSum(double money, double percent, int months)
        {
            double percentPerMonth = (percent / 12)/100;
            for (int i = 0; i < months; i++)
            {
                money += percentPerMonth * money;
            }

            return money;
        }


    }
}
