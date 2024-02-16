/*
 * File: /mnt/f/CS1410/cs1410-master/Module1/TO1-3/src/stock.h
 * Project: /mnt/f/CS1410/cs1410-master/Module1/TO1-3/src
 * Created Date: Tuesday, March 24th 2020, 10:14:23 am
 * Author: Dr. Hugo Valle (hugovalle1@weber.edu)
 * -----
 * Last Modified: Sun Mar 29 2020
 * Modified By: Dr. Hugo Valle
 * -----
 * Copyright (c) 2020, Dr. Hugo Valle, Weber State University
 * 
 * -----
 * HISTORY:
 * Date      	By	Comments
 * ----------	---	----------------------------------------------------------
 */

#ifndef STOCK_H_
#define STOCK_H_

#include <array>    // For array containers

// Constant for number of stocks
const int STOCKS = 5;

// Function Signatures
void ShowStock(const std::array<double, STOCKS> &portfolio);

void IncreaseValueStock(std::array<double, STOCKS> &portfolio, double percentage);

void SellStock(std::array<double, STOCKS> &portfolio);

#endif /* !STOCK_H_ */
