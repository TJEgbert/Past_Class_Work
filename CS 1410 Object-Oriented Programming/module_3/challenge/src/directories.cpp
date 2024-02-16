#include <string>
#include <iostream>
#include <iomanip>


/**
 *
 * @brief Checks to see if the phone number is the correct and if not corrects it to the correct format ***.***.****
 * @param phone: string
 * @return phone: strings
 */
std::string FixPhoneNumber(std::string phone)
{
    if (phone.find("-"))
    {
        int search = phone.find("-");
        while (search != phone.npos)
        {
            phone.replace(search, 1, ".");
            search = phone.find("-");
        }
    }
    if (phone.length() == 7)
    {
        phone.insert(3, ".");
    }
    if (phone.length() == 10)
    {
        phone.insert(3, ".");
        phone.insert(7, ".");
    }
    if (phone.length() == 13)
    {
        int search_1 = phone.find("(");
        phone.replace(search_1, 1, "");
        int search_2 = phone.find(")");
        phone.replace(search_2, 1, ".");
        int search_3 = phone.find("-");
        while (search_3 != phone.npos)
        {
            phone.replace(search_3, 1, ".");
            search_3 = phone.find("-");
        }

    }
    return phone;
}

/**
 *
 * @brief Checks to see if the name is in correct format and corrects it if its not
 * @param name: string
 * @return name: string
 */
std::string FixName(std::string name)
{
    int search_name = name.find(",");
    if (search_name != name.npos)
    {
        int search = name.find(",");
        std::string last_name = name.substr(0, search);
        name.append(" ");
        name.append(last_name);
        name.erase(0, search + 2);
    }

    return name;
}

/**
 *
 * @breif checks to see if the email is in the correct format and corrects if its not
 * @param email: string
 * @return email: string
 */
std::string FixEmail(std::string email)
{
    int search_com = email.find(".com");
    int search_at = email.find("@");

    if (search_com == email.npos && search_at == email.npos)
    {
        email.append("@mail.weber.edu");
        return email;

    }
    if (search_at && search_com == email.npos)
    {
        email.append(".com");
    }

    return email;
}

/**
 *
 * @brief takes in the following parameters and formats then writes to an reference to on ofstream
 * @param phone: string
 * @param name: string
 * @param email: string
 * @param out: ofstream
 */
void WriteFormatted(std::string phone, std::string name, std::string email, std::ostream& out)
{
    std::string name_to_print;
    if (name.length() > 19)
    {
        name_to_print = name.substr(0, 16) + "...";
    }
    else
    {
        name_to_print = name;
    }

    out
    << std::right << std::setw(16) << phone << "  "
    << std::left << std::setw(19) << name_to_print << "  "
    << std::left << email << std::endl;

}