[![Open in Visual Studio Code](https://classroom.github.com/assets/open-in-vscode-2e0aaae1b6195c2367325f4f02e2d04e9abb55f0b24a779b69b11b9e10269abc.svg)](https://classroom.github.com/online_ide?assignment_repo_id=15667364&assignment_repo_type=AssignmentRepo)
# CS 4580, Introduction to Python for Data Science

 ## 1.1. Objective and Purpose

The goal of this assignment is to review your Python programming skills and introduce some of the key Python libraries and technology tools that will be used throughout the course. By completing this assignment, you will ensure that your development environment is properly configured and that you are comfortable with the basic workflow we’ll follow for subsequent assignments.


## 1.3. Task 0: Prerequisites and Setup Verification
Before starting this assignment, ensure that you have the following software development tools installed and set up on your system:

	•	Anaconda: For managing Python environments and packages.
	•	GitHub Account: For version control and collaboration.
	•	Visual Studio Code (VS Code): As your integrated development environment (IDE).


## 1.4. Task 1: Factorial Digit Sum
Reference: https://projecteuler.net/problem=20 

```
n! means n × (n − 1) × ... × 3 × 2 × 1
```
For example, `10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800`,

and the sum of the digits in the number `10!` is:
```
3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
```

Find the sum of the digits in the number `100!`

Using `part1.py`, write one or more functions to solve this problem. 

Sample Output
```
$ python part1.py
The sum of digits for 100! is: 648
```
### 1.4.1. Test Task 1 Code

When you are ready to test your code, run the following command: 

```bash
$ pytest part1_test.py

....

part1_test.py ..                                                                   [100%]

=============== 2 passed in 0.03s =============
```
Note: If you need to install `pytest` testing package, run the following command: 
```
$ pip install pytest
```

## 1.5. Task 2: The 1000-digit Fibonacci Number
Reference: https://projecteuler.net/problem=25 

The Fibonacci sequence is defined by the recurrence relation:

    Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.

Hence the first 12 terms will be:

    F1 = 1
    F2 = 1
    F3 = 2
    F4 = 3
    F5 = 5
    F6 = 8
    F7 = 13
    F8 = 21
    F9 = 34
    F10 = 55
    F11 = 89
    F12 = 144

The `12th` term, `F12`, is the first term to contain `three` digits.

What is the **index** of the first term in the Fibonacci sequence to contain `1000` digits?

*Hint: Do not use recursion!*

Using `part2.py`, write one or more functions to solve this problem. 

Sample Output
```
$ python part2.py
For index 12, it contains 3 digits
For index 4782, it contains 1000 digits
```
### 1.5.1. Test Task 2 Code

When you are ready to test your code, run the following command: 

```bash
$ pytest part2_test.py

....

part2_test.py ..                                                                   [100%]

=============== 2 passed in 0.03s =============
```
Note: If you need to install `pytest` testing package, run the following command: 
```
$ pip install pytest
```


## 1.6. Task 3: Largest Palindrome Product
Reference: https://projecteuler.net/problem=4

A palindromic number reads the same both ways. The largest palindrome made from the product of `two 2-digit numbers is 9009 = 91 × 99`.

Find the largest palindrome made from the product of two `3-digit numbers`.


Using `part3.py`, write one or more functions to solve this problem. 

Sample Output
```
$ python part3.py
Max number for 2 by 2 is 9009
Max number for 3 by 3 is 906609
```
### 1.6.1. Test Task 3 Code

When you are ready to test your code, run the following command: 

```bash
$ pytest part3_test.py

....

part3_test.py ..                                                                   [100%]

=============== 2 passed in 0.03s =============
```
Note: If you need to install `pytest` testing package, run the following command: 
```
$ pip install pytest
```



## 1.7. Submission Checklist

Before submitting your assignment, ensure that you have completed the following:

- [ ] Pass all test cases for Tasks 1
- [ ] Pass all test cases for Tasks 2
- [ ] Pass all test cases for Tasks 3
- [ ] Save and `commit` your code in your GitHub Project
- [ ] Add your github repo `as a comment` to your assignment in `Canvas`.
- [ ] Upload your walkthrough video to`Canvas`.