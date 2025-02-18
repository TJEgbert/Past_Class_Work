import pytest
import pandas as pd
from ca import load_census_data
from ca import get_max_state_population_by_race
from ca import get_unemployment_rate
from ca import get_income_inequality
from ca import get_total_feminine_population
from ca import get_most_diverse_racially

# Common fixture for all tests
@pytest.fixture
def census_data():
    census_data_file = 'data/acs2015_census_tract_data.csv'
    return load_census_data(census_data_file)

def test_load_census_data_excludes_puerto_rico(census_data):
    data = census_data # Get dataFrame from fixture

    # Check if the result is a DataFrame
    assert isinstance(data, pd.DataFrame)
    
    # Check if the data does not contain Puerto Rico
    assert 'Puerto Rico' not in data['State'].values
    assert 'California' in data['State'].values
    assert 'Texas' in data['State'].values
    assert 'New York' in data['State'].values


def test_get_max_state_population_by_race(census_data):
    data = census_data # Get dataFrame from fixture

    # Test for Hispanic population
    max_state, max_population = get_max_state_population_by_race(data, 'Hispanic')
    assert max_state == 'California'
    assert int(max_population) == 14750696

    # Test for White population
    max_state, max_population = get_max_state_population_by_race(data, 'White')
    assert max_state == 'California'
    assert int(max_population) == 14879391

    # Test for Black population
    max_state, max_population = get_max_state_population_by_race(data, 'Black')
    assert max_state == 'Texas'
    assert int(max_population) == 3070659

    # Test for Asian population
    max_state, max_population = get_max_state_population_by_race(data, 'Asian')
    assert max_state == 'California'
    assert int(max_population) == 5192738

    # Test for Native population
    max_state, max_population = get_max_state_population_by_race(data, 'Native')
    assert max_state == 'Oklahoma'
    assert int(max_population) == 267481

    # Test for Pacific population
    max_state, max_population = get_max_state_population_by_race(data, 'Pacific')
    assert max_state == 'California'
    assert int(max_population) == 139145

def test_get_unemployment_rate(census_data):
    data = census_data # Get dataframe from fixture

    # Test for highest unemployment rate
    state, unemployment_rate = get_unemployment_rate(data, 'highest')
    assert state == 'District of Columbia'
    assert pytest.approx(unemployment_rate, 0.02) == 10.98

    # Test for lowest unemployment rate
    state, unemployment_rate = get_unemployment_rate(data, 'lowest')
    assert state == 'North Dakota'
    assert pytest.approx(unemployment_rate, 0.02) == 2.95

def test_get_income_inequality(census_data):
    data = census_data  # Get dataframe from fixture

    # Get the result from the function
    result = get_income_inequality(data)

    # Check if the result is a DataFrame
    assert isinstance(result, pd.DataFrame)

    # Check if the result has the correct columns
    expected_columns = ['CensusTract', 'State', 'County', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific', 'Income', 'Poverty']
    assert list(result.columns) == expected_columns

    # Check if all rows have Income >= 50000 and Poverty > 50
    assert all(result['Income'] >= 50000)
    assert all(result['Poverty'] > 50)

    # Check if the result is not empty
    assert not result.empty

    # Check the dataframe shape columns and rows
    assert result.shape[1] == len(expected_columns)
    assert result.shape[0] == len(result)  
    
    # Optionally, you can add specific checks for known values if you have any
    # For example:
    # assert result.loc[result['CensusTract'] == 1001, 'State'].values[0] == 'Alabama'

def test_get_total_feminine_population(census_data):
    data = census_data  # Get dataframe from fixture

    # Get the result from the function
    result = get_total_feminine_population(data)

    # Check if the result is a DataFrame
    assert isinstance(result, pd.DataFrame)

    # Check if the result has the correct columns
    expected_columns = ['CensusTract', 'State', 'County', 'TotalPop', 'Women', 'Men', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific', 'Income', 'Poverty']
    assert list(result.columns) == expected_columns

    # Check if all rows have TotalPop > 10000 and Women/TotalPop > 0.57
    assert all(result['TotalPop'] > 10000)
    assert all(result['Women'] / result['TotalPop'] > 0.57)

    # Check if the result is not empty
    assert not result.empty

    # Check the dataframe shape columns and rows
    assert result.shape[1] == len(expected_columns)
    assert result.shape[0] == len(result)  
    
    # Optionally, you can add specific checks for known values if you have any
    # For example:
    # assert result.loc[result['CensusTract'] == 1001, 'State'].values[0] == 'Alabama'


def test_get_most_diverse_racially(census_data):
    data = census_data  # Get dataframe from fixture

    # Get the result from the function
    result = get_most_diverse_racially(data)

    # Check if the result is a DataFrame
    assert isinstance(result, pd.DataFrame)

    # Check if the result has the correct columns
    expected_columns = ['CensusTract', 'State', 'County', 'Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific']
    assert list(result.columns) == expected_columns

    # Check if all rows have at least four races with >= 15%
    filter_records = ['Hispanic', 'White', 'Black', 'Asian', 'Native', 'Pacific']
    assert all((result[filter_records] >= 15).sum(axis=1) >= 4)

    # Check if the result is not empty
    assert not result.empty

    # Check the dataframe shape columns and rows
    assert result.shape[1] == len(expected_columns)
    assert result.shape[0] == len(result)  
    
    # Optionally, you can add specific checks for known values if you have any
    # For example:
    # assert result.loc[result['CensusTract'] == 1001, 'State'].values[0] == 'Alabama'
    

if __name__ == "__main__":
    pytest.main()