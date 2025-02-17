from unittest.mock import patch
from part3 import product_num_palindrome

# Test product_num_palindrome function
@patch('builtins.print')
def test_product_num_palindrome_2_by_2(mock_print):
    product_num_palindrome(2, 2)
    mock_print.assert_called_once_with('Max number for 2 by 2 is 9009')

@patch('builtins.print')
def test_product_num_palindrome_3_by_3(mock_print):
    product_num_palindrome(3, 3)
    mock_print.assert_called_once_with('Max number for 3 by 3 is 906609')