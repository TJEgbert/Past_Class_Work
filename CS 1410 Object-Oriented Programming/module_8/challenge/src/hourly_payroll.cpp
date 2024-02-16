#include <iostream>
#include <iomanip>
#include <string>

#include "hourly_payroll.h"

//const variables
const double HourlyPayroll::kMinHours = 0;
const double HourlyPayroll::kMaxHours = 168;
const double HourlyPayroll::kRegularHours = 40;
const double HourlyPayroll::kOvertimeRate = 1.5;
const double HourlyPayroll::kMinWage = 7.25;

/**
 * @brief: if pay_rate < kMinWage sets pay_rate_ = kMinWare else set pay_rate_ = pay_rate
 * @param pay_rate double: the amount of pay the employee works an hour
 */
void HourlyPayroll::set_pay_rate(double pay_rate)
{
    if(pay_rate < kMinWage)
    {
        pay_rate_ = kMinWage;
    }
    else
    {
        pay_rate_ = pay_rate;
    }
}

/**
 * @brief: checks to see if hours_work is between the kMaxHours and k MinHours if so hours_worked_ = hours_worked
 *         If hours_worked <= kMinHours then it sets hours_worked_ = kMinHours else hours_worked_ = kMaxHours
 * @param hours_worked
 */
void HourlyPayroll::set_hours(double hours_worked)
{
    if (hours_worked < kMaxHours && hours_worked > kMinHours)
    {
        hours_worked_ = hours_worked;
        return;
    }
    if( hours_worked <= kMinHours)
    {
        hours_worked_ = kMinHours;
    }
    else
    {
        hours_worked_ = kMaxHours;
    }
}

/**
 * @brief: default constructor that sets pay_rate_ to kMinWage and hours_worked_ = kMinHourse
 */
HourlyPayroll::HourlyPayroll()
{
    pay_rate_ = kMinWage;
    hours_worked_ = kMinHours;
}

/**
 * @brief: none default constructor sets using the set methods to set the private data members
 * @param hours_worked double
 * @param pay_rate double
 * @param name std::string
 */
HourlyPayroll::HourlyPayroll(double hours_worked, double pay_rate, std::string name)
{
    set_pay_rate(pay_rate);
    set_hours(hours_worked);
    set_name(name);
}

/**
 * @brief Checks to see hours_worked_ <= kRegularHours if calculates the gross pay else calculates pay with over_time
 * @return the gross pay of the employee
 */
double HourlyPayroll::ComputeGross() const
{
    if(hours_worked_ <= kRegularHours)
    {
        double gross_pay = hours_worked_ * pay_rate_;
        return gross_pay;
    }
    else
    {
        double over_time = hours_worked_ - kRegularHours;
        double regular_pay = kRegularHours * pay_rate_;
        double over_time_pay = over_time * pay_rate_ * kOvertimeRate;
        double gross_pay = regular_pay + over_time_pay;
        return gross_pay;
    }
}

/**
 * @brief: Formats the data writes it out
 * @param out ostream: The location the data well be writen to
 */
void HourlyPayroll::WriteData(std::ostream &out) const
{
    out
    << std::fixed << std::setprecision(2) << "H " << hours_worked_ << " " << pay_rate_ << " " << ComputeGross()<<
    std::endl << last_name_ << ", " << first_name_ << std::endl;

}

/**
 * @brief: Formats the data in more readable way writes it out.
 * @param out ostream: The location the data well be writen to
 */
void HourlyPayroll::WriteReport(std::ostream &out) const
{
    out
    << first_name_ << " " << last_name_ << std::endl
    << "   " << "Hours Worked: " << std::fixed << std::setprecision(2) << hours_worked_ << std::endl
    << "   " << "Pay Rate: " << "$" << pay_rate_ << std::endl
    << "   " <<"Gross Pay: " << "$" << ComputeGross() << std::endl;
}