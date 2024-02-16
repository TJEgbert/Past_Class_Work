#ifndef UTILITIES_H
#define UTILITIES_H

#include <string>
#include <fstream>

std::string FixStory(std::string story);

void WriteReportLine(float magnitude, std::string type, std::string location, float latitude, float longitude,
                     float depth, std::string time, std::ostream& out);

#endif
