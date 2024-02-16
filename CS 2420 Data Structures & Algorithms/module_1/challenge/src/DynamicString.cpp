#include "DynamicString.h"
#include <cctype>
#include <stdexcept>


using std::out_of_range;
using std::tolower;
using std::toupper;
using std::ostream;

/**
 * @brief: default constructor sets cstr array to 1 and sets it to '\0'
 */
DynamicString::DynamicString()
{
    cstr = new char[1];
    cstr[0] = *"\0";
    arraySize_ = 0;
}

/**
 * @brief: none default constructor checks the str the come in and creates sets cstr[arraySize_ + 1] and then adds the
 * '\0' at the end.
 * @param str char*: pointer to str and sets it to cstr array.
 */
DynamicString::DynamicString(const char* str)
{
    arraySize_ = 0;
    while(str[arraySize_] != '\0')
    {
        ++ arraySize_;
    }
    cstr = new char[arraySize_ + 1];

    for (int i = 0; i < arraySize_; ++i)
    {
        cstr[i] = str[i];
    }
    cstr[arraySize_] = *"\0";
}

/**
 * @brief: loops through the cstr array until cstr[count] != '/0' and returns count;
 * @return int: returns the number of items in the array.
 */
int DynamicString::len() const
{

    int count = 0;
    while(cstr[count] != '\0')
    {
        count ++;
    }
    return count;
}

/**
 * @breif: returns the array cstr
 * @return const char*: the array cstr
 */
const char* DynamicString::c_str() const
{
    return cstr;
}

/**
 * @brief: checks to see if the position > arraySize_ or < 0 if so throws out_of_range if not return cstr[position]
 * @param position int: the index the user wants to access
 * @return char: the character at cstr[position]
 */
char DynamicString::char_at(int position) const
{
    if(position > arraySize_)
    {
        throw std::out_of_range("The number entered is out of the size of DynamicString");
    }
    else if(position < 0)
    {
        throw std::out_of_range("The number must be >= 0");
    }

    return cstr[position];
}

/**
 * @brief: overload operator for [] checks to see if position > arraySize_ or position < 0 and throws out_of_range
 * @param position int: the index that use wants to access
 * @return returns &char: cstr[position]
 */
char& DynamicString::operator[](int position)
{
    if(position > arraySize_)
    {
        throw std::out_of_range("The number entered is out of the size of DynamicString");
    }
    else if(position < 0)
    {
        throw std::out_of_range("The number must be >= 0");
    }

    return cstr[position];
}

/**
 * @brief: checks to see if the other is empty, then it checks if arraySize >= other.arraySize_ if so it loops through
 * the arrays to see if other is the start of cstr
 * @param other DynamicString&: that the use wants check against cstr
 * @return bool: True if cstr starts with other or if empty.  False if cstr doesn't start with other
 */
bool DynamicString::startsWith(const DynamicString& other) const
{
    char empty = '\0';
    if(other.char_at(0)== empty)
    {
        return true;
    }
    else if(arraySize_ >= other.arraySize_)
    {
        int i = 0;
        while(cstr[i] == other.char_at(i))
        {
            if(cstr[i] == other.char_at(other.arraySize_ -1))
            {
                return true;
            }
            ++i;
        }
        return false;
    }
    return false;
}

/**
 * @brief: checks to see if the other is empty, then it checks if arraySize >= other.arraySize_ if so it loops through
 * the arrays backwards to see if other is the start of cstr
 * @param other DynamicString&: that the use wants check against cstr
 * @return bool: True if cstr starts with other or if empty .  False if cstr doesn't start with other
 */
bool DynamicString::endsWith(const DynamicString& other) const
{
    char empty = '\0';
    if(other.char_at(0) == empty)
    {
        return true;
    }
    else if(arraySize_ >= other.arraySize_)
    {
        if(cstr[0] != '\0')
        {
            int other_count = other.arraySize_ - 1;
            int cstr_count = arraySize_ - 1;

            while (cstr[cstr_count] == other.char_at(other_count)) {
                if (other_count == 0) {
                    return true;
                }
                other_count -= 1;
                cstr_count -= 1;
            }
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }
    return false;
}

/**
 * @brief: checks the arraySize_ of both DynamicStrings and sets loop_size = arraySize_.  Then it loops through the
 * arrays to see if cstr comes before other in the dictionary using ascii values.  Case sensitive
 * @param other DynamicString&: what the user wants to check is in cstr
 * @return int: if cstr later in the dictionary returns 1. if cstr early in the dictionary returns -1. if there the same
 * returns 0
 */
int DynamicString::compare(const DynamicString& other) const
{
    int loop_size;
    if(arraySize_ > other.arraySize_)
    {
        loop_size = arraySize_;
    }
    else
    {
        loop_size = other.arraySize_;
    }
    if(cstr[0] == other.char_at(0))
    {
        for (int i = 1; i < loop_size; ++i)
        {
            if(cstr[i] < other.char_at(i))
            {
                return -1;
            }
            else if(cstr[i] > other.char_at(i))
            {
                return 1;
            }
        }
    }
    else if(cstr[0] < other.char_at(0))
    {
        return -1;
    }
    else if(cstr[0] > other.char_at(0))
    {
        return 1;
    }
    return 0;
}

/**
 * @brief: checks the arraySize_ of both DynamicStrings and sets loop_size = arraySize_.  Then it loops through the
 * arrays and changing lower case to see if cstr comes before other in the dictionary using ascii values.
 * @param other DynamicString&: what the user wants to check is in cstr
 * @return int: if cstr later in the dictionary returns 1. if cstr early in the dictionary returns -1. if there the same
 * returns 0
 */
int DynamicString::iCompare(const DynamicString& other) const
{
    int loop_size;
    if(arraySize_ > other.arraySize_)
    {
        loop_size = arraySize_;
    }
    else
    {
        loop_size = other.arraySize_;
    }
    if(tolower(cstr[0]) == tolower(other.char_at(0)))
    {
        for (int i = 1; i < loop_size; ++i)
        {
            if(tolower(cstr[i]) < tolower(other.char_at(i)))
            {
                return -1;
            }
            else if(tolower(cstr[i]) > tolower(other.char_at(i)))
            {
                return 1;
            }
        }
    }
    else if(tolower(cstr[0]) < tolower(other.char_at(0)))
    {
        return -1;
    }
    else if(tolower(cstr[0]) > tolower(other.char_at(0)))
    {
        return 1;
    }
    return 0;
}

/**
 * @brief: loops through the cstr array converting DynamicString to lowercase
 * @return DynamicString&: in lower case
 */
DynamicString& DynamicString::toLower()
{
    for(int i = 0; i < arraySize_; ++i)
    {
        char temp = this->char_at(i);
        cstr[i] = static_cast<char>(tolower(temp));
    }
    return *this;
}

/**
 * @brief: loops through the cstr array converting DynamicString to uppercase
 * @return DynamicString&: in lower case
 */
DynamicString& DynamicString::toUpper()
{
    for(int i = 0; i < arraySize_; ++i)
    {
        char temp = this->char_at(i);
        cstr[i] = static_cast<char>(toupper(temp));
    }

    return *this;
}

/**
 * @brief: loops the cstr looking for old and replacing it with newCh
 * @param old char: the char the user wants to replace
 * @param newCh char: the char the user wants to replace old with.
 * @return DynamicString&: the updated object
 */
DynamicString& DynamicString::replace(char old, char newCh)
{
    for (int i = 0; i < arraySize_; ++i)
    {
        if(cstr[i] == old)
        {
            cstr[i] = newCh;
        }
    }

   return *this;
}

/**
 * @brief: uses start to set where to start looping through the cstr array.  Returns the first index of c.  If
 * it can't be found returns -1
 * @param c char: the char the user wants to look for
 * @param start int: the starting point in the array
 * @return int:  The index
 */
int DynamicString::find(char c, int start) const
{
    for(int i = start; i < arraySize_; i++)
    {
        if (cstr[i] == c)
        {
            return i;
        }
    }
   return -1;
}

/**
 * @brief: uses start to set where to start looping through the cstr array backwards. If start < 0 return -1.  If
 * start > arraySize_ it sets start to arraySize. Returns the last index of c.  If it can't be found returns -1.
 * @param c char: the char the user wants to look for
 * @param start int: the starting point in the array
 * @return int:  The index of the last occurrence of the char
 */
int DynamicString::reverseFind(char c, int start) const
{
    if(start < 0)
    {
        return -1;
    }
    else if(start > arraySize_)
    {
        start = arraySize_;
    }

    for (int i = start; i >= 0; --i)
    {
        if (cstr[i] == c)
        {
            return i;
        }
    }
    return -1;
}

/**
 * @breif: loops through the cstr backwards to find the last occurrence of char
 * @param c char: the char that the user wants to find
 * @return int: The index location if not found return -1
 */
int DynamicString::reverseFind(char c) const
{
    for (int i = arraySize_; i >= 0; --i)
    {
        if (cstr[i] == c)
        {
            return i;
        }
    }
    return -1;
}

/**
 * @brief: friend operator of the << operator
 * @param out ostream&:  The ostream the user wants to output to
 * @param str DynamicString&: the string the user wants to output
 * @return oustream&: the cstr[]
 */
ostream& operator<<(ostream& out, const DynamicString& str)
{

    out << str.c_str();

   return out;
}



DynamicString::DynamicString(const DynamicString &other)
{
    int otherSize = other.arraySize_;
    cstr = new char[otherSize];
    arraySize_= otherSize;
    *cstr = *(other.cstr);

}


DynamicString::~DynamicString()
{
    delete cstr;
}


DynamicString &DynamicString::operator=(const DynamicString &other)
{
    if(this != &other)
    {
        delete cstr;
        cstr = new char[other.arraySize_];
        *cstr = *(other.cstr);
        arraySize_ = other.arraySize_;
    }
    return *this;
}