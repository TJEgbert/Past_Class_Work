#ifndef PAYROLL_DATA_H
#define PAYROLL_DATA_H

#include <string>
#include <iostream>

class PayrollData
{
protected:
    double pay_rate_;
    std::string first_name_;
    std::string last_name_;

public:

    // Getters
    double get_pay_rate() const {return pay_rate_;}
    std::string get_first_name() const {return first_name_;}
    std::string get_last_name() const {return last_name_;}

    // Setters
    void set_pay_rate(double pay_rate);
    void set_name(std::string name);

    // Constructor
    PayrollData() {pay_rate_ = 0, first_name_ = "it is", last_name_ = "unknown";}
    PayrollData(double pay_rate, std::string name);

    ~PayrollData(){};

    // Other methods
    virtual double ComputeGross() const = 0;
    virtual void WriteData(std::ostream &out) const = 0;
    virtual void WriteReport(std::ostream &out) const = 0;

};



#endif