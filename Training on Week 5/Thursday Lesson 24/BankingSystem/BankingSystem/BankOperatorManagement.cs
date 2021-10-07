using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    class BankOperatorManagement
    {
        public static Dictionary<int, Tuple<string, double>> operators = new Dictionary<int, Tuple<string, double>>();
        public void AddOperator()
        {
            try
            {

                operators.Add(001, new Tuple<string, double>("John", 2000.00));
                operators.Add(002, new Tuple<string, double>("Mark", 3500.50));
                operators.Add(003, new Tuple<string, double>("Mary", 2500.50));
                operators.Add(004, new Tuple<string, double>("Kim", 2000.00));
                operators.Add(005, new Tuple<string, double>("Elvi", 3000.00));

                //Operator o1 = new Operator(001, "John", 2000.00);
                //Operator o2 = new Operator(002, "Mark", 3500.50);
                //Operator o3 = new Operator(003, "Mary", 2500.50);
                //Operator o4 = new Operator(004, "Kim", 2000.00);
                //Operator o5 = new Operator(005, "Elvi", 3000.00);

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Operator already in database, Please try another operator number");
            }
            catch (AggregateException)
            {
                Console.WriteLine("sorry not allowed");
            }
            catch (FormatException)
            {
                Console.WriteLine("incorrect format");
            }

        }
        //public void RemoveOperators(Operator operator1)
        //{
        //    operators.Remove(operator1.operatorID);
        //}
        public void ListOperators()
        {

            foreach (var operator1 in operators)
            {
                Console.WriteLine("Listing all current operators: ");
                Console.WriteLine("{0} > {1}", operator1.Key, operator1.Value.Item1, operator1.Value.Item2);

            }

        }
    }
}
