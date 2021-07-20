#include <Dictionary.h>
#include <StringHelper.h>

#include <fstream>
#include <algorithm>
#include <iostream>
#include <vector>

void Dictionary::CreateDictionaryFromFileData(std::string const &pathToFile)
{
    std::ifstream dataFile;

    dataFile.open(pathToFile);

    if (dataFile.is_open())
    {
        std::string word;
        while (dataFile >> word)
        {
            word = StringHelper::ToLowerCase(word);
            word = StringHelper::RemoveCrap(word);

            ++dictionary[word];
        }
        dataFile.close();
    }
    else
    {
        std::cout << "Can't open file, sorry :c" << std::endl;
    }
}

void Dictionary::PrintDictionary() const
{
    std::for_each(dictionary.begin(), dictionary.end(), [](auto item){
        std::cout << item.first << " : " << item.second << std::endl;});
}