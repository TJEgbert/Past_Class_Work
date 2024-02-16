#include <iomanip>
#include <string>
#include "salary_payroll.h"

/**
 * @brief: none default constructor that sets the private data members with the set methods
 * @param pay_rate double
 * @param name std::string
 */
SalaryPayroll::SalaryPayroll(double pay_rate, std::string name)
{
    set_pay_rate(pay_rate);
    set_name(name);
}

/**
 * @brief returns the pay_rate_
 * @return  double pay_rate_
 */
double SalaryPayroll::ComputeGross() const
{
    return pay_rate_;
}

/**
 * @brief: Formats the data writes it out
 * @param out ostream: The location the data well be writen to
 */
void SalaryPayroll::WriteData(std::ostream &out) const
{
    out
    << std::fixed << std::setprecision(2) << "S " << pay_rate_ <<
    std::endl << last_name_ << ", " << first_name_ << std::endl;
}

/**
 * @brief: Formats the data in more readable way writes it out.
 * @param out ostream: The location the data well be writen to
 */
void SalaryPayroll::WriteReport(std::ostream &out) const
{
    out
    << std::fixed << std::setprecision(2) <<
    first_name_ << " " << last_name_ << std::endl <<
    "   Pay Rate: $" << pay_rate_ << std::endl <<
    "   Gross Pay: $" << ComputeGross() << std::endl;
}