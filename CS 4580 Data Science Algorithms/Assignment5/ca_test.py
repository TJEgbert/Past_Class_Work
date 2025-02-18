import os
import requests
import pytest
import pandas as pd
from unittest.mock import patch, mock_open
import ca

DATA_TEST_FOLDER = 'data_test'
# Helper function to clean up created files and directories after tests
def cleanup(file_path):
    if os.path.exists(file_path):
        os.remove(file_path)
    if os.path.exists(DATA_TEST_FOLDER):
        os.rmdir(DATA_TEST_FOLDER)

def test_download_dataset_creates_folder_and_downloads_file():
    url = 'http://test.com'
    data_file = 'test.csv'
    file_path = os.path.join(DATA_TEST_FOLDER, data_file)
    
    # Mock the requests.get call to return a successful response
    with patch('requests.get') as mock_get:
        mock_get.return_value.status_code = 200
        mock_get.return_value.content = b'Test content'
        
        # Mock the open function to write the file content
        with patch('builtins.open', mock_open()) as mock_file:
            ca.download_dataset(url, data_file, DATA_TEST_FOLDER)
            
            # Check if the folder was created
            assert os.path.exists(ca.DATA_FOLDER)
            # Check if the file was written
            mock_file.assert_called_once_with(file_path, 'wb')
            mock_file().write.assert_called_once_with(b'Test content')
    
    # Clean up
    cleanup(file_path)

def test_download_dataset_file_already_exists():
    url = 'http://test.com'
    data_file = 'test.csv'
    file_path = os.path.join(DATA_TEST_FOLDER, data_file)
    
    # Create the folder and file to simulate existing file
    os.makedirs(DATA_TEST_FOLDER, exist_ok=True)
    with open(file_path, 'wb') as f:
        f.write(b'Existing content')
    
    with patch('requests.get') as mock_get:
        ca.download_dataset(url, data_file, DATA_TEST_FOLDER)
        
        # Ensure requests.get was not called since the file already exists
        mock_get.assert_not_called()
    
    # Clean up
    cleanup(file_path)


def test_download_dataset_download_fails():
    url = 'http://test.com'
    data_file = 'test.csv'
    file_path = os.path.join(DATA_TEST_FOLDER, data_file)
    
    # Mock the requests.get call to return a failed response
    with patch('requests.get') as mock_get:
        mock_get.return_value.status_code = 404
        
        # Mock the print function to check for error message
        with patch('builtins.print') as mock_print:
            ca.download_dataset(url, data_file, DATA_TEST_FOLDER)
            
            # Check if the error message was printed
            mock_print.assert_called_with(f'Error downloading dataset {data_file} from {url}/{data_file}')
    
    # Clean up
    cleanup(file_path)

def test_load_data_file_not_found():
    file_path = 'non_existent_file.csv'
    
    with pytest.raises(FileNotFoundError):
        ca.load_data(file_path)

def test_load_data_invalid_file_format():
    file_path = 'invalid_file.txt'
    
    with patch('builtins.print') as mock_print:
        with pytest.raises(ValueError):
            ca.load_data(file_path)
        mock_print.assert_called_with(f'File {file_path} is not a valid CSV file')

def test_load_data_success():
    file_path = 'valid_file.csv'
    data_content = 'col1,col2\n1,2\n3,4'
    
    with patch('os.path.exists', return_value=True):
        with patch('pandas.read_csv', return_value=pd.DataFrame({'col1': [1, 3], 'col2': [2, 4]})):
            with patch('builtins.open', mock_open(read_data=data_content)):
                df = ca.load_data(file_path)
                assert not df.empty
                assert list(df.columns) == ['col1', 'col2']
                assert df.shape == (2, 2)
    
if __name__ == '__main__':
    pytest.main()