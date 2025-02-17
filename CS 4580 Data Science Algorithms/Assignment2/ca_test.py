import pytest
import pandas as pd
import numpy as np
from unittest.mock import patch

import ca  # This is the ca.py file

# Data file    
data_file = 'weatherHistory.csv'
df = pd.read_csv(data_file)


def test_print_top_records():
    # Print out the first 5 entries of 'Temperature (C).'
    colum = 'Temperature (C)'
    num = 5
    with patch('builtins.print') as mock_print:
        result = ca.print_top_records(df, colum, num)
        mock_print.assert_called_once_with('The top 5 of the Temperature (C) colum are: [9.47222222 9.35555556 9.37777778 8.28888889 8.75555556]')
    # Now for 10 entries
    num = 10
    with patch('builtins.print') as mock_print:
        result = ca.print_top_records(df, colum, num)
        mock_print.assert_called_once_with('The top 10 of the Temperature (C) colum are: [ 9.47222222  9.35555556  9.37777778  8.28888889  8.75555556  9.22222222\n  7.73333333  8.77222222 10.82222222 13.77222222]')


def test_print_bottom_records():
    colum = 'Temperature (C)'
    num = 5
    with patch('builtins.print') as mock_print:
        result = ca.print_bottom_records(df, colum, num)
        mock_print.assert_called_once_with('The bottom 5 of the Temperature (C) colum are: [26.01666667 24.58333333 22.03888889 21.52222222 20.43888889]')
    # Now for 10 entries
    num = 10
    with patch('builtins.print') as mock_print:
        result = ca.print_bottom_records(df, colum, num)
        mock_print.assert_called_once_with('The bottom 10 of the Temperature (C) colum are: [30.89444444 31.08333333 31.08333333 30.76666667 28.83888889 26.01666667\n 24.58333333 22.03888889 21.52222222 20.43888889]')


def test_print_min_max_std_all():
    colum = 'Temperature (C)'
    with patch('builtins.print') as mock_print:
        result = ca.print_min_max_std(df, colum)
        mock_print.assert_called_once_with('Min: -21.822222222222223, Max: 39.90555555555555, Std: 9.551546320657026')


def test_print_min_max_std_group_by_partly_cloudy():
    colum = 'Temperature (C)'
    filter_column = 'Summary'
    filter_column_value = 'Partly Cloudy'
    with patch('builtins.print') as mock_print:
        result = ca.print_min_max_std_group_by(df, colum, filter_column, filter_column_value)  # Std original: 9.447220867085175
        mock_print.assert_called_once_with('Partly Cloudy: Min: -20.55555555555556, Max: 39.58888888888889, Std: 9.44722086708517')


def test_print_min_max_std_group_by_foggy():
    colum = 'Temperature (C)'
    filter_column = 'Summary'
    filter_column_value = 'Foggy'
    with patch('builtins.print') as mock_print:
        result = ca.print_min_max_std_group_by(df, colum, filter_column, filter_column_value) # Std original: 5.756860300249743
        mock_print.assert_called_once_with('Foggy: Min: -21.822222222222223, Max: 23.66111111111111, Std: 5.756860300249747')


def test_print_min_max_std_group_by_overcast():
    colum = 'Temperature (C)'
    filter_column = 'Summary'
    filter_column_value = 'Overcast'
    with patch('builtins.print') as mock_print:
        result = ca.print_min_max_std_group_by(df, colum, filter_column, filter_column_value) # Std original: 7.112252687819718
        mock_print.assert_called_once_with('Overcast: Min: -16.11111111111111, Max: 33.644444444444446, Std: 7.112252687819746')


def test_add_column():
    new_column_name = 'Wind Bearing (radians)'
    from_column_name = 'Wind Bearing (degrees)'
    with patch('builtins.print') as mock_print:
        result = ca.add_column(df, new_column_name, from_column_name)
        mock_print.assert_called_once_with("count    96453.000000\nmean         3.272653\nstd          1.874194\nmin          0.000000\n25%          2.024582\n50%          3.141593\n75%          5.061455\nmax          6.265732\nName: Wind Bearing (radians), dtype: float64")


def test_filter_data_frame():
    filter_column = 'Humidity'
    column_value_min = 0.6
    column_value_max = 0.7
    with patch('builtins.print') as mock_print:
        result = ca.filter_data_frame(df, filter_column, column_value_min, column_value_max)
        mock_print.assert_called_once_with("count    12220.000000\nmean         0.652871\nstd          0.031530\nmin          0.600000\n25%          0.630000\n50%          0.650000\n75%          0.680000\nmax          0.700000\nName: Humidity, dtype: float64")

if __name__ == '__main__':
    pytest.main()