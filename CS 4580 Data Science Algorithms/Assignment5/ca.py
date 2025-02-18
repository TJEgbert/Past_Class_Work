#!/usr/bin/env python3
# -*- coding: UTF-8 -*-

"""
Name: Trevor Egbert
Date: 11/2/2024
Title CS 4580 - Assignment 5. Titanic Crew Analysis
File: ca.py 
"""
import sys
import os
import requests
import pandas as pd
from scipy import stats
from statsmodels.formula.api import ols
import statsmodels.api as sm
from statsmodels.stats.multicomp import MultiComparison
from statsmodels.stats.multicomp import pairwise_tukeyhsd
from scipy.stats import pearsonr, spearmanr
from sklearn import preprocessing

# from sklearn.preprocessing import LabelEncoder
import matplotlib.pyplot as plt
import seaborn as sns

# Constants
ICARUS_CS4580_DATASET_URL = 'http://icarus.cs.weber.edu/~hvalle/cs4580/data'
DATA_FOLDER = 'data'


def download_dataset(url, data_file, data_folder=DATA_FOLDER):
    """
    Downloads a dataset from a specified URL and saves it to a local directory.
    Parameters:
    url (str): The base URL where the dataset is hosted.
    data_file (str): The name of the dataset file to be downloaded.
    data_folder (str): The name of the data folder to store data
    Returns:
    None
    Side Effects:
    - Creates a directory if it does not exist.
    - Downloads the dataset file and saves it to the specified directory.
    - Prints messages indicating the status of the download process.
    Notes:
    - If the dataset file already exists in the specified directory, the function will not download it again.
    - If the download fails, an error message will be printed.
    """

    # Check if the data folder exists and file_path is a valid path
    if not os.path.exists(data_folder):
        os.makedirs(data_folder)
        print(f'Created folder {data_folder}')
    # Check if the file already exists
    data_folder = os.path.join(data_folder, data_file)
    if os.path.exists(data_folder):
        print(f'Dataset {data_file} already exists in {data_folder}')
        return

    # Include file name to url server address
    url = f'{url}/{data_file}'
    # Download the dataset from the server to DATA_FOLDER
    response = requests.get(url)
    if response.status_code == 200:
        with open(data_folder, 'wb') as f:
            f.write(response.content)
        print(f'Downloaded dataset {data_file} to {data_folder}')
    else:
        print(f'Error downloading dataset {data_file} from {url}')


def load_data(file_path):
    """
    Load data from a CSV file into a pandas DataFrame.

    Parameters:
    file_path (str): The path to the CSV file.

    Returns:
    DataFrame: Returns a pandas DataFrame if the file exists and is a valid CSV file.

    Raises:
    ValueError: If the file is not a valid CSV file.
    FileNotFoundError: If the file does not exist.
    """
    # Check if file is csv format
    if not file_path.endswith('.csv'):
        print(f'File {file_path} is not a valid CSV file')
        raise ValueError
    # Check if data is a valid file path or raise an error
    if not os.path.exists(file_path):
        print(f'File {file_path} does not exist')
        raise FileNotFoundError

    # Load the data into a DataFrame
    df = pd.read_csv(file_path)
    return df


def remove_column(data, column):
    """Removes the column from the passed in DateFrame

    Args:
        data (DataFrame): The data that the user wants to drop the column from
        column (str): Name of the column
    """
    data.drop(columns=column, inplace=True)


def null_removal_by_column(data, column):
    """Drops all the rows with missing value in a column from

    Args:
        data (DataFrame): The data that the user wants to drop rows from
        column (str): Name of the column
    """
    data.dropna(subset=[column], inplace=True)


def rename_column(data, old_name, new_name):
    """Renames the column in the passed in DataFrame

    Args:
        data (DataFrame): The data the contains the column the user wants to rename
        old_name (str): current name of column
        new_name (str): new name for column
    """
    data.rename(columns={old_name: new_name}, inplace=True)


def chi2_test(data, indepen, depen):
    """Does a chi square analysis on the passed in variables and prints the results

    Args:
        data (DataFrame): The data the contains the variables
        indepen (str): name of the independent variable
        depen (str): name of the dependent variable
    """
    # Creates a contingency table from the passed in variables
    contingency_table = pd.crosstab(data[indepen], data[depen])
    # Does the chi square analysis
    results = stats.chi2_contingency(contingency_table)
    # Prints results
    print(f'independent variable: {indepen}, Dependent variable: {depen}')
    print(f'statistic: {results.statistic}')
    print(f'p-value: {results.pvalue}')
    print(f'Degree of Freedom: {results.dof}\n')


def Anova_test(data, indepen, depen):
    """Does an ANOVA analysis on the passed in variables and prints the results

    Args:
        data (DataFrame): The data the contains the variables
        indepen (str): name of the independent variable
        depen (str): name of the dependent variable
    """
    # Trains ols model with the passed in variable and data
    model = ols(f'{depen} ~ {indepen}', data=data).fit()
    # Does the ANOVA analysis
    anova_table = sm.stats.anova_lm(model)
    # Prints results
    print(anova_table)


def tukey_test(data, indepen, depen):
    """Does an tukey analysis on the passed in variables and prints the results

    Args:
        data (DataFrame): The data the contains the variables
        indepen (str): name of the independent variable
        depen (str): name of the dependent variable
    """
    # Creates a DataFrame from the of the independent and dependent variables
    tukey_df = data[[indepen, depen]]
    # Does the comparison between the two variables
    mc = MultiComparison(tukey_df[depen], tukey_df[indepen])
    # Gets the results of the Tukey analysis
    results = mc.tukeyhsd()
    # Prints results
    print(results.summary())


def calc_correlation(data, col1, col2):
    """Does a Pearson and Spearman correlation and prints there results

    Args:
        data (DataFrame): The data the contains the columns
        col1 (str): The fist column do correlate with
        col2 (str): The second column do correlate with
    """
    print(f'Correlation between {col1}, and {col2}')
    # Does a Pearson Correlation and prints the results
    corr, p_values = pearsonr(data[col1], data[col2])
    print(f'Pearson correlation is: {corr}')
    # Does a Spearman Correlation and prints the results
    corr, p_values = spearmanr(data[col1], data[col2])
    print(f'Spearman correlation is: {corr}')


def plot_barchart(data, x_var, y_var, margin=0.0):
    """Plots a bar chart of the passed in variables and saves it to the plots folder

    Args:
        data (DataFrame): The data the contains the columns
        x_var (str): The name of the column used for the x-axis
        y_var (str): The name of the column used for the y-axis
        margin (float, optional): Used to set the margin on the bottom plot. Defaults to 0.0.
    """
    # Creates a contingency table from the passed in data and variables
    contingency_table = pd.crosstab(data[x_var], data[y_var])
    # Creates bar chart
    contingency_table.plot(kind='bar', figsize=(16, 10))
    # Formats the margins accordingly
    if margin != 0.0:
        plt.subplots_adjust(bottom=margin)
    # Formats and saves the bar chart
    plt.xlabel(x_var)
    plt.ylabel(y_var)
    plt.title(f'Barshart {y_var} vs {x_var}')
    plt.savefig(f'plots/{y_var}_vs_{x_var}.barchart.png')
    plt.show(block=False)


def encode_column(data, column):
    """Creates a new column of the encoded values from passed in column with a LabelEncoder
       Then it prints what the classes got encoded to

    Args:
        data (DataFrame): The data the contains the columns
        column (str): name of column to encode
    """
    # Creates a label encoder
    le = preprocessing.LabelEncoder()
    # Encodes label
    data[f'{column}_encoded'] = le.fit_transform(data[column])
    # Creates a dictionary of classes and there encoded values
    res = {}
    for cl in le.classes_:
        res.update({cl: le.transform([cl])[0]})
    # Prints encoded values
    print(res)


def main():
    # TASK 1: Get dataset from server
    print('-------------------------------- Task 1 --------------------------------\n')
    print(f'Task 1: Download dataset from server')
    dataset_file = 'TitanicCrew.csv'
    download_dataset(ICARUS_CS4580_DATASET_URL, dataset_file)
    # TASK 2: Load  data_file into a DataFrame
    print(f'Task 2: Load weather data into a DataFrame')
    data_file = f'{DATA_FOLDER}/{dataset_file}'
    data = load_data(data_file)
    print(f'Loaded {len(data)} records')


    print('\n-------------------------------- Task 2 --------------------------------\n')
    # Part 1: Drop Unnecessary Columns
    remove_column(data, 'URL')
    print(data.columns)
    # Part 2: Filter Data Based on Survival Status
    null_removal_by_column(data, 'Survived?')
    print(data['Survived?'].unique())
    # Part 3: Rename Column
    rename_column(data, 'Survived?', 'Lost_Survived')
    print(data.columns)


    print('\n-------------------------------- Task 3 --------------------------------\n')
    dependent = 'Lost_Survived'
    print('-------------------- Part 1 --------------------\n')
    independent = 'Gender'
    chi2_test(data, independent, dependent)
    print('We can see from the p-value being less than 0.05 and relatively statistic score stat we can see there is a statistical relationship between gender and if someone lived or died.')

    print('\n-------------------- Part 2 --------------------\n')
    independent = 'Class/Dept'
    chi2_test(data, independent, dependent)
    print('We can see with p-values less than 0.05 and statistic score of 82.97 that is statistical relationship between Class/Dept and crew.')

    print('\n-------------------- Part 3 --------------------\n')
    independent = 'Joined'
    chi2_test(data, independent, dependent)
    print('From the results we can see there is no relationship between Joined and Lost_Survived.  With a statistic score of 0 and a p-value of 1 means there is no relationship.')


    print('\n-------------------------------- Task 4 --------------------------------\n')
    print('-------------------- Part 1 --------------------\n')
    rename_column(data, 'Class/Dept', 'Class_Dept')
    dependent = 'Age'
    independent = 'Class_Dept'
    Anova_test(data, independent, dependent)
    print('\nFrom the ANOVA Test we see again from the PR(>F) value (p-value) that there is some type of distribution of age between Class/Dept and their ages.')

    print('\n-------------------- Part 2 --------------------\n')
    tukey_test(data, independent, dependent)
    print('There were a couple of groups where age was significant age difference...')
    print('- Deck Crew and Restaurant Staff')
    print('- Deck Crew Titanic Officers and Restaurant Staff')
    print('- Engineering Crew and Restaurant Staff')
    print('- Restaurant Staff and Victualling Crew')
    print('- Restaurant Staff and Victualling Crew Postal Clerk')
    print('\n-------------------- Part 3 --------------------\n')

    print('From the ANOVA test we saw there was some type of age distribution between the different Class/Dept.')
    print('Doing a Tukey analysis, we see there are five groups that their age is significantly different.')
    print('One group that shows up is in every group is restaurant staff.')
    print('So, this either means they are significantly younger or older from the other groups.')
    print('Looking at Deck Crew and Restaurant staff age frequently we see that 57 percent of restaurant staff is 25 of younger.')
    print('While for the Deck Crew only 11 percent are 25 or younger.')


    print('\n-------------------------------- Task 5 --------------------------------\n')
    # Part 1
    data['is_female'] = data['Gender'].map(lambda x: 1 if x == 'Female' else 0)
    data['is_male'] = data['Gender'].map(lambda x: 1 if x == 'Male' else 0)
    data['Survived'] = data['Lost_Survived'].map(
        lambda x: 0 if x == 'LOST' else 1)
    
    print('\n-------------------- Part 2 --------------------\n')
    calc_correlation(data, 'is_female', 'Survived')
    calc_correlation(data, 'is_male', 'Survived')

    print('\n-------------------- Part 3 --------------------\n')
    print("""We can see between is_female and Survived has a slight positive correlation of 0.24 for both the Pearson and Spearman correlations.
          \nWhile on the other hand for is_male there is a slight negative correlation of -0.24 for both correlation methods.\n""")
    
    print("""For the Pearson correlation score means there is linear relationship meaning for is_female there is a positive trend.
          \nThis means that if trend continues females are more likely to live over males.\nThen the opposite can be said for is_male.
          \nWith a negative trend means males are more likely to die.\n""")
    
    print('For the Spearman correlation with this checking if there is a monotonic relationship.\nThis meaning there is more curve trend to the data over a straight line.')

    print('\n-------------------- Part 4 --------------------\n')
    print("""With our correlations we can see the women have a slight positive correlation with surviving.
          \nWhile men on the other hand had a slight negative correlation with surviving.
          \nWith this being a subset of the Titanic data.\nWe can say with our findings that women are more likely to survive over men in the full data set.""")
    

    print('\n-------------------------------- Task 6 --------------------------------\n')
    # Part 1
    plot_barchart(data, 'Gender', 'Lost_Survived')
    plot_barchart(data, 'Nationality', 'Lost_Survived', 0.22)
    plot_barchart(data, 'Class_Dept', 'Lost_Survived', 0.30)

    print('-------------------- Part 2 --------------------\n')
    print('From Gender and Survived we can see that males outnumber women by an extreme amount for our data set.\nWe can see more women survived then died while the opposite is true for men.\n')
    print('For Nationality and Survived that most passengers where English.\nThen more people of each nationality died then survived.\n')
    print("""For Class_Dept and Survived we see that Victualling Crew had the most crewmen with the Engineering Crew close second.
          \nDeck Crew is the only Class_Dept where more survived then died.\nWhile Victualling Crew Postal Clerks all seem to have died.\n""")

    print('\n-------------------------------- Task 7 --------------------------------\n')
    encode_column(data, 'Class_Dept')
    encode_column(data, 'Gender')
    pair_plot_df = data[['Age', 'Class_Dept_encoded',
                         'Gender_encoded', 'Survived']]
    sns.pairplot(pair_plot_df)
    plt.savefig('plots/pairplot.png')
    plt.show(block=False)
    print('-------------------- Part 2 --------------------\n')
    print("""From the pair plot we can see a couple of interesting trends.
          \nFirst verifying the previous bar chart of Class_Dept that Victualling Crew Postal Clerk no one in that department survived.
          \nWe also can see for the people that survived their ages range from around 10 to 60.
          \nWhile for people who did not survive, their ages covered a large range from around 5 to 70.
          \nAlso, we can confirm our Tukey analysis we can see that restaurant staff (4) that most of the staff falls under the age of 40 with a cluster around the 20.
          \nThen we can also so that mostly men (1) where hired for the crew over women.
          \nOne conclusion we can make is that being a woman in the age range of 10 to 60 and not working as crew would give a person the best chance of surviving.\n""")


if __name__ == '__main__':
    main()
