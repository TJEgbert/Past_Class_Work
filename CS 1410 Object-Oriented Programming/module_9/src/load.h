#ifndef LOAD_H
#define LOAD_H
#include <vector>
#include "shipping_item.h"

class Load
{
private:
    std::vector<ShippingItem*> vector_load_;
    int count_index_;
    int load_size_;
    double total_weight_;
    double total_volume_;

public:
    // constructor and destructor
    Load();
    ~Load();

    //getter
    int get_count() const {return load_size_;}
    double get_total_volume() {return total_volume_;}
    double get_total_weight() const {return total_weight_;}

    //other methods
    void FillLoad(std::string filename);
    void DisplayNextDelivery(std::ostream &out) const;
    void ItemDelivered();
    void NotDeliverable();
    int HowManyDelivered() const;
    int HowManyNotDelivered() const;

};



#endif