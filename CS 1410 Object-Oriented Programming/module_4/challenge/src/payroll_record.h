#ifndef PAYROLL_RECORD_H
#define PAYROLL_RECORD_H
#include <string>
#include <iostream>

class PayrollRecord
{
private:
    double hours_;
    double pay_rate_;
    std::string first_name_;
    std::string last_name_;

public:
    static const double kMinimumWage;
    static const double kRegularHours;
    static const double kOvertimeRate;

    // Getters
    double get_hours() const {return hours_;}
    double get_pay_rate() const {return pay_rate_;}
    std::string get_first_name() const {return first_name_;}
    std::string get_last_name() const {return last_name_;}

    // Setters
    void set_hours(double hours);
    void set_pay_rate(double pay_rate);
    void set_name(std::string name);

    // Constructor
    PayrollRecord() {hours_ = 0, pay_rate_ = kMinimumWage, first_name_ = "it is", last_name_ = "unknown";}
    PayrollRecord(double hours, double pay_rate, std::string name);

    ~PayrollRecord(){};

    // Other methods
    double ComputeGross() const;
    void WriteData(std::ostream &out) const;
    void WriteReport(std::ostream &out) const;

};



#endif