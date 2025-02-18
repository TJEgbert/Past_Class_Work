#!/usr/bin/env python3
# -*- coding: UTF-8 -*-

"""Name: Trevor Egbert
   Date: 9/27/2024
   Title: CS 4580 - Assignment 4. Data Correlation
   File: ca.py 
   Description: Does statistical analysis on Weather Data
   From 2007 to 2017
"""
import pandas as pd
import matplotlib.pyplot as plt
from matplotlib import interactive
import sys, os
import random
from sklearn.preprocessing import LabelEncoder
    

def load_data(file_path):
    """
    Loads data from a CSV file

    Args:
        file_path (str): The path to the CSV file containing the census data.

    Returns:
        pandas.DataFrame: A DataFrame containing the weather data
    """
    # TBD: Implement the function to load data
    df = pd.read_csv(file_path)
    return df


def get_start_end_date(data):
    """Gets the start and end date of the data

    Args:
        data (Pandas DataFrame): DataFrame containing Date column

    Returns:
        tuple: Contains earliest and latest dates from the date column
    """
    copy_df = data.copy()
    copy_df['Date'] = pd.to_datetime(copy_df['Date'])
    max_date = copy_df.Date.max()
    min_date = copy_df.Date.min()

    return min_date, max_date



def get_avg_min_temp_by_month(data):
    """Gets the average of MinTemp by month

    Args:
        data (Pandas DataFrame): DataFrame containing Date and MinTemp column

    Returns:
        Pandas Series: Containing the month with the average MinTemp
    """
    copy_df = data.copy()
    copy_df['Date'] = pd.to_datetime(copy_df['Date'])
    copy_df['Month'] = copy_df['Date'].dt.month
    avg_min_by_month = copy_df.groupby(['Month']).MinTemp.mean()
    return avg_min_by_month



def plot_avg_min_temp_by_month(avg_min_temp):
    """Plots the average minimum temp per month

    Args:
        avg_min_temp (DataFrame): Counting the average minimum tem per month
    """
    # Creates bar chart
    plt.figure(figsize=(10, 7))
    plt.bar(avg_min_temp.index, avg_min_temp.values)
    plt.xlabel('Month')
    plt.ylabel('Average Minimum Temperature')
    plt.title('Average Minimum Temperature by Month')

    # Saves the bar chart
    plt.savefig('plots/avg_min_temp_by_month.png')
    plt.show(block= False) # Prevents program stopping 

def get_unique_cities(data):
    """Returns the number of unique cities from the passed
       in DataFrame

    Args:
        data (Pandas DataFrame): DataFrame containing Location column
    Returns:
        int: The number of unique cities
    """
    unique_cities = data['Location'].unique()
    return unique_cities.shape[0]


def print_top_rainiest_cities(data, n=5):
    """Prints the top n rain cities

    Args:
        data (DataFrame): DataFrame containing Location and Rainfall column
        n (int, optional): The number of cities. Defaults to 5.

    Returns:
        list: List of names of n cities with the most rainfall
    """
    working_df = data[['Location', 'Rainfall']]
    top_n =working_df.groupby('Location').sum('Rainfall').sort_values('Rainfall', ascending=False).head(n)
    return top_n.index.to_list()
    

def print_univariate_values(data):
    """Prints out a few statistical measurements for some of the data

    Args:
        data (DataFrame): Pandas DataFrame
    """
    print(f'Mean Pressure9am: {data['Pressure9am'].mean():.2f}')
    mode = data['Humidity9am'].mode()
    print(f'Mode Humidity9am: {mode.iloc[0]:.2f}')
    print(f'Median WindGustSpeed: {data['WindGustSpeed'].median():.2f}')
    print(f'Standard Deviation Temp3pm: {data['Temp3pm'].std():.2f}')
    print(f'75th Percentile Rainfall: {data['Rainfall'].quantile(0.75):.2f}')
    print(f'Minimum MaxTemp: {data['MaxTemp'].min():.2f}')
    print(f'Maximum MinTemp: {data['MinTemp'].max():.2f}')
    print(f'Range WindSpeed9am: {(data.WindSpeed9am.max() - data.WindSpeed9am.min()):.2f}')
    print(f'Variance Evaporation: {data['Evaporation'].var():.2f}')
    print(f'Skewness Sunshine: {data['Sunshine'].skew():.2f}')
    


def fix_missing_values(data, column):
    """Fills missing values of a numerical column with
       the median.

    Args:
        data (DataFrame): The DataFrame containing the column
        column (String): The name of the columns you want to fill the nan values
    """
    if data[column].isnull().values.any():
        data[column] = data[column].fillna(data[column].median())
    

def get_correlation_two_vars(data, var1, var2, type_correlation='pearson'):
    """Gets the of var1 and var2 from the passed in data.
       Notes: var1 and va2 must be numeric columns

    Args:
        data (DataFrame): The DataFrame containing the columns for var1 and var2
        var1 (string): The name of the first column
        var2 (string): The name of the second column
        type_correlation (str, optional): The type of correlation you want to do
        Spearman of Pearson. Defaults to 'pearson'.

    Raises:
        ValueError: The passed in type_correlation is not pearson or spearman
        KeyError: Var1 or var2 are not a numeric column
        KeyError: Var1 or Var2 are not in data

    Returns:
        Tuple: Of the correlation and the p_value
    """
    from scipy.stats import pearsonr, spearmanr
    accepted_dtypes = ['int64', 'int32', 'float64', 'float32']
    if var1 in data.columns and var2 in data.columns:
        if data[var1].dtype in accepted_dtypes and data[var1].dtype in accepted_dtypes:
            if type_correlation == 'pearson' or type_correlation == 'spearman':
                if type_correlation == 'pearson':
                    corr, p_value = pearsonr(data[var1], data[var2])
                else:
                    corr, p_value = spearmanr(data[var1], data[var2])
                return corr, p_value
            else:
                raise ValueError('type_correlation must be pearson or spearman')
        else:
            raise KeyError('var1 or var2 column is not a numeric dtype')
    else:
        raise KeyError('var1 or var2 is not contained in the DataFrame')
        
    
def plot_correlation(data, var1, var2):
    """Plots the correlation between var1 and var2

    Args:
        data (DataFrame): The DataFrame containing var1 and var2
        var1 (string): The name of the first column
        var2 (string): The name of the second column
    """
    # Creates the scatter plot
    plt.figure(figsize=(10, 7))
    plt.scatter(data[var1], data[var2], alpha=0.5)
    plt.xlabel(var1)
    plt.ylabel(var2)
    plt.title(f'Scatterplot of {var1} vs {var2}')
    # Saves the scatter plot
    plt.savefig(f'plots/{var1}_vs_{var2}_scatterplot.png')
    plt.show(block= False)  # Prevents program stopping 


def encode_categorical_data(data, column):
    """Encodes the passed in categorical column

    Args:
        data (DataFrame): The DataFrame containing column
        column (string): Name of column to encode

    Returns:
        string: Name of the newly added column
    """
    le = LabelEncoder()
    new_column_name = f'{column}_encoded'
    data.loc[:, new_column_name] = le.fit_transform(data[column])

    data.drop(columns= [column], inplace =True)
    return new_column_name



def show_correlation_cities_rainfall(data, col1, col2, type_correlation='pearson'):
    """Calculates the correlation and p_value of col1, and col2.
       5 Records are randomly selected from data for this.
       If columns are not numeric it encode the columns to be able
       to do the correlation

    Args:
        data (DataFrame): The DateFrame containing col1 and col2
        col1 (string): The name of col1
        col2 (string): The name of col2
        type_correlation (str, optional): The type of correlation to do
        either pearson or spearman. Defaults to 'pearson'.

    Returns:
        Tuple: Containing correlation, p_value, the DataFrame with only 5 records
    """
    print('Warning data must be numeric for correlation calculation')
    cities_list = get_unique_cities(data)
    index_list = []
    five_city = []

    # Verifies if col1 and col2 need to be encoded
    if data[col1].dtype == 'object':
        col1 = encode_categorical_data(data, col1)
    if data[col2].dtype == 'object':
        col2 = encode_categorical_data(data, col2)
    # Gets 5 random cities with a random record
    for i in range(5):
        city_index = random.randrange(cities_list)
        # Makes sure the city hasn't already been chosen
        while city_index in index_list:
            city_index = random.randrange(cities_list)
        index_list.append(city_index)
        # Gets the random record from the city_index   
        ran_record = data[data[col1] == city_index]
        five_city.append(ran_record) # Add the row to list
    five_city_df = pd.concat(five_city) # Creates a DataFrame the list
    # Calls get_correlation_two_vars to get the correlation
    corr, p_value = get_correlation_two_vars(five_city_df, col1, col2, type_correlation)
    return corr, p_value, five_city_df


def main():
    # TASK 1: Get dataset from Kaggle
    # TASK 2: Load census data into a DataFrame
    print(f'Task 2: Load weather data into a DataFrame')
    census_data_file = 'data/weatherAUS.csv'
    data = load_data(census_data_file)
    print(f'Loaded {len(data)} records')

    # TASk 3: Print (to the console) the start to end of the time in days, months, and years.
    print(f'\nTask 3: Print the start and end of the time in days, months, and years')
    min_date, max_date = get_start_end_date(data)
    print(f'Start Date: {min_date}')
    print(f'End Date: {max_date}')

    # TASK 4: Print (to the console) the average MinTemp based on month (you should display 12 values).
    print(f'\nTask 4: Print the average MinTemp based on month')
    avg_min_temp = get_avg_min_temp_by_month(data)
    print(f'Average MinTemp by Month: {avg_min_temp}')

    # Task 5: Display this information in a bar chart (or histogram) using the 'matplotlib' or 'plotly' package. 
    # The x-axis should be the month and the y-axis should be the average MinTemp.
    print(f'\nTask 5: Display the average MinTemp by month in a bar chart')
    plot_avg_min_temp_by_month(avg_min_temp)

    # TASK 6: Get Unique Cities
    print(f'\nTask 6: Get Unique Cities')
    unique_cities = get_unique_cities(data)
    print(f'Unique Cities: {unique_cities}')

    # TASK 7: Print out the top five rainiest cities in the dataset.
    total = 5
    print(f'\nTask 7: Print the top five rainiest cities in the dataset')
    rainiest_cities = print_top_rainiest_cities(data, n=total)
    print(f'Top {total} Rainiest Cities: {rainiest_cities}')

    # TASK 8: Print out different univariate values 
    print(f'\nTask 8: Print univariate values')
    print_univariate_values(data)

    # TASK 9: Fix missing values
    print(f'\nTask 9: Fix missing values for MinTemp and Rainfall')
    col1 = 'MinTemp'
    fix_missing_values(data, col1)
    col2 = 'Rainfall'
    fix_missing_values(data, col2)
    
    # TASK 10: Show the correlation between MinTemp and Rainfall
    print(f'\nTask 10: Show the correlation between MinTemp and Rainfall')
    correlations = ['pearson', 'spearman']
    for correlation in correlations:
        corr, p_value  = get_correlation_two_vars(data, col1, col2, type_correlation=correlation)
        # Display p_value in scientific notation up to -22
        print(f'{correlation.capitalize()} Correlation ({col1}, {col2}): {corr:.6f}. P-value: {p_value:.21e}')   
        # TASK 10B: Explain the correlation in the console
        print('We can see from the correlation that there is a stronger correlation between MinTemp and Rainfall')
        print('From the p-value with being so small we have strong evidence that they are related')
    
    # TASK 10C: Plot the correlation
    plot_correlation(data, col1, col2)

    # Task 11: Second correlation
    correlation = 'pearson'
    col1 = 'Location'
    col2 = 'Rainfall'
    print(f'\nTask 11: Show the correlation between {col1} and {col2}')   
    corr, p_value, df = show_correlation_cities_rainfall(data, col1, col2, type_correlation=correlation)
    print(f'{correlation.capitalize()} Correlation ({col1}, {col2}): {corr:.6f}. P-value: {p_value:.21e}')   
    

if __name__ == '__main__':
    main()
