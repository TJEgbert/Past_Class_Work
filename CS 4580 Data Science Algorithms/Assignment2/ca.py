"""Name: Trevor Egbert
   Date: 9/13/2024
   Title: Introduction to Pandas library
   File: ca.py 
   Description: Reads in Kaggle - Weather Dataset and
   does some data manipulation using the Pandas library
"""
# import pandas package
import pandas as pd
import numpy as np
from zipfile import ZipFile
from datetime import date
import os


def unzip_data(zip_file_name, csv_file_name):
    """Unzip the file and return the data frame from the csv file

    Args:
        zip_file_name (str): Zip file to unzip
        csv_file_name (str): csv file to read from zip file
    
    Returns:
        dataFrame: data frame from the csv file
    """
    with ZipFile(zip_file_name, 'r') as zObject:
        zObject.extractall('.')
    
    df_return = pd.read_csv(csv_file_name)
    return df_return


def print_top_records(data_frame, column_name, num_records):
    """Print records from the top of the data frame

    Args:
        data_frame (pdDataFrame): DataFrame to read from
        column_name (str): Column name to read from
        num_records (int): Number of records to read
    """
    arr = [] # Use this array to store final values
    # TODO: Do your code
    arr = data_frame[column_name].head(num_records).to_numpy()     
    print(f'The top {num_records} of the {column_name} colum are: {arr}') # DO NOT CHANGE THIS LINE


def print_bottom_records(data_frame, column_name, num_records):
    """Print records from the bottom of the data frame

    Args:
        data_frame (pandas dataFrame): data frame to read from
        column_name (str): Column name to read from
        num_records (int): Number of records to read
    """
    arr = [] # Use this array to store final values
    # TODO: Do your code
    arr = data_frame[column_name].tail(num_records).to_numpy()     
    print(f'The bottom {num_records} of the {column_name} colum are: {arr}') # DO NOT CHANGE THIS LINE


def print_min_max_std(data_frame, column_name):
    """Print min, max, and standard deviation of the column

    Args:
        data_frame (pandas dataFrame): data frame to read from
        column_name (str): Column name to read from
    """
    min_val = 0
    max_val = 0
    std_val = 0
    # TODO: Do your code
    min_val = data_frame[column_name].min()
    max_val = data_frame[column_name].max()
    std_val = data_frame[column_name].std()
    
    print(f'Min: {min_val}, Max: {max_val}, Std: {std_val}') # DO NOT CHANGE THIS LINE


def print_min_max_std_group_by(data_frame, column_name, filter_column, filter_column_value):
    """Print min, max, and standard deviation of the column for a group

    Args:
        data_frame (pandas dataFrame): data frame to read from
        column_name (str): Column name to read from
        filter_column (str): Column to filter by
        filter_column_value (str): Value to filter by
    """
    min_val = 0
    max_val = 0
    std_val = 0
    # TODO: Do your code
    df_filtered = data_frame.loc[data_frame[filter_column] == filter_column_value]
    min_val = df_filtered[column_name].min()
    max_val = df_filtered[column_name].max()
    std_val = df_filtered[column_name].std()

    
    print(f'{filter_column_value}: Min: {min_val}, Max: {max_val}, Std: {std_val}') # DO NOT CHANGE THIS LINE


def add_column(data_frame, new_column_name, from_column_name):
    """Add a column to the data frame
        Use the describe function to print out the statistics of the new column

    Args:
        data_frame (pandas dataFrame): data frame to add to
        new_column_name (str): Column name to add
        from_column_name (numpy array): Column name to take data from
    """
    # TODO: Do your code
    degree_arr = data_frame[from_column_name].to_numpy()
    radian_arr = np.deg2rad(degree_arr)
    data_frame[new_column_name] = radian_arr.tolist()
    
    print(f'{data_frame[new_column_name].describe()}') # DO NOT CHANGE THIS LINE


def filter_data_frame(data_frame, filter_column, column_value_min, column_value_max): 
    """Using filtering, create a new dataframe that only has values 
    where the filter_column is >= column_value_min and <= colum_value_max.
    With this new dataset use the 'describe' function on the new_column

    Args:
        data_frame (pandas dataFrame): data frame to filter
        filter_column (str): Column to filter by
        column_value_min (float): Min value to filter from
        column_value_max (float): Max Value to filter to

    Returns:
        pandas dataFrame: Filtered data frame
    """
    new_data_frame = None # Use this variable to store the new data frame
    # TODO: Do your code
    new_data_frame = data_frame.loc[(data_frame[filter_column] >= column_value_min) & (data_frame[filter_column] <= column_value_max)]


    print(f'{new_data_frame[filter_column].describe()}') # DO NOT CHANGE THIS LINE
    return new_data_frame
    

def main():
    """Sample driver. This function has all the test cases for the functions above.
    """
    zip_file_name = 'weather-dataset.zip' # DO NOT CHANGE THIS VARIABLE NAME
    csv_file_name = 'weatherHistory.csv'  # DO NOT CHANGE THIS VARIABLE NAME
    
    # Task 1: Unzip file_name from the current directory and return dataframe from csv_file_name
    df = unzip_data(zip_file_name, csv_file_name)

    # Task 2: Print out the first 5 entries of 'Temperature (C).'
    column_name = 'Temperature (C)'
    num_records = 5
    print_top_records(df, column_name, num_records)

    # Task 3: Print out the last 5 entries of 'Temperature (C).' without the index
    print_bottom_records(df, column_name, num_records)

    # Task 4: Print out the min, max, and standard deviation for the 'Temperature (C)' column.
    print_min_max_std(df, column_name)

    # Task 5: Use groupby to show the min, max, and standard deviation for the 'Temperature (C)' for the following groups:
    # Task 5A: Summary column, Value = 'Foggy'
    filter_column = 'Summary'
    filter_colum_value = 'Foggy'
    print_min_max_std_group_by(df, column_name, filter_column, filter_colum_value)
    # Task 5B: Summary column, Value = 'Partly Cloudy'
    filter_colum_value = 'Partly Cloudy'
    print_min_max_std_group_by(df, column_name, filter_column, filter_colum_value)
    # Task 5C: Summary column, Value = 'Overcast'
    filter_colum_value = 'Overcast'
    print_min_max_std_group_by(df, column_name, filter_column, filter_colum_value)
    
    # Task 6: Add column 'Wind Bearing (radians)' to the dataframe that converts 'Wind Bearing (degrees)' to radians.
    new_column_name = 'Wind Bearing (radians)'
    from_column_name = 'Wind Bearing (degrees)'
    add_column(df, new_column_name, from_column_name)
    
    # Task 7: Create a new dataframe that only has values where the 'Humidity' is >= 0.6 and <= 0.7.  
    filter_column = 'Humidity'
    column_value_min = 0.6
    column_value_max = 0.7
    new_data_frame = filter_data_frame(df, filter_column, column_value_min, column_value_max)


    # Task 8 Part 1:
    max_time = df['Formatted Date'].max() # Gets the latest date
    min_time = df['Formatted Date'].min() # Gets the earliest data
    
    # Converts the dates into datetime
    max_date = date(int(max_time[0:4]), int(max_time[5:7]), int(max_time[8:10]))
    min_date = date(int(min_time[0:4]), int(min_time[5:7]), int(min_time[8:10]))
    
    # Gets the amount of years, month, days between the two dates
    years_between = max_date.year - min_date.year
    months_between = max_date.month - min_date.month
    days_between = max_date.day - min_date.day
    print(f' Years: {years_between}, Months: {months_between}, Days:{days_between}')

    # Task 8 Part 2:

    # Temperature
    descrip = df['Temperature (C)'].describe()
    print(descrip)

    # Humidity
    print(df['Humidity'].describe())

    # Windy
    print(df['Summary'].unique()) # Gets all the unique date from the Summary columns
    df_windy = df[df['Summary'].str.contains('Windy')] # Searches Summary for the word Windy
    df_breezy = df[df['Summary'].str.contains('Breezy')] # Searches Summary for the word Breezy
    print(len(df_windy)) # Prints how many record where returned
    print(len(df_breezy)) # Prints how many record where returned

if __name__ == '__main__':
    main()
