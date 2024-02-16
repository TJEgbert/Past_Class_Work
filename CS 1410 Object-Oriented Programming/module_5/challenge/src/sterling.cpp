#include <iostream>
#include <string>
#include <cmath>
#include "sterling.h"
using namespace std;

/**
 * @breif sets the pounds_ to pounds that are entered in
 * @param pounds: a long
 * @remark checks to see if pounds > 0 and set pounds_ if not pounds_ = 0
 */
void Sterling::set_pounds(long pounds)
{
    if(pounds > 0)
    {
        pounds_= pounds;
    }
    else
    {
        pounds_= 0;
    }
}

/**
 * @brief sets the shills_ to shills that are entered in
 * @param shillings: an int
 * @remark checks to see if shillings is > 0. If shillings is >= 20 then it does calculations to figure out the total
 * of pounds it needs to add to pounds it get the remainder shilling to shills_. If shillings < 0 then shills_ = 0.
 */
void Sterling::set_shills(int shillings)
{
    if (shillings > 0)
    {
        if (shillings >= 20)
        {
            int pounds = shillings / 20;
            shillings = shillings - (20 * pounds);
            pounds_ += pounds;
        }
        shills_ = shillings;
    }
    else
    {
        shills_ = 0;
    }
}

/**
 * @brief sets the pence_ to pence that are entered in
 * @param pence: an int
 * @remark checks to see if pence is > 0. If pence is >= 12 then it does calculations to figure out the total
 * of shills it needs to add to shillings it get the remainder pences to pence_. If pence < 0 then pence_ = 0.
 */
void Sterling::set_pence(int pence)
{
    if (pence > 0)
    {
        if(pence >= 12)
        {
            int shilling = pence / 12;
            pence = pence - (12 * shilling);
            set_shills(shills_ += shilling);
        }
        pence_ = pence;
    }
    else
    {
        pence_ = 0;
    }
}

/**
 * @brief Uses the split function and sets the old_system_;
 * @param sterling: a reference string
 */
void Sterling::set_old_system(const std::string &sterling)
{
     Split(sterling);
     old_system_ = sterling;
}

/**
 * @brief Three number constructor for the Sterling class
 * @param pounds: a long used to set pounds_
 * @param shills: an int used to set shills_
 * @param pence: an int used to set pence_
 */
Sterling::Sterling(long pounds, int shills, int pence)
{
    set_pounds(pounds);
    set_shills(shills);
    set_pence(pence);
}

/**
 * @brief Constructor that takes in old style format string ex. "45.10.10".
 * @param old_system: a reference string give and sets it using set_old_system
 */
Sterling::Sterling(const std::string &old_system)
{
    set_old_system(old_system);
}

/**
 * @brief Constructor that takes in current currency style ex. 45.20. Then calculate pounds, shills, and pences and
 * sets them
 * @param decimal_pounds: a double used in calculations
 */
Sterling::Sterling(double decimal_pounds)
{
    int pounds = floor(decimal_pounds);
    double fractional_part = decimal_pounds - pounds;
    double decimal_shillings = fractional_part * 20;
    int shillings = floor(decimal_shillings);
    int pence = floor((decimal_shillings - shillings) * 12);

    set_pounds(pounds);
    set_shills(shillings);
    set_pence(pence);
}

/**
 * @brief Friend operator for << to be able print pounds_, shills_ and pence_
 * @param os: a reference to an ostream
 * @param sterling a reference to type Sterling
 * @return ostream
 */
std::ostream& operator << (std::ostream &os, const Sterling &sterling)
{
    os << "pounds: " << sterling.pounds_ << " shills: " << sterling.shills_ << " pence: " << sterling.pence_;
    return os;
}

/**
 * @brief Overload operator for == and lets you compare pounds_, shills_, and pence_
 * @param rhs reference of Sterling class
 * @return true if the same. return false if they aren't
 */
bool Sterling::operator == (const Sterling &rhs) const
{
    if(pounds_ == rhs.pounds_ && shills_ == rhs.shills_ && pence_ == rhs.pence_)
    {
        return true;
    }
    else
    {
        return false;
    }

}

/**
 * @brief Overload operator for != and lets you compare pounds_, shills_, and pence_
 * @param rhs reference of Sterling class
 * @return true if they aren't the same. Return false if they are the same
 */
bool Sterling::operator != (const Sterling &rhs) const
{
    if(pounds_ != rhs.pounds_ || shills_ != rhs.shills_ || pence_ != rhs.pence_)
    {
        return true;
    }
    else
    {
        return false;
    }

}

/**
 * @brief adds pounds_, shills_, pence_ together from on Sterling object to another.
 * @param s2: the second Sterling object
 * @return a Sterling object
 */
Sterling Sterling::operator + (Sterling s2) const
{
   long pounds = pounds_ + s2.pounds_;
   int shills = shills_ + s2.shills_;
   int pence = pence_ + s2.pence_;

   return Sterling(pounds, shills, pence);

}

/**
 * @brief minus pounds_, shills_, pence_ together from on Sterling object to another.
 * @param s2: the second Sterling object
 * @return a Sterling object
 * @remark if shills or pence go below zero it takes one from pound of shills and calculates what would be left
 */
Sterling Sterling::operator - (Sterling s2) const
{
    long pounds = pounds_ - s2.pounds_;
    int shills = shills_ - s2.shills_;
    int pence = pence_ - s2.pence_;

    if (shills < 0)
    {
        pounds -= 1;
        shills += 20;
    }
    if (pence < 0)
    {
        shills -= 1;
        pence += 12;
    }
    return Sterling(pounds, shills, pence);
}

/**
 * @breif turns pound_, shills, and pence into decimal form of current money format ex. 25.10.
 * @return float: decimal form
 */
float Sterling::decimal_pound()
{
    float decimal_form = pounds_ + shills_ / 20.0 + pence_/240.0;
    return decimal_form;
}

/**
 * @breif Breaks down a string in old style of money format and breaks it down into pounds, shells, and pences.
 * Then converts them into ints and sets them for Sterling object.
 * @param stringToBeSplit: a string from the in the for old style of money format ex 10.17.10
 */
void Sterling::Split(std::string stringToBeSplit)
{
    int search = stringToBeSplit.find(".");
    std::string pounds = stringToBeSplit.substr(0, search);
    std::string shills = stringToBeSplit.substr(search + 1, search);
    std::string pence = stringToBeSplit.substr((stringToBeSplit.find_last_of(".") +1 ));

    set_pounds(stoi(pounds));
    set_shills(stoi(shills));
    set_pence(stoi(pence));
}
