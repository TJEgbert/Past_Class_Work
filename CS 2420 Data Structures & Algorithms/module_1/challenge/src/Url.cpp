//
// Created by Trevor on 9/21/2022.
//
#include "Url.h"

Url::Url(const char *str)
{
    DynamicString tempUrl(str);
    int stringS = 0;
    int schemeC = 0;
    int authorityC = 0;
    int pathC = 0;
    while(tempUrl.char_at(stringS) != '\0')
    {
        if(tempUrl.char_at(stringS) == '/')
        {
            if(tempUrl.char_at(stringS + 2) == '/')
            {
                throw std::invalid_argument("This is an invalid URL");
            }

        }
        ++stringS;
    }

    while(tempUrl.char_at(schemeC) != ':')
    {
        ++schemeC;
    }
    scheme = new char[schemeC + 1];

    for (int j = 0; j < schemeC; ++j)
    {
        scheme[j] = tempUrl.char_at(j);
    }
    scheme[schemeC] = '\0';

    if(tempUrl.reverseFind('/', schemeC + 4) == -1)
    {
        for (int j = schemeC + 1; j < stringS ; ++j)
        {
            ++authorityC;
        }
        authority = new char[authorityC + 1];
        for (int j = 0; j < authorityC - 1; ++j)
        {
            authority[j] = tempUrl.char_at(j + schemeC + 3);
        }
        authority[authorityC] = '\0';
    }
    else
    {
        for (int j = schemeC + 3; j < tempUrl.find('/', schemeC + 3); ++j)
        {
            ++authorityC;
        }
        authority = new char[authorityC + 1];
        for (int j = 0; j < authorityC; ++j)
        {
            authority[j] = tempUrl.char_at(j + schemeC + 3);
        }
        authority[authorityC] = '\0';

    }

    if(tempUrl.find('/', schemeC + authorityC) > 0)
    {
        for (int j = (schemeC + authorityC + 3); j < stringS; ++j)
        {
            ++pathC;
        }

        path = new char[pathC + 1];

        for(int j = 0; j < pathC; ++j)
        {
            path[j] = tempUrl.char_at(j + (schemeC + authorityC + 4));
        }

        path[pathC] = '\0';

    }
    else
    {
        path = new char[1];
        path[0] = '\0';
    }
}

int Url::compare(const Url &other)
{
    DynamicString scheme_temp(this->scheme);
    DynamicString authority_temp(this->authority);
    DynamicString path_temp(this->path);

    DynamicString Oscheme_temp(other.scheme);
    DynamicString Outhority_temp(other.authority);
    DynamicString Opath_temp(other.path);

    if(scheme_temp.iCompare(Oscheme_temp) == - 1)
    {
        return -1;
    }
    else if(scheme_temp.iCompare(Oscheme_temp) == 0)
    {
        if(authority_temp.iCompare(Outhority_temp) == -1)
        {
            return -1;
        }
        else if(authority_temp.iCompare(Outhority_temp) == 1)
        {
            return 1;
        }
        else if(authority_temp.iCompare(Outhority_temp) == 0)
        {
            if(path_temp.compare(Opath_temp) == -1)
            {
                return -1;
            }
            else if(path_temp.compare(Opath_temp) == 1)
            {
                return 1;
            }
            else if(path_temp.compare(Opath_temp) == 0)
            {
                return 0;
            }
        }
    }
    else if(scheme_temp.iCompare(Oscheme_temp) == 1)
    {
        return 1;
    }
}