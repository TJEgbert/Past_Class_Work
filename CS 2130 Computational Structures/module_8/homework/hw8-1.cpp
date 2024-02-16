#include <iostream>
#include <ctype.h>
#include <string>  // Needed for Visual Studio

using namespace std;

int main(int argc, char *argv[]) {
	int n1;   // n-1 for computing F(n) for n>1
	int n2;   // n-2 for computing F(n) for n>1
	int n;    // Result, F(n)
	int num;  // the value to determine the prime factorization for
	int i;    // loop control variable
	string inputStr;  // used to get an entire line of input
	char answer = ' ';  // used for the answer of doing another numer
	
	cout << "This program examines math with large integer values\n";
	cout << "We will use an interative algoritthm to determine a \n" 
		<<  "Fibonacci value.  You need to enter an integer, i  > 1 and \n" 
		<<  "the program will print out the ith value in the Fibonacci\n"
		<<  "sequence.\n\n";
		
	do {
		cout << "\nPlease enter a positive integer greater than 1: ";
		cin >> num;
		if (num < 1) {
			cout << "Can't determine the " << num<< "th Fibonacci number\n";
		} else {
			cout << "The " << num << "th Fibonacci is: ";
			n1 = 1;  // initialize n-1
			n2 = 0;  // initialize n-2
			n = 1;   // initialize n
			i = 2;   // counter
			while(i <= num) {  // We are determining F(i)
				n = n1 + n2;   // F(n) = F(n-1) + F(n-2)
				n2 = n1;       // 
				n1 = n;
				i++;
			}
			cout << n << "\n\n";
		}
		cout << "Would you like to try another number (N for no, anything else is yes): ";
		cin.ignore(256, '\n');
		getline(cin,inputStr);
		answer = toupper(inputStr[0]);
		
	} while (answer != 'N');
	

	
	
	
	return 0;
}
