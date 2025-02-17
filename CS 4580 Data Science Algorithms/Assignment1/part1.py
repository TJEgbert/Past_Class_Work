"""Name: Trevor Egbert
   Date: 8/29/2024
   Title: Introduction to Python
   File: part1.py 
   Description: Finds sum of factorial of 100
"""

from math import factorial as fact

# Part 1 (from: https://projecteuler.net/problem=20)
# n! means n × (n − 1) × ... × 3 × 2 × 1
# For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
# and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
# Find the sum of the digits in the number 100!


def number_of_digits(number):
    """Adds together all digits of the factorial of the number passed in

    Args:
        number (int): The number the user want to know the sum of the factorial digits
    """

    number_sum = 0

    fact_answer = str(fact(number)) #converts the factorial to a string
    for num in fact_answer:
        number_sum += int(num) # loops through the string adding each digit together

    # DO NOT erase
    print(f'The sum of digits for {number}! is: {number_sum}')
    

if __name__ == '__main__':
    number = 100
    number_of_digits(number) 