/**
 * Try-it-out: Template Stack Class
 * Trevor Egbert
 * 7/5/2022
 * Creates the Stack template class and implements it.
 */

#include <iostream>
#include <string>
#include "carton.h"
#include "stack.h"

using namespace std;

int main() {

  // Part 4, First Stack Type
  cout << "Part 4\nFirst Stack\n";

  // Define a Stack object. Make it small, a maximum size of 3-6
    Stack<int, 5> stack_1(5);
    cout << stack_1.Top() << endl;

  // Use Push to fill up the stack, then Push one more time
  // Handle the exception by using a try/catch block. When an exception
  // occurs, print the exception message to the screen

  try
  {
      stack_1.Push(2);
      cout << stack_1.Top() << endl;
      stack_1.Push(4);
      cout << stack_1.Top() << endl;
      stack_1.Push(7);
      cout << stack_1.Top() << endl;
      stack_1.Push(2);
      cout << stack_1.Top() << endl;
  }
  catch (out_of_range over)
  {
      cout << over.what() << endl;
  }

  cout << "stack_1 loading complete." << endl;


//  //  Print out the following information about the Stack
//  //  size of Stack
//  //  value at the top of the Stack. Handle this by using a try/catch block
//  //  When an exception occurs, print the exception message to the screen

  int stack_1_size = stack_1.Size();
  int stack_1_top;
  try
  {
      stack_1_top = stack_1.Top();
  }
  catch (out_of_range none)
  {
      cout << none.what() << endl;
  }

  cout << "Stack 1 size: " << stack_1_size << endl;
  cout << "Top of Stack 1: " << stack_1_top << endl;


  //  Use Pop to remove all the items from the Stack. Use the Empty method
  //  to prevent an exception. Print each value as it is popped.

  while(!stack_1.Empty())
  {
      cout << stack_1.Top() << endl;
      stack_1.Pop();
  }


  //  Print out the following information about the Stack
  //  size of Stack
  //  value at the top of the Stack. Handle this by using a try/catch block
  //  When an exception occurs, print the exception message to the screen

  stack_1_size= stack_1.Size();

  try
  {
      stack_1_top = stack_1.Top();
  }
  catch (out_of_range none)
  {
      cout << none.what() << endl;
  }

  cout << "Stack 1 size: " << stack_1_size << endl;
  cout << "Top of Stack 1: " << stack_1_top << endl;

  // Part 4, Second Stack Type
  cout << "Part 4\n\nSecond Stack\n";

  // Define a Stack object. Make it small, a maximum size of 3-6

  Stack<string, 5> stack_2("Ace");

  // Use Push to fill up the stack plus one additional Push
  // Handle the exception by using a try/catch block to handle the exception.

  try
  {
      stack_2.Push("Jack");
      cout << stack_2.Top() << endl;
      stack_2.Push("Queen");
      cout << stack_2.Top() << endl;
      stack_2.Push("King");
      cout << stack_2.Top() << endl;
      stack_2.Push("Spade");
      cout << stack_2.Top() << endl;
  }
  catch (out_of_range over)
  {
      cout << over.what() << endl;
  }

  cout << "stack_2 loading complete." << endl;

  //  Print out the following information about the Stack
  //  size of Stack
  //  value at the top of the Stack. Handle this by using a try/catch block

  int stack_2_size = stack_2.Size();
  string stack_2_top;
  try
  {
      stack_2_top = stack_2.Top();
  }
  catch (out_of_range none)
  {
      cout << none.what() << endl;
  }
  cout << "Stack 2 size: " << stack_2_size << endl;
  cout << "Top of Stack 2: " << stack_2_top << endl;

  //  Use Pop to remove all the items from the Stack. Use the Empty method
  //  to prevent an exception. Print each value as it is popped.

  while(!stack_2.Empty())
  {
      cout << stack_2.Top() << endl;
      stack_2.Pop();
  }

  //  Print out the following information about the Stack
  //  size of Stack
  //  value at the top of the Stack. Handle this by using a try/catch block

  stack_2_size= stack_2.Size();

  try
  {
      stack_2_top = stack_2.Top();
  }
  catch (out_of_range none)
  {
      cout << none.what() << endl;
  }
  cout << "Stack 2 size: " << stack_2_size << endl;
  cout << "Top of Stack 2: " << stack_2_top << endl;

  return 0;
}