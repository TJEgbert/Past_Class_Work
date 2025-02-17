"""Name: Trevor Egbert
   Date: 8/29/2024
   Title: Introduction to Python
   File: part3.py 
   Description: Finds the largest value palindrome product from numbers
   where there number of digits equal 2 and 2.  
   Then also with numbers where number of digits equal 3 and 3 
"""

# Part 3 (from: https://projecteuler.net/problem=4)
# A palindromic number reads the same both ways. The largest palindrome 
# made from the product of two 2-digit numbers is 9009 = 91 × 99.
# Find the largest palindrome made from the product of two 3-digit numbers.


def check_palindrome(num):
    """Checks if the given number is a palindrome

    Args:
        num (int): the number the user wants to check
        if its a palindrome

    Returns:
        bool: Returns true if the number is a palindrome
    """

    is_palindrome = False
    num_string = str(num)
    rev_string = num_string[::-1] # Reverse the string

    if num_string == rev_string:
        is_palindrome = True

    return is_palindrome


def loop_range(digits):
    """Gets the range of numbers based of how many digits

    Args:
        digits (int): The number of digits the user wants to check

    Returns:
        tuple: returns the starting and of the range
    """

    starting_range = 0
    ending_range = 0

    match digits: # Gets the correct range needed based of the digit
        case 1:
            starting_range = 0
            ending_range = 10
        case 2:
            starting_range = 10
            ending_range = 100
        case 3:
            starting_range = 100
            ending_range = 1000
        case 4:
            starting_range = 1000
            ending_range = 10000

    return starting_range, ending_range


def product_num_palindrome(num1, num2):
    """Prints the largest palindrome from the digits based in

    Args:
        num1 (int): Number of digits of the first set of numbers
        num2 (int): Number of digits of the first set of numbers
    """

    # You may use this variable to store the max value
    product = 0
    max_value = 0 
    num1_starting, num1_ending = loop_range(num1)
    num2_starting, num2_ending = loop_range(num2)

    # Loops through the required range of number
    for val1 in range(num1_starting, num1_ending):
        for val2 in range(num2_starting, num2_ending):
            product = val1 * val2
            if check_palindrome(product):
                if max_value < product:
                    max_value = product # Updates max_value if its less than product
    
    # DO NOT REMOVE
    print(f'Max number for {num1} by {num2} is {max_value}')


if __name__ == '__main__':
    # 2 by 2 calculation
    product_num_palindrome(2, 2)  # test case
    product_num_palindrome(3, 3) 