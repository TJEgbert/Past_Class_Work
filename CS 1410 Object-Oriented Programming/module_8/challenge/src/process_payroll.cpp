#include <fstream>
#include <string>
#include <vector>
#include "process_payroll.h"
#include "commission_payroll.h"
#include "hourly_payroll.h"
#include "payroll_data.h"
#include "salary_payroll.h"

/**
 * @brief In ports data from a file checks to see what class is needed to be used with and adds a new object of that
 * class and stores it in a vector of pointers of type payroll_data.  Then it use the WriteReport method and outputs to
 * the outfile.  Then clears vector of pointers.
 * @param inputFile std::string: The file path the user wants to read from
 * @param outputFile std::string:  The file path the user wants to write to
 */
void ProcessPayroll(std::string inputFile, std::string outputFile)
{
    std::ifstream infile(inputFile);

    if(infile.fail())
    {
        std::cout << inputFile << " was not loaded.  Program shutting down..." << std::endl;
        return;
    }

    std::vector<PayrollData*> pay_roll_vector;
    char type;
    double pay_rate;
    double hours;
    int how_many;
    double base_pay;
    std::string name;

    while(infile >> type)
    {
        switch(type)
        {
            case 'H':
               infile >> hours;
               infile >> pay_rate;
               infile.ignore();
               std::getline(infile, name);
               pay_roll_vector.push_back( new HourlyPayroll(hours, pay_rate, name));
               break;

            case 'S' :
                infile >> pay_rate;
                infile.ignore();
                std::getline(infile, name);
                pay_roll_vector.push_back(new SalaryPayroll(pay_rate, name));
                break;

            case 'C' :
               infile >> pay_rate;
               infile >> how_many;
               infile >> base_pay;
               infile.ignore();
               std::getline(infile, name);
               pay_roll_vector.push_back(new CommissionPayroll(pay_rate, how_many, base_pay, name));
               break;

            default:
                break;
        }
    }

    infile.close();

    std::ofstream outfile(outputFile);

    for(PayrollData* &employee : pay_roll_vector)
    {
        employee->WriteReport(outfile);
    }

    for(PayrollData* &employee : pay_roll_vector)
    {
        delete employee;
        employee = NULL;
    }

    outfile.close();

}