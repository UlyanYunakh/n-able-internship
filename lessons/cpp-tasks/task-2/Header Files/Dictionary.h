#ifndef DICTIONARY_H
#define DICTIONARY_H

#include <string>
#include <map>

class Dictionary
{
public:
    Dictionary() = default;
    ~Dictionary() = default;

    void CreateDictionaryFromFileData(std::string const &pathToFile);
    void PrintDictionary() const;

private:
    std::map<std::string, std::size_t> dictionary;
};

#endif