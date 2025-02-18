#!/usr/bin/env python3
# -*- coding: UTF-8 -*-
"""Name: Trevor Egbert
   Date: 9/27/2024
   Title: CS 4580 - Assignment 3. Census Data Analysis
   File: ca.py 
   Description: Does data analysis on a set of 2015
   census data
"""

import pandas as pd
import sys, os
import zipfile as ZipFile


def extract_census_data(zip_file):
    """Unzips the file from the data folder

    Args:
        zip_file (String): the name of the zipfile to unzip
    """
    with ZipFile.ZipFile(zip_file, 'r') as zObject:
        zObject.extractall('/data')
    

def load_census_data(file_path):
    """Loads in the census data into a DataFrame and drops
        all records from Puerto Rico

    Args:
        file_path (String): The path of the file to turn into
        a DataFrame

    Returns:
        DataFrame: of the census data passed in 
    """
    census_df = pd.read_csv(file_path, encoding='latin-1')
    census_df = census_df[census_df.State != 'Puerto Rico']
    return census_df


def get_max_state_population_by_race(data, race):
    """Gets the state with the highest population of the
       passed in race

    Args:
        data (DataFrame): The data that is going to be working with
        race (String): The race to check in the data for

    Returns:
        Tuple: (State, highest population)
    """
    working_df = data.copy()

    # Calculate race population for each county
    working_df['RacePop'] = (working_df[race] / 100) * working_df.TotalPop
    # Groups records by state and sums up the RacePop
    by_state_df = working_df.groupby('State', as_index=False).agg(total= ('RacePop', 'sum'))
    
    max_record = by_state_df.loc[by_state_df['total'].idxmax(), ['State', 'total']]
    return max_record.State, int(max_record['total'])
            

def get_unemployment_rate(data, rate):
    """Gets the highest or lowest unemployment rate by state

    Args:
        data (DataFrame): The data that is going to be working with
        rate (String): highest or lowest 

    Returns:
        Tuple: (State, Unemployment rate in percentage)
    """
    working_df = data.copy()
    # Get the number of unemployed people per county
    working_df['UnemployedPeople'] = (working_df.Unemployment / 100) * working_df.TotalPop
    # Get the total unemployed people per state
    by_state_df = working_df.groupby('State', as_index=False).agg(total_pop= ('TotalPop', 'sum'), total_unemployed= ('UnemployedPeople', 'sum'))
    # Calculate the unemployment rate
    by_state_df['UnemploymentRate'] = by_state_df.total_unemployed /by_state_df.total_pop
    
    # Gets the correct row based off of passed in rate
    match rate:
        case 'lowest':
            return_set = by_state_df.loc[by_state_df['UnemploymentRate'].idxmin(), ['State', 'UnemploymentRate']]
        case 'highest':
            return_set = by_state_df.loc[by_state_df['UnemploymentRate'].idxmax(), ['State', 'UnemploymentRate']]

    return return_set.State, return_set['UnemploymentRate'] * 100

def get_income_inequality(data):
    """ Finds the census data that has the highest inequality in income and poverty

    Args:
        data (DataFrame): The data that is going to be working with

    Returns:
        DataFrame: With the filtered data
    """
    filtered_df = data[(data.Poverty > 50) & (data.Income >=50000)]
    return_df = filtered_df[['CensusTract', 'State', 'County', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific', 'Income', 'Poverty']]
    return return_df


def get_total_feminine_population(data):
    """Gets the census data where the population is majority women

    Args:
        data (DataFrame): The data that is going to be working with

    Returns:
        DataFrame: With the filtered data
    """
    # Gets records where there are more women then men
    filtered_df = data[data.Women > data.Men]
    # Gets data where population is greater than 10000
    filtered_df = filtered_df[filtered_df.TotalPop > 10000]
    # Calculates the percentage of women
    filtered_df['PercentWomen'] = filtered_df.Women / filtered_df.TotalPop
    # Filters data where the PercentWomen > 0.57
    filtered_df = filtered_df[filtered_df.PercentWomen > 0.57]

    # Gets records ready to return
    return_df = filtered_df[['CensusTract', 'State', 'County', 'TotalPop', 'Women', 'Men', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific', 'Income', 'Poverty']]
    return return_df


def check_rows(row):
    """Adds a new row Yes set its to True of False

    Args:
        row (Series): Row of the census data

    Returns:
        Series: The row with updated Yes row
    """
    # Gets the working row
    working = row[['Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific']].to_numpy()
    total = (working >= 15).sum() # Counts how many columns >= 15
    if total > 3: # If more than >
        row['Yes'] = True 
    else:
        row['Yes'] = False
    return row



def get_most_diverse_racially(data):
    """Gets the census record where the it has the greatest
       race diversity

    Args:
        data (DataFrame): The data that is going to be working with

    Returns:
        DataFrame: With the filtered data
    """
    filtered_df = data[['CensusTract', 'State', 'County', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific']]
    # Fills all the NAN values to 0
    clean_df = filtered_df.fillna(0)
    clean_df = clean_df.apply(check_rows, axis='columns') # Adds the new column
    # Gets the records where yes is True
    return_df = clean_df[clean_df.Yes == True]
    # drops yes column
    df = return_df.drop('Yes', axis=1)
    return df




def main():
    """
    Main function to execute the census data analysis.

    This function serves as the entry point for the census data analysis script.
    It orchestrates the loading, processing, and analysis of census data, and
    outputs the results.

    Steps performed by this function:
    1. Load the census data from a specified source.
    2. Process the data to clean and prepare it for analysis.
    3. Perform various analyses on the processed data.
    4. Output the results of the analyses.

    Returns:
        None
    """
    print('Assignment 3: Census Data Analysis')
    # TASK 1: Get data from Kaggle

    # TASK 2: Load census data into a DataFrame
    print(f'Task 2: Load census data into a DataFrame')
    census_data_file = 'data/acs2015_census_tract_data.csv'
    data = load_census_data(census_data_file)
    print(data.head())
    
    # # Task 3: Find state with highest population density based on race
    print(f'\nTask 3: Find state with highest population density based')
    races = ['Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific']
    for race in races:
        max_state, max_population = get_max_state_population_by_race(data, race)
        print(f'Max state for {race}: {max_state} with population {int(max_population)}')
    
    # # Task 4: Report Unemployment by state
    print(f'\nTask 4: Part 2: Report Unemployment by state')
    state, unemployment_rate = get_unemployment_rate(data, 'highest')
    print(f'Highest state for unemployment: {state} with unemployment rate {unemployment_rate:.2f}') 
    state, unemployment_rate = get_unemployment_rate(data, 'lowest')
    print(f'Lowest state for unemployment: {state} with unemployment rate {unemployment_rate:.2f}') 
    
    # Task 5: Report the census tract(s) that have drastic income inequality. 
    print(f'\nTask 5: Report the census tract(s) that have drastic income inequality')
    records = get_income_inequality(data)
    print(records)
    print(records.shape)

    # Task 6: Report the census tract(s) that are mostly feminine.
    print(f'\nTask 6: Report the census tract(s) that are mostly feminine')
    records = get_total_feminine_population(data)
    print(records)
    print(records.shape)

    # Task 7: Report the census tract(s) that are the most diverse racially.
    print(f'\nTask 7: Report the census tract(s) that are the most diverse racially')
    records = get_most_diverse_racially(data)
    print(records)
    print(records.shape)


if __name__ == '__main__':
    main()
