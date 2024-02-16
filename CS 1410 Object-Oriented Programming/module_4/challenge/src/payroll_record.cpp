#include <string>
#include <iostream>
#include <iomanip>
#include "payroll_record.h"

// const used for placeholders and calculation.
const double PayrollRecord::kMinimumWage = 7.25;
const double PayrollRecord::kRegularHours = 40;
const double PayrollRecord::kOvertimeRate = 1.5;

/**
 * @brief sets the hours_ to hours
 * @param hours: double used to set hours_
 * @remark Check to see if hours are between 0 to 168 and hours_ to it. If out of the range it sets hours_ = 0
 */
void PayrollRecord::set_hours(double hours)
{
    if (hours >= 0 && hours <= 168)
    {
        hours_ = hours;
    }
    else
    {
        hours_ = 0;
    }
}

/**
 * @brief sets the pay_rate_ to pay_rate
 * @param pay_rate: double used to set pay_rate_
 * @remark Checks to see if the pay_rate < kMinimumWage it sets pay_rate_ to kMinimumWage if not pay_rate_ = pay_rate
 */
void PayrollRecord::set_pay_rate(double pay_rate)
{
    if (pay_rate < kMinimumWage)
    {
        pay_rate_ = kMinimumWage;
    }
    else
    {
        pay_rate_ = pay_rate;
    }
}

/**
 * @brief takes in the string of name and stores first and last name in substrings.
 * @param name: string to set name_
 */
void PayrollRecord::set_name(std::string name)
{
    int search_1 = name.find(",");
    int search_2 = name.find(".");

    if (name.find(",") == name.npos && name.find(".") == name.npos)
    {
        std::string first_name = name.substr(0, name.find_last_of(" "));
        first_name_ = first_name;
        std:: string last_name = name.substr(name.find_last_of(" ") + 1);
        last_name_ = last_name;
        return;
    }
    if (name.find(",") == search_1 && search_2 == name.npos)
    {
        std::string last_name = name.substr(0, search_1);
        last_name_ = last_name;
        std::string first_name = name.substr(search_1 + 2);
        first_name_ = first_name;
        return;
    }

    if (name.find(".") == search_2 && search_1 == name.npos)
    {
        std::string first_name = name.substr(0, search_2 + 1);
        first_name_ = first_name;
        std::string last_name = name.substr(search_2 + 2);
        last_name_ = last_name;
        return;
    }

    if (name.find(",") == search_1 && name.find(".") == search_2)
    {
        std::string last_name = name.substr(0, search_1);
        last_name_= last_name;
        std::string first_name = name.substr(search_1 + 2);
        first_name_ = first_name;
        return;
    }

}

/**
 * The non default constructor for PayRollRecord Class
 * @param hours: double used to set hours_
 * @param pay_rate: double used to set pay_rate_
 * @param name: string used to set_name_
 */
PayrollRecord::PayrollRecord(double hours, double pay_rate, std::string name)
{
    set_hours(hours);
    set_pay_rate(pay_rate);
    set_name(name);
}

/**
 * @brief A method to calculate the gross pay from the PayrollRecord Class
 * @return gross_pay: double the stores the gross_pay after calculations
 */
double PayrollRecord::ComputeGross() const
{
    if(hours_ <= kRegularHours)
    {
        double gross_pay = hours_ * pay_rate_;
        return gross_pay;
    }
    else
    {
        double over_time = hours_ - kRegularHours;
        double regular_pay = kRegularHours * pay_rate_;
        double over_time_pay = over_time * pay_rate_ * kOvertimeRate;
        double gross_pay = regular_pay + over_time_pay;
        return gross_pay;
    }
}

/**
 * @brief a method that can format the data from PayrollRecord class and outputs.
 * @param out ostream: Used to write the formatted information
 */
void PayrollRecord::WriteData(std::ostream &out) const
{
    out
    << std::fixed << std::setprecision(2) << hours_ << " " << pay_rate_ << " " << ComputeGross()<< std::endl
    << last_name_ << ", " << first_name_ << std::endl;
}

/**
 * @brief a method that can format the data from PayrollRecord class and outputs.
 * @param out ostream: Used to write the formatted information in the form of a sentence
 */
void PayrollRecord::WriteReport(std::ostream &out) const
{
    out
    << first_name_ << " " << last_name_ << std::endl
    << "   " << "Hours Worked: " << std::fixed << std::setprecision(2) << hours_ << std::endl
    << "   " << "Pay Rate: " << "$" << pay_rate_ << std::endl
    << "   " <<"Gross Pay: " << "$" << ComputeGross() << std::endl;
}