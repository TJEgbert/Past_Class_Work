"""Name: Trevor Egbert
   Date: 8/29/2024
   Title: Introduction to Python
   File: part2.py
   Description: Finds the index in the Fibonacci where the
   number of digits equal 3 and 1000  
"""

# Part 2 (from: https://projecteuler.net/problem=25)
# The Fibonacci sequence is defined by the recurrence relation:
#     Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
# Hence the first 12 terms will be:
#     F1 = 1 
#     F2 = 1
#     F3 = 2
#     F4 = 3
#     F5 = 5
#     F6 = 8
#     F7 = 13
#     F8 = 21
#     F9 = 34
#     F10 = 55
#     F11 = 89
#     F12 = 144

# The 12th term, F12, is the first term to contain three digits.
# What is the index of the first term in the Fibonacci sequence to contain 1000 digits?
# Hint: Do not use recursion!


def digitis_in_fibo(digits):
    """Finds the index of the Fibonacci sequence where the amount
    of digits is equal to the passed in amount

    Args:
        digits (int): The number of digits the user wants to find
    """

    index = 0
    # You may use this variable to store your result as a 
    # string and counting the number of digits
    number = '0'

    num1 = 1 # Stores the Fn-1 variable
    num2 = 0 # Stores the Fn-2 variable
    next_num = 0 # Stores the next number for num2
    while len(str(number)) != digits:
        index += 1 
        next_num = num1 + num2
        number = str(next_num)
        num1 = num2
        num2 = next_num
    
    # DO NOT ERASE
    print(f'For index {index}, it contains {len(number)} digits')
    
    
if __name__ == '__main__':
    digits = 3
    digitis_in_fibo(digits)  # test case
    digits = 1000
    digitis_in_fibo(digits)
    