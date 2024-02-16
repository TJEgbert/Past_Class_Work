#include "shipping_item.h"
#include <iostream>

// const variables
const double ShippingItem::kMaxWeight = 70;
const double ShippingItem::kMaxSize = 108;
const double ShippingItem::kMinSize = .007;


/**
 * @brief: sets the address_ to address
 * @param address Address: used to set address_
 */
void ShippingItem::set_address(Address address)
{
    address_ = address;
}

/**
 * @breif: checks to see if the weight < 0 or weight > kMaxWeight if so it throws out_of_range else set weight_ = weight.
 * @param weight double: used to set weight_
 */
void ShippingItem::set_weight(double weight)
{
    if (weight < 0 || weight > ShippingItem::kMaxWeight)
    {
        throw std::out_of_range ("Weight must be between 0 and 70");
    }

    weight_ = weight;
}

/**
 * @brief: checks to see it length < kMinSize or length > kMaxSize if so throw out_of_range else set length_ = length
 * @param length double: used to set length_
 */
void ShippingItem::set_length(double length)
{
    if (length < ShippingItem::kMinSize || length > ShippingItem::kMaxSize)
    {
        throw std::out_of_range("Length must be between .007 and 108");
    }

    length_ = length;

}

/**
 * @brief: set the delivered_ = delivered
 * @param delivered bool: used to set delivered to true or false
 */
void ShippingItem::set_delivered(bool delivered)
{
    delivered_ = delivered;
}

/**
 * @brief: default constructor for the ShippingItem
 */
ShippingItem::ShippingItem()
{
    address_.name = "unknown";
    weight_ = 2;
    length_ = 12;
    delivered_ = false;
}

/**
 * @brief: none default constructor uses the setter methods set the private data members
 * @param address Address: used to set address_
 * @param weight double: used to set weight_
 * @param length double: used to set length_
 */
ShippingItem::ShippingItem(Address address, double weight, double length)
{
    set_address(address);
    set_weight(weight);
    set_length(length);
}

/**
 * @brief: sets delivered_ = true
 */
void ShippingItem::MarkDelivered()
{
    delivered_ = true;
}

