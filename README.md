# Bisection
C# Console App for Bisection of F(x) to find root on [a,b]

******************Overview of Bisection in Math**************************************************************************************************

Bisection is a way to find the real roots of a polynomial function, along an interval [A,B] where F(A) and F(B) have opposite signs. 
This guarantees at least one root (a point where F(x) = 0 ) will lie between points A and B.

By bisecting that interval, and analyzing whether the midpoint F(C) lies above or below 0, 
we can create a smaller interval to continue the bisection, until either F(0) is exactly 0. 
Otherwise, if for instance the root of the polynomial is an irrational number, 
the bisection can trim the distance between A and B to be miniscule enough to make a close estimate of C at F(C) = nearly 0. 

You can read more about the math behind this operation here. 	
    https://en.wikipedia.org/wiki/Bisection_method
    
******************Read the Full Code******************************************************************************************************
 Bisection > Program.cs
 
 The C# program described below is available in the Bisection Folder, and is titled Program.cs, by convention. 
 
******************How this C# program works******************************************************************************************************

This C# program uses a bisection method when provided with an interval [A,B] in which at least one root exists as a non-imaginary number. 
The user may provide an interval, as well as an epsilon value for the smallest distance between A and B for the bisection to trim down to. 
A midpoint C is calculated between A and B, and the program then passes these 4 arguments to the bisection method for operation. 
The method counts how many times it performs the bisection with a counter i.

The bisection method in my program uses a separate Structure to return two values for output. 
The important return value is the C value when F(C)=0, but it must also return the counter i, how many bisections were made, 
and I use a structure I created called Returners. A Tuple structure could also return multiple values, 
but I have chosen to create my own return structure for better readability. The structure is called Returners,
and lives at the very end of the code file.

I also have a separate method for all calculations involving the polynomial function, to call F(x) whenever needed,
without hard coding the equation into the Bisection method. This makes changing the polynomial much easier. 

The program is currently set up to calculate the root of -x^2 + 2, but it can also calculate other quadratics,
or more complex functions like Sin(x), by modifying the F method.

The Bisection method instantiates a Returners structure for its outputs, then first checks if F(A) or F(B) are the 0 points, in which case it will return that value immediately, and a counter i of 0, since the interval was not bisected at all.
Otherwise, it will continue with the bisection.
A while loop iterates the bisection and keeps track of the counter i. 
The while loop will stop when F(C) = 0, or when the distance between a and b becomes smaller than epsilon. 
(This is done by comparing the absolute value of (B-A) to epsilon).

Nested within the while loop, are two If statements.
They check for whether F(A) and F(C) opposite signs 
(which would mean C becomes the new boundary B of the newly bisected interval) 
or if F(B) and F(C) have opposite signs, 
(which would mean C becomes the new boundary A of the newly bisected interval).

When the loop is complete and the C value for F(C)=0 is found, the bisection method assigns that C value, and the counter i, 
to the instance of the Returners structure it is using, 
and then returns that instance to the main Method for printing the outcome in the console, for the user to see.


******************Notes*****************************************************************************************************

This program was straightforward to implement, but there are several things to say for others working on a similar exercise.
A more advanced version of this program would be able to accept user input of the function F(x) by reading the inputted string, but this was beyond the scope of my exercise here.

A more mathematical version might be concerned with a greater degree of certainty, which I have included to some degree with the epsilon value. Using doubles rather than floats for the operation would be more accurate, but for a general purpose algorithm, floats are sufficiently accurate.

