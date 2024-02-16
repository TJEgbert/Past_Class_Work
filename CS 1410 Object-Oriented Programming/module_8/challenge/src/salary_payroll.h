#ifndef SALARY_PAYROLL_H
#define SALARY_PAYROLL_H

#include "payroll_data.h"

class SalaryPayroll : public PayrollData
{
public:
    // constructor and destructor
    SalaryPayroll() {}
    SalaryPayroll(double pay_rate, std::string name);
    ~SalaryPayroll() {}

    // methods
    double ComputeGross() const;
    void WriteData(std::ostream &out) const;
    void WriteReport(std::ostream &out) const;
};

#endif