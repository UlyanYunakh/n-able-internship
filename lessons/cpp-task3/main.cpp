#include <Dictionary.h>
#include <DictionaryHandler.h>

#include <iostream>
#include <memory>
#include <future>

int main()
{
    auto handler = std::make_shared<DictionaryHandler>();

    std::vector<std::string> pathes = {"/home/ulyan/Cpp/console/file1.txt",
                                       "/home/ulyan/Cpp/console/file2.txt",
                                       "/home/ulyan/Cpp/console/file3.txt"};

    handler->ProcessFiles(pathes);
    handler->PrintAllDictionaries();
    handler->PrintGeneralDictionary();
    handler->ProcessFiles({"/home/ulyan/Cpp/console/file4.txt"});
    handler->PrintAllDictionaries();
    handler->PrintGeneralDictionary();

    return 0;
}