#include <string>
#include "payroll_data.h"

/**
 * @brief sets the pay_rate_ to pay_rate
 * @param pay_rate: double used to set pay_rate_
 * @remark Checks to see if the pay_rate < kMinimumWage it sets pay_rate_ to kMinimumWage if not pay_rate_ = pay_rate
 */
void PayrollData::set_pay_rate(double pay_rate)
{
    if (pay_rate < 0)
    {
        pay_rate_ = 0;
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
void PayrollData::set_name(std::string name)
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
 * The non default constructor for PayrollData Class
 * @param hours: double used to set hours_
 * @param pay_rate: double used to set pay_rate_
 * @param name: string used to set_name_
 */
PayrollData::PayrollData(double pay_rate, std::string name)
{
    set_pay_rate(pay_rate);
    set_name(name);
}

