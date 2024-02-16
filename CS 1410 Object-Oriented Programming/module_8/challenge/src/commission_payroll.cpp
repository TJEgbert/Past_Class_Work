#include "commission_payroll.h"

#include <iomanip>

/**
 * @brief: checks to see if the how_many < 0 if so sets how_many_ = 0 else how_many_ = how_many
 * @param how_many int: the amount of commission the employee had
 */
void CommissionPayroll::set_how_many(int how_many)
{
    if(how_many < 0)
    {
        how_many_ = 0;
    }
    else
    {
        how_many_ = how_many;
    }
}

/**
 * @breif: checks to see if base_pay < 0 if so it sets base_pay_ = 0 else base_pay_ = base_pay
 * @param base_pay
 */
void CommissionPayroll::set_base_pay(double base_pay)
{
    if(base_pay < 0)
    {
        base_pay_ = 0;
    }
    else
    {
        base_pay_ = base_pay;
    }
}

/**
 * @breif: default constructor name_ and pay_rate_ set from the parent class payroll_data.
 * Set how_many_ = 0 and base_pay_ = 0
 */
CommissionPayroll::CommissionPayroll()
{
    how_many_ = 0;
    base_pay_ = 0;

}

/**
 * @breif: constructor that use the set methods to set the private data members
 * @param pay_rate double
 * @param how_many int
 * @param base_pay double
 * @param name std::string
 */
CommissionPayroll::CommissionPayroll(double pay_rate, int how_many, double base_pay, std::string name)
{
    set_pay_rate(pay_rate);
    set_how_many(how_many);
    set_base_pay(base_pay);
    set_name(name);
}

/**
 * @breif: calculates commission pay
 * @return a double: the amount the employee makes.
 */
double CommissionPayroll::ComputeCommission() const
{
    return pay_rate_ * how_many_;
}

/**
 * @brief: calculates gross pay
 * @return a double: the gross pay the employee makes
 */
double CommissionPayroll::ComputeGross() const
{
    return ComputeCommission() + base_pay_;
}

/**
 * @brief: Formats the data writes it out
 * @param out ostream: The location the data well be writen to
 */
void CommissionPayroll::WriteData(std::ostream &out) const
{
    out << std::fixed << std::setprecision(2) <<
    "C " << pay_rate_ << " " << how_many_ << " " << base_pay_ << " " << ComputeGross() << std::endl
    << last_name_ << ", " << first_name_ << std::endl;

}

/**
 * @brief: Formats the data in more readable way writes it out.
 * @param out ostream: The location the data well be writen to
 */
void CommissionPayroll::WriteReport(std::ostream &out) const
{
    out << std::fixed << std::setprecision(2) <<
    first_name_ << " " << last_name_ << std::endl <<
    "   Pay Rate: $" << pay_rate_ << std::endl <<
    "   How Many: " << how_many_ << std::endl <<
    "   Commission: $" << ComputeCommission() << std::endl <<
    "   Base Pay: $" << base_pay_ << std::endl <<
    "   Gross Pay: $" << ComputeGross() << std::endl;
}