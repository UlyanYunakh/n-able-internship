#ifndef STRINGHELPER_H
#define STRINGHELPER_H

#include <string>

class StringHelper
{
public:
    static std::string ToLowerCase(std::string const &string);
    static std::string RemoveCrap(std::string const &string);
};

#endif