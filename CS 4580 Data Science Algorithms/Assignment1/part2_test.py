from unittest.mock import patch
from part2 import digitis_in_fibo

@patch('builtins.print')
def test_3_digitis_in_fibo(mock_print):
    digitis_in_fibo(3)
    mock_print.assert_called_once_with('For index 12, it contains 3 digits')
    

@patch('builtins.print')
def test_1000_digitis_in_fibo(mock_print):
    digitis_in_fibo(1000)
    mock_print.assert_called_once_with('For index 4782, it contains 1000 digits')