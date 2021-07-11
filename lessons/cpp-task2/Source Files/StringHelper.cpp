#include "StringHelper.h"

#include <algorithm>

std::string StringHelper::ToLowerCase(std::string const &string)
{
    std::string newString = string;

    std::transform(string.begin(), string.end(), newString.begin(), [](unsigned char c)
                   { return std::tolower(c); });

    return newString;
}

std::string StringHelper::RemoveCrap(std::string const &string)
{
    std::string newString = string;

    auto lastSymbol = std::remove_if(newString.begin(), newString.end(), [](unsigned char c)
                                     { return std::ispunct(c); });
    auto newSize = std::distance(newString.begin(), lastSymbol);
    newString.resize(newSize);

    return newString;
}