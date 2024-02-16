/**
 * Challenge: Payrolldata Class
 * Trevor Egbert
 * 7/25/2022
 * Creates the sub classes of the Payroll_data: hourly_payroll, commission_payroll and salary_payroll.
 * Then uses them with process_payroll to output formatted data.
 */
#include <iostream>
#include <string>
#include "hourly_payroll.h"
#include "salary_payroll.h"
#include "commission_payroll.h"
#include "process_payroll.h"

using namespace std;

int main() {
  // create HourlyPayroll objects and use the associated methods
  cout << "The HourlyPayroll class demonstration.\n";
  cout << endl;

  // Create HourlyPayroll objects using the default and non-default
  // constructors.

    HourlyPayroll employee1;
    HourlyPayroll employee2(15.5, 15, "Jimmy James");

  // Use the HourlyPayroll objects to call the getter and setter methods.
  // Print out the results to see that the methods are doing what is expected.

  employee1.set_hours(12);
  employee1.set_pay_rate(32);
  employee1.set_name("Fred Smith");

  cout << employee1.get_hours() << endl;
  cout << employee2.get_first_name() << endl;
  cout << employee1.get_last_name() << endl;
  cout << employee1.get_pay_rate() << endl;

  // Use the HourlyPayroll objects to call the ComputeGross method. Print
  // out the results to see that the method is doing what is expected.

  cout << "employee 2 makes: " << employee2.ComputeGross() << endl;

  // Use the HourlyPayroll objects to call the WriteData and WriteReport
  // methods to see they are working as expected.

  employee1.WriteReport(cout);
  employee2.WriteData(cout);

  // create SalaryPayroll objects and use the associated methods
  cout << "The SalaryPayroll class demonstration.\n";
  cout << endl;

  // Create SalaryPayroll objects using the default and non-default
  // constructors.

  SalaryPayroll sal1;
  SalaryPayroll sal2(56000, "Sarah Miller");

  // Use the SalaryPayroll objects to call the getter and setter methods.
  // Print out the results to see that the methods are doing what is expected.
  // Notice that the SalaryPayroll does not define any new getters and
  // setters but still use the ones that are defined in the PayrollData class.

  sal1.set_name("Sam S. Turner");
  sal1.set_pay_rate(100000);
  cout << sal1.get_pay_rate() << " " << sal1.get_first_name() << " " << sal1.get_last_name() << endl;

  // Use the SalaryPayroll objects to call the ComputeGross method. Print
  // out the results to see that the method is doing what is expected.

  cout << "sal2 gross: " << sal2.ComputeGross() << endl;

  // Use the SalaryPayroll objects to call the WriteData and WriteReport
  // methods to see they are working as expected.

  sal1.WriteData(cout);
  sal2.WriteReport(cout);

  // create CommissionPayroll objects and use the associated methods
  cout << "The CommissionPayroll class demonstration.\n";
  cout << endl;

  // Create CommissionPayroll objects using the default and non-default
  // constructors.

  CommissionPayroll com1;
  CommissionPayroll com2(10.5, 10, 1500, "Johnson, Kim");

  // Use the CommissionPayroll objects to call the getter and setter methods.
  // Print out the results to see that the methods are doing what is expected.

  com1.set_base_pay(500);
  com1.set_how_many(5);
  com1.set_name("Ricky Tem");
  com1.set_pay_rate(350.25);
  cout << "com1 info is: " << com1.get_base_pay() << " " << com1.get_how_many() << " " << com1.get_first_name() <<
  " " << com1.get_last_name() << " " << com1.get_pay_rate() << endl;

  // Use the CommissionPayroll objects to call the ComputeCommission method.
  //  Print out the results to see that the method is doing what is expected.

  cout << "com2 Commission pay is: " << com2.ComputeCommission() << endl;

  // Use the CommissionPayroll objects to call the ComputeGross method. Print
  // out the results to see that the method is doing what is expected.

  cout << "com2 gross pay is: " << com1.ComputeGross() << endl;

  // Use the CommissionPayroll objects to call the WriteData and WriteReport
  // methods to see they are working as expected.

  com1.WriteReport(cout);
  com2.WriteData(cout);

  // run the ProcessPayroll function
  cout << "The ProcessPayroll function.\n";
  cout << endl;

  // In main, call the  ProcessPayroll function.
  // See that it is producing the expected report.

  string infile("../../payroll_week23.txt");
  string outfile("../../formatted_payroll_week23.txt");

    ProcessPayroll(infile, outfile);



  return 0;
}