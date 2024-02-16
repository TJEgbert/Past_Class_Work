#ifndef HOURLY_PAYROLL_H
#define HOURLY_PAYROLL_H

#include "payroll_data.h"

class HourlyPayroll : public PayrollData
{
private:
    double hours_worked_;

public:
    //static const data members
    static const double kMinHours;
    static const double kMaxHours;
    static const double kRegularHours;
    static const double kOvertimeRate;
    static const double kMinWage;

    // constructors destructor
    HourlyPayroll();
    HourlyPayroll(double hours_worked, double pay_rate, std::string name);
    ~HourlyPayroll() {}

    //getters
    double get_hours() const {return hours_worked_;}

    //setter
    void set_pay_rate(double pay_rate);
    void set_hours(double hours_worked);

    // other methods
    double ComputeGross() const;
    void WriteData(std::ostream &out) const;
    void WriteReport(std::ostream &out) const;
};

#endif