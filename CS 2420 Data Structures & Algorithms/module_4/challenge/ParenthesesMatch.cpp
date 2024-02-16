#include "ParenthesesMatch.h"

/**
 * @brief checks to see if there are complete pairs of parentheses in a string.
 * @param str char the string that you want to check
 * @return true if there are only complete pairs in the str if not false
 */
bool parenthesesMatch(const char* str)
{
    Stack<char> pareChecker;
    int i = 0;

    while(str[i] != '\0')
    {
        if(str[i] == '(')
        {
            pareChecker.push(str[i]);
        }

        if(!pareChecker.empty() && str[i] == ')')
        {
            pareChecker.pop();
        }
        ++i;
    }

    if(pareChecker.empty())
    {
        return true;
    }
    return false;
}
