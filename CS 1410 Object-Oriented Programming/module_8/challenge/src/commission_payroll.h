#ifndef COMMISSION_PAYROLL_H
#define COMMISSION_PAYROLL_H

#include "payroll_data.h"

class CommissionPayroll : public PayrollData
{
private:
    int how_many_{};
    double base_pay_{};

public:
    // constructor destructor
    CommissionPayroll();
    CommissionPayroll(double pay_rate, int how_many, double base_pay, std::string name);
    ~CommissionPayroll() {}

    // getters
    int get_how_many() const {return how_many_;}
    double get_base_pay() const {return base_pay_;}

    // setters
    void set_how_many(int how_many);
    void set_base_pay(double base_pay);

    // methods
    double ComputeCommission() const;
    double ComputeGross() const;
    void WriteData(std::ostream &out) const;
    void WriteReport(std::ostream &out) const;

};

#endif