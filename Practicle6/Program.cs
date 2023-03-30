namespace Practicle6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic processlogic = new ProcessBusinessLogic();
            processlogic.ProcessCompleted += bl_ProcessCompleted; // register with an event
            processlogic.StartProcess();
        }
        // event handler
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Method Invoked");
        }
    }
}