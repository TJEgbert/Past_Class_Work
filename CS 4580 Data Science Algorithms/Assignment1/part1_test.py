from unittest.mock import patch
from part1 import number_of_digits

def test_print_statement():
    number = 100
    with patch('builtins.print') as mock_print:
        number_of_digits(number)
        mock_print.assert_called_once_with('The sum of digits for 100! is: 648')

def test_print_statement_for_10():
    number = 10
    with patch('builtins.print') as mock_print:
        number_of_digits(number)
        mock_print.assert_called_once_with('The sum of digits for 10! is: 27')