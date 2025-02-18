#!/usr/bin/env python3
# -*- coding: UTF-8 -*-

"""
Name: Trevor Egbert
Date: 11/15/2024
Title CS 4580 - Assignment 6. Movie Recommendation Engine (Part I)
File: ca.py 
"""
import sys
import os
import requests
import pandas as pd
# from sklearn.preprocessing import LabelEncoder
# import matplotlib.pyplot as plt

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


def data_cleaning(df):
    """Splits the title into year and title

    Args:
        df (Pandas DataFrame): DataFrame to update
    """
    df['year'] = df['title'].map(lambda x: x[-5: -1])
    df['title'] = df['title'].map(lambda x: x[:-7])


def _random_selection(df, num_samples):
    """Gets a number of randoms samples from the passed in DataFrame

    Args:
        df (Pandas DataFrame): Gets the random records from
        num_samples (int): The number of random records needed

    Returns:
        Pandas DataFrame: Contains the returned samples
    """
    data = df.sample(num_samples)
    return data


def print_movies(df):
    """ Prints the movies from the passed in DataFrame

    Args:
        df (Pandas DataFrame): Containing movie information
    """
    counter = 1
    # Loops through all the records in the passed in DataFrame
    for index, movie in df.iterrows():
        g = str(movie['genres']) # Gets the genres and turns to a string
        g = g.replace('|', ', ') # replace | with ,
        # Prints the info about the movie
        print(f"""[{counter}] Title:[{movie['title']}] Release Year:[{
            movie['year']}] Genres:[{g}]""")
        counter += 1


def is_int(s):
    """Checks to see if the passed in can be converted to an int

    Args:
        s (string): The string to check if it is an int

    Returns:
        bool: True if it is a number false if not
    """
    try:
        int(s)
    except ValueError:
        return False
    else:
        return True


def display_menu(search_state, filter_state):
    """Displays the menu according to the current state of the program

    Args:
        search_state (bool): If true displays search related menu options
        filter_state (bool): If true display filter related menu options
    """
    print(
        '------------------------------- Menu ------------------------------')
    if not search_state: # if not in the search state
        print('Type the related number of movie to add it to your Selection:\n')
        if not filter_state: # if not in the filter state
            print('To search type [search]')
            print(
                'To change the amount the number recommendation type [update]')
        else: # in the filter state
            print('To clear search term type [clear]')
        print('To quite please type [close]')
        print('Type the related number of movie to add it to your Selection:\n')
    else: # in search state
        print('Please type the number of the type of search:')
        print('[1] Release Year')
        print('[2] Title or Key Words in Title')
        print('To go back recommendation list type [back]')
    print('-------------------------------------------------------------------')


def add_movie_to_selection(data, move_to, id):
    """Adds a movie to the selected DataFrame

    Args:
        data (Pandas DataFrame): The base DataFrame to get the record
        move_to (Pandas DataFrame): The DataFrame to move the record to
        id (int): The id of the movie

    Returns:
        DataFrame: The update move_to DataFrame
    """
    record = data[data['movieId'] == id]
    move_to = pd.concat([move_to, record])
    return move_to


def _get_weighted_jaccard_similarity_dict(selected_df):
    """Create a dictionary with genres weighted towards how many 
    times the show up in the selected movie DataFrame

    Args:
        selected_df (Pandas DataFrame): Contains the user selected movies

    Returns:
        Dictionary: 
        {key = string genre name : int number of time it genre showed up in the selected_df}
    """
    # Creates the dictionary
    genres_weighted_dictionary = {"total": 0}
    for index, movie in selected_df.iterrows():
        # the genres are separated by a semicolon and loops through them
        for genre in movie["genres"].split("|"):
            # If already in the dictionary
            if genre in genres_weighted_dictionary:
                # increase count by one
                genres_weighted_dictionary[genre] += 1
            else:
                # Adds a new entry in the dictionary
                genres_weighted_dictionary[genre] = 1
            genres_weighted_dictionary["total"] += 1
    return genres_weighted_dictionary


def _weighted_jaccard_similarity(genre_dict, compare_genres):
    """Gets the record Jaccard Similarity Score based off of
        genres

    Args:
        genre_dict (Dictionary): Containing genres with the respective weight
        compare_genres (str): Contains all genres for the movie

    Returns:
        float: The Jaccard Similarity score for a the single record
    """
    numerator = 0
    denominator = genre_dict['total'] # the total number of entries into the dictionary
    # Splits the compare genres on |
    for genre in compare_genres.split('|'): 
        if genre in genre_dict: # Checks to genre is in the dictionary
            # Adds the number of times the genre accord in the selected movies to the numerator
            numerator += genre_dict[genre]
    return numerator / denominator


def recommendation_driver(data_df, selected_df, k, filtered: bool, value = '', filter_col = ''):
    """Generates the recommendation for the user

    Args:
        data_df (Pandas DataFrame): Contains all the movie data
        selected_df (Pandas DataFrame): Contains the user selected movies
        k (int): The number of recommendation the user wants
        filtered (bool): Checks if filter is active
        value (str, optional): The value the user want to sort by. Defaults to ''.
        filter_col (str, optional): The column the user wants to filter by. Defaults to ''.

    Returns:
        Pandas DataFrame: Contains the new recommendation for the user
    """
    return_df = 0
    working_df = data_df.copy() # Makes a copy of the of all the movie data
    if not selected_df.empty: # Checks to make sure there are moves in in selected_df
        # Gets the dictionary ready for jaccard_similarity
        genre_dict = _get_weighted_jaccard_similarity_dict(selected_df)
        # Adds a new column to the working_df for the weight_results from weighted_jaccard_similarity
        working_df['weighted_results'] = working_df['genres'].map(
            lambda x: _weighted_jaccard_similarity(genre_dict, x))
        # Sorts in descending order
        sorted_df = working_df.sort_values(by='weighted_results', ascending=False)
        # Stores the results
        if filtered: # Checks if filter is running
            sorted_df = _filtered_results(sorted_df, filter_col, value)
        return_df = sorted_df.head(k)
    else: # if no movies have been selected
        if filtered:
            # Filters the whole data frame
            return_df = _filtered_results(working_df, filter_col, value)
            return_df = return_df.head(k)
        else:
            # Stores the randomly generated results
            return_df = _random_selection(working_df, k)
    # Returns the newly created recommendation to the user
    return return_df


def _filtered_results(df, filtered_col, value):
    """Filters the movies based on what the user passes in

    Args:
        df (Pandas DataFrame): Contains all the movie data
        filtered_col (str): The column the user want to filter by
        value (str): What the user wants to filter by
        k (int): The number of records to return

    Returns:
        Pandas DataFrame: Contains the filtered movie recommendation
    """
    return_df = 0
    if filtered_col == 'year': # Check what to filter
        # Returns all moves based on the year
        return_df = df[df[filtered_col] == value]
    else:
        # Creates a new column of the lower case title
        df['lower_case_title'] = df['title'].map(lambda x: x.lower())
        # Checks if the passed in value is contained in the lower case title
        return_df = df[df['lower_case_title'].str.contains(value)]
    # Returns the k number of recommendation
    return return_df


def show_movies(selection_df, display_movies, display_updated):
    """Displays all the recommend movies and selected movies

    Args:
        selection_df (Pandas DataFrame): Contains the users selected movies
        display_movies (Pandas DataFrame): Contains the recommend movies
        display_updated (bool): Shows if the recommend movies need to be updated

    Returns:
        int[]: An array containing the id of the recommend Movies
    """
    if len(selection_df.index) != 0:
        print('---------------------- Selected Movies ----------------------------')
        print_movies(selection_df)
        print('-------------------------------------------------------------------')
    if display_updated:
        print(
            '---------------------- Recommended Movies ----------------------------')
        print_movies(display_movies)
        ids = display_movies['movieId'].to_numpy()
        display_updated = False
    else:
        ids = []
    return ids

def main():
    # TASK 1: Get dataset from server
    #print(f'Task 1: Download dataset from server')
    dataset_file = 'movies_data.csv'
    download_dataset(ICARUS_CS4580_DATASET_URL, dataset_file)
    # TASK 2: Load  data_file into a DataFrame
    #print(f'Task 2: Load weather data into a DataFrame')
    data_file = f'{DATA_FOLDER}/{dataset_file}'
    data = load_data(data_file)
    #print(f'Loaded {len(data)} records')

    #TODO Your code

    program_loop = True # Keeps the program opened
    search_state = False # Keeps track of search state
    filter_active = False  # Keeps track if the filter is active
    display_updated = True # Tracks if the display needs to updated
    error_happened = False # Tracks if an error message needs to be displayed to the user

    temp_holder_df = 0 # Holds the recommended movies to display after search is over
    number_of_recommendation = 10 # Tracks the number or recommendation the user wants
    message = '' # Used to show and track a message for the user

    data_cleaning(data) # Splits title in title and year
    selection_df = pd.DataFrame()
    # Get initial recommendations
    display_movies = recommendation_driver(
        data_df=data, selected_df=selection_df, k=number_of_recommendation, filtered=filter_active)
    # Gets the id of the recommended moviesF
    ids = display_movies['movieId'].to_numpy()
    print('\nWelcome to the movie recommendation app!')
    print('Select some of your favorites movies so we can recommend some movies we think you well like.')
    # Program loop start
    while (program_loop):
        if not error_happened: # Check if a error happened and does not update recommended list
            ids = show_movies(selection_df, display_movies, display_updated)
            display_menu(search_state, filter_active)
        if message != '': # display message if there is one
            print(message)
            message = ''
            error_happened = False
        # Gets the user input and lowercases it
        user_input = input('Please enter choice: ')
        choice = user_input.lower()

        # Checks user input
        match choice:
            
            case 'update':
                if not filter_active: # Check if filter is active
                    # Gets the user input
                    updated_num = input(
                        'Please type the number of desired amount of recommendation: ')
                    if is_int(updated_num): # Checks if its a number
                        # Updates number_of_recommendation
                        number_of_recommendation = int(updated_num)
                        # updates message
                        message = (f"""Number of recommendations have been update to {
                                   number_of_recommendation}!\n""")
                        # Gets a new set of recommended movies
                        display_movies = recommendation_driver(
                            data_df= data, selected_df= selection_df, k=number_of_recommendation, filtered= filter_active)
                        # Will let the program update the recommended movies
                        display_updated = True
                    else:
                        # informs the user the did not input a number
                        message = 'Please input a numerical number'
                        error_happened = True
                else:
                    # Prevents users updating while filter is on
                    message = 'Please exit filter mode and try again'
                    error_happened = True

            case 'close': # Ends the program loop
                program_loop = False

            case 'search': # Enters search State
                search_state = True
                display_updated = False

            case 'back': # Let the user backup from the search state
                if search_state:
                    search_state = False
                    display_updated = True
                    print('\n')

            case 'clear': # If filter is on
                if filter_active:
                    # Deactivate filter
                    filter_active = False
                    message = 'Filter has been cleared'
                    # Updates the display_movies to what they where before the filter
                    display_movies = temp_holder_df.copy()
                    display_updated = True

            case _: # For all other cases
                if is_int(choice): # checks if the user input is a number
                    if not search_state: # if not in search state
                        index = int(user_input) - 1 # Gets the index of the movie id
                        movie_id = int(ids[index]) # Gets move id from id array
                        # Add movie to the selection_df
                        selection_df = add_movie_to_selection(
                            data, selection_df, movie_id)
                        # Let the user know it was successfully added
                        message = 'Movie was added!'
                        # If filter is not activated
                        if not filter_active:
                            # Get new recommendation with the updated selection_df
                            display_movies = recommendation_driver(
                                data_df=data, selected_df=selection_df, k=number_of_recommendation, filtered=filter_active)
                        display_updated = True # Update recommend movies to display
                        print('\n')
                    else: # if in search_state
                        if choice == '1': # User selected to filter by year
                            # Gets the user input for year
                            user_input = input('Please enter a year: ')
                            if is_int(user_input): # Checks user input is a number
                                filter_active = True # Activate filter
                                temp_holder_df = display_movies.copy()  # Copies current recommend
                                # Gets movies based on the year
                                display_movies = recommendation_driver(
                                    data_df=data, selected_df=selection_df, k=number_of_recommendation, filtered=filter_active, value=user_input, filter_col='year')
                                # Update states accordingly
                                display_updated = True 
                                search_state = False
                            else:
                                # Sends error message if the user did a number
                                message = 'Please enter a valued year'
                                error_happened = True
                        elif choice == '2': # User selected to filter by key terms in title
                            user_input = input('Please type you search key terms: ')
                            search_term = user_input.lower() # lowercase user input
                            filter_active = True  # Activate filter
                            temp_holder_df = display_movies.copy()  # Copies current recommend
                            # Gets movies based on the key terms in title
                            display_movies = recommendation_driver(
                                data_df=data, selected_df=selection_df, k=number_of_recommendation, filtered=filter_active, value=search_term, filter_col='title')
                            # Update states accordingly
                            display_updated = True
                            search_state = False       
                        else:
                            message = 'Please enter a valued selection'
                            error_happened = True            
                else: # If the user input was not recognized
                    message = (
                        'Did not recognized the command.  Please try again\n')
                    error_happened = True


if __name__ == '__main__':
    main()
