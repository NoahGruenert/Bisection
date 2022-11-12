// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//add an optional default parameter Epsilon to the Bisect method?


using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


class Bisection
{ 
   static void Main()
   {

      float a = 0;                                 // left interval before user input
      float b = 5;                                 //right interval before user input
     
      float c = (a + b) / 2;                        //midpoint

      double e;                         //minimum width of the interval once bisection begins

      Console.WriteLine("Enter the a value (left parameter) of the interval");
      a = float.Parse(Console.ReadLine());

      Console.WriteLine("Enter the b value (right parameter) of the interval");
      b = float.Parse(Console.ReadLine());

      Console.WriteLine("Enter the minimum width of the interval. Default value is 0.000001. Type <CTRL> Z and Enter to use Default.");
      string input = Console.ReadLine();
      if (input == null)
      {
         e = 0.000001;
      }
      else
      {
         e = Math.Abs(float.Parse(input));         // e is set as the absolute value of the users input, to avoid negative values
      }
      c = (a + b) / 2;                             //calculate c again, to use the values entered by the user


      Bisection Q = new Bisection();                           //instantiate Bisection class
      Returners d = Q.Bisect(a,b,c,e);                         //Instantiate return structure and proceed with Bisecting
      Console.WriteLine($"The zero of -x*x+2 is approximately {d.k}, interval {a} to {b} bisected {d.j} times.");     //tell the world about it

   }

   public Returners Bisect(float a, float b, float c, double e)
   {
      int i = 0;                          //counter for loop iterations
      Returners q = new Returners();      // build a new Returners structure, for returning the c value of F(c) = 0, and the # of iterations i
    
      if (F(a) == 0)                      //check if a is the 0          
      {
         q.j = 0;
         q.k = a;
         return q;
      }
      if (F(b) == 0)                      // check if b is the 0
      {
         q.j = 0;
         q.k = b;
         return q;
      }
     while (F(c) != 0 && Math.Abs(b-a) > e)          //if c is not the 0, and the distance between a and b is still significant
      {
         i++;                                               //loop counter

            if((F(b)*F(c))<0)                                    //bisect and reset a at c if (F(b)*F(c))<0
            {                                                     // because b and c have opposite signs, meaning a 0 lies between b and c
               a = c;                                            // so a is moved to c, to close in on the 0
               c = (a+b)/2;
            }
            else
            {
               if((F(a)*F(c))<0)                                     //bisect and reset b at c if (F(a)*F(c))<0
               {                                                     // because a and c have opposite signs, meaning a 0 lies between a and c
                  b = c;                                             // so b is moved to c, to close in on the 0
                  c = (a+b)/2;
               }
            }
      }

      q.j = i;                                              //provide returner q with the number of iterations
      q.k = c;                                              //provide returner q with the c value for the 0
     return q;                                              //return q so it can be displayed in Main
   }  

   static double F(float x)                                  //Function operation
   {
      double y = (double) x;
      y = -x*x+2;                       // REMINDER: Changing the function here does not change the output to the user RE: F in line 44
      return y;                                             // So when editing the function here, also edit the Console Writeline in Main
   }
   public struct Returners                                  // Returner structure for Bisect Method
   {
         public int j;                                      // to be the # of iterations
         public float k;                                    // to be the c value 
   }
}