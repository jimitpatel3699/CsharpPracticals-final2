namespace practicle2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "jimit patel";
            long accountNO = 10000000234588;
            CustomerAccount customer1 = new CustomerAccount(name,accountNO);
            customer1.PrintInfo();

            //implicit constructor 

            ImplicitConstuctor implicitConstuctor = new ImplicitConstuctor();
            implicitConstuctor.PrintData();
            
            
            //parameterless constructor

            ParameterlessConstructor parameterlessConstructor = new ParameterlessConstructor();
          
            
            //try to access private member 

            //Console.WriteLine($"Student id ={parameterlessConstructor.Id});

            //access public member of class 

            Console.WriteLine(parameterlessConstructor.Name);
         
            
            //paramerised constructor 

            ParametrisedConstrctor parametrisedConstructor = new ParametrisedConstrctor("21it100085", "jimit", "23-11-2001", 9582478996);
            parametrisedConstructor.PrintData();
            
            //try to access protected member

            //Console.WriteLine($"Student Mobile:{parametrisedConstructor.Mobile}");

            //copyconstructor

            CopyConstuctor copyConstuctor = new CopyConstuctor(10, 20);
            CopyConstuctor copyConstuctor1 = new CopyConstuctor(copyConstuctor);

            //static constructor

            StaticConstructor staticConstructor = new StaticConstructor(2110021);

            //private constructor

            //PrivateConstructor privateConstructor = new PrivateConstructor();

            //overloaded constructor

            OverloadConstructor overloadConstructor1 = new OverloadConstructor(14, 12, 19);
            OverloadConstructor overloadConstructor2 = new OverloadConstructor(50,69);
            OverloadConstructor overloadConstructor3 = new OverloadConstructor("jimit","Patel");

        }
    }
}