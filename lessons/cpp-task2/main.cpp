#include <Dictionary.h>

#include <iostream>
#include <memory>

int main()
{
    std::unique_ptr<Dictionary> dict = std::make_unique<Dictionary>();

    dict->CreateDictionaryFromFileData("/home/ulyan/Cpp/console/testFile.txt");
    dict->PrintDictionary();

    return 0;
}