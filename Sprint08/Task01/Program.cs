using System;
using System.Threading;
using System.Threading.Tasks;
//Implement ParallelUtils class that will be able to execute an operation in a parallel thread.
//The constructor of ParallelUtils takes 3 parameters: 
// 1) The Func<T, T, TR> to define an operation that will be executed,
// 2) The operand1 of type T 
// 3) Tperand2 of type T.
//The ParallelUtils class should have public Result property of type TR where the result of the operation must be written when it's executed.
//Implement method StartEvaluation that will start the evaluation (of the function passed into constructor) in a parallel thread 
//Implement method Evaluate that will start the evaluation (of the function passed into constructor) in a parallel thread and wait until it's executed
namespace Task01
{
    class ParallelUtils<T, TR>
    {
        private T firstOperand;
        private T secondOperand;
        private Func<T, T, TR> func;
        public TR Result { get; set; }
        public ParallelUtils(Func<T, T, TR> func, T firstOperand, T secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
            this.func = func;
        }
        public void StartEvaluation()
        {
            Thread thread = new Thread(() => { Result = func(firstOperand, secondOperand); });
            thread.Start();
        }
        public void Evaluate()
        {
            Thread thread = new Thread(() => { Result = func(firstOperand, secondOperand); });
            thread.Start();
            thread.Join();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            var parallelUtils = new ParallelUtils<int, int>((x, y) => x + y, 3, 5);
            parallelUtils.StartEvaluation();
            Console.WriteLine(parallelUtils.Result);
            Console.ReadLine();
        }
    }
}
