/**
 * Challenge: The PayrollRecord Class
 * Trevor Egbert
 * 6/13/22
 * Creates the payroll class and can be used to read and write two different formats of reports
 */
#include <iostream>
#include <string>
#include <fstream>
#include <array>
#include "payroll_record.h"


using namespace std;

int main()
{
    // Const used to set of the array and set up the array.
    const int kMaxSize = 32;
    array<PayrollRecord, kMaxSize> pay_roll_records;

    PayrollRecord test_name(10, 10, "sjdofjsdif");
    // Creates the ifstream payroll_input to open the file payroll_input.txt;
    ifstream payroll_input("../../payroll_input.txt");

    // Checks to see if the file opened
    if (payroll_input.fail())
    {
        cout << "file payroll_input.txt was not loaded... shutting down.\n";
    }

    // Sets up the two ofstream with outfiles payroll_data.txt and payroll_report.txt
    ofstream payroll_data("../../payroll_data.txt");
    ofstream payroll_report("../../payroll_report.txt");

    // Variables used to store data in the while loop
    int index = 0;
    double hours, pay_rate;
    string name;


     // Loops through the file gathering data for hours, pay_rate, name and stores them to creates an object from the
     // PayRollRecord class and stores in it an array to.  Then the methods .WriteDate and .WriteReport are used to
     // format the data.
    while (index < kMaxSize && payroll_input >> hours)
    {
        payroll_input >> pay_rate;
        payroll_input.ignore();
        getline(payroll_input, name);
        pay_roll_records[index] = PayrollRecord(hours, pay_rate, name);
        pay_roll_records[index].WriteData(payroll_data);
        pay_roll_records[index].WriteReport(payroll_report);
        index ++;
    }
    // Closes the ofstream;
    payroll_data.close();
    payroll_report.close();

    return 1;
}
