using System;
using Conta.Entities;

namespace Conta
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1001, "Alex", 500.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            //UPCASTING: Conversão da subclasse para superclasse
            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0); //Fica disponível somente os métodos da Account
            Account acc3 = new SavingsAccount(1004, "Anna", 0.0, 0.01);  //Para poder utilizar os métodos da subclasse precisa fazer casting

            //DOWNCASTING: Conversão da superclasse para subclasse
            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0); // Os métodos da subclasse estão disponíveis pois foi feito casting

            // Ocorre erro em tempo de execução se tentar fazer casting para subclasse diferente da que foi utilizada para instanciar o objeto.
            //BusinessAccount acc5 = (BusinessAccount)acc3;

            //Precisa testar antes de fazer casting para evitar erros:
            if(acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                //BusinessAccount acc5 = acc3 as BusinessAccount; //Forma alternativa de escrita
                acc5.Loan(200.0);
                System.Console.WriteLine("Loan!");
            }

            if(acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = (SavingsAccount)acc3;
                //SavingsAccount acc5 = acc3 as SavingsAccount; //Forma alternativa de escrita
                acc5.UpdateBalance();
                System.Console.WriteLine("Update!");
            }

            Account acc6 = new Account(1006, "Alex,", 500.0);
            Account acc7 = new SavingsAccount(1007, "Anna", 500, 0.01);

            acc6.Withdraw(10.0);
            acc7.Withdraw(10.0);

            System.Console.WriteLine(acc6.Balance);
            System.Console.WriteLine(acc7.Balance);

        }
    }
}
