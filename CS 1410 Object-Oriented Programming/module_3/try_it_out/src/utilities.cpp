
#include <string>
#include <iostream>
#include <iomanip>
 /**
  *
  * @breif searches through a string to find "&apos" and replaced it with "'".
  * @brief searches through a string to find "striped shirt" and inserts "red" in front of it
  * @param Story: a string
  * @return story: a string
  *
  */
std::string FixStory(std::string story)
{
    int search = story.find("&apos");
    while (search != story.npos)
        {
            story.replace(search, 6, "'");
            search = story.find("&apos");
        }

    search = story.find("striped shirt");
    while (search != story.npos)
    {
        story.insert(search, "red ");
        search += 20;
        search = story.find("striped shirt", search);
    }
    return story;
}

/**
 *
 * @brief takes in the following parameters and formats read to an ofstream
 * @param magnitude: float
 * @param type: string
 * @param location: string
 * @param latitude: float
 * @param longitude: float
 * @param depth: float
 * @param time: string
 * @param out: ofstream
 */
void WriteReportLine(float magnitude, std::string type, std::string location, float latitude, float longitude,
                     float depth, std::string time, std::ostream& out)
{
    std::string location_to_print;
    if (location.length() > 38)
    {
        location_to_print = location.substr(0, 35) + "...";
    }
    else
    {
        location_to_print = location;
    }

    out
    << std::right << std::setw(3) << std::fixed << std::setprecision(1) << magnitude << " "
    << std::left << std::setw(4) << type
    << std::setw(38) << location_to_print
    << std::right << std::setw(12) << std::fixed << std::setprecision(4) << latitude
    << std::setw(12) << longitude
    << std::right << std::setw(8)<< std::fixed << std::setprecision(1) << depth << "  "
    << std::left << time << std::endl;

}