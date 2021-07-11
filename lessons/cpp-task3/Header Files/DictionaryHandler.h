#ifndef DICTIONARYHANDLER_H
#define DICTIONARYHANDLER_H

#include <Dictionary.h>

#include <vector>
#include <map>

class DictionaryHandler
{
public:
    DictionaryHandler() = default;
    ~DictionaryHandler() = default;

    void ProcessFiles(std::vector<std::string> const &filesPath);
    void UniteDictionary();
    void PrintAllDictionaries() const;
    void PrintGeneralDictionary() const;

private:
    std::vector<Dictionary> dictionaries;
    Dictionary generalDictionary;

    Dictionary CreateDictionary(std::string const &filePath) const;
};

#endif