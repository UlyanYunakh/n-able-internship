#include <DictionaryHandler.h>
#include <Dictionary.h>

#include <thread>
#include <future>
#include <iostream>

void DictionaryHandler::ProcessFiles(std::vector<std::string> const &filesPath)
{
    std::vector<std::future<Dictionary>> futureDictionaries;

    for (auto const &path : filesPath)
    {
        futureDictionaries.push_back(std::async(std::launch::async, &DictionaryHandler::CreateDictionary, this, path));

        // std::promise<Dictionary> promise;
        // futureDictionaries.push_back(promise.get_future());
        // std::thread([&promise, path]()
        //             {
        //                 std::unique_ptr<Dictionary> dictionary = std::make_unique<Dictionary>();

        //                 dictionary->CreateDictionaryFromFileData(path);
        //                 promise.set_value_at_thread_exit(*dictionary);
        //             })
        //     .detach();
    }

    for (auto &futureDictionary : futureDictionaries)
    {
        dictionaries.push_back(futureDictionary.get());
    }

    UniteDictionary();
}

void DictionaryHandler::UniteDictionary()
{
    std::map<std::string, std::size_t> newDictionary;

    for (auto const &dictionary : dictionaries)
    {
        for (auto const &record : dictionary.GetDictionary())
        {
            newDictionary[record.first] += record.second;
        }
    }

    generalDictionary.SetDictionary(newDictionary);
}

void DictionaryHandler::PrintAllDictionaries() const
{
    for (std::size_t index = 0; index < dictionaries.size(); ++index)
    {
        std::cout << "Dictionary from file " << index + 1 << " :" << std::endl;
        dictionaries[index].PrintDictionary();
    }
}

void DictionaryHandler::PrintGeneralDictionary() const
{
    std::cout << "General dictionary :" << std::endl;
    generalDictionary.PrintDictionary();
}

Dictionary DictionaryHandler::CreateDictionary(std::string const &filePath) const
{
    auto dictionary = std::make_unique<Dictionary>();

    dictionary->CreateDictionaryFromFileData(filePath);

    return *dictionary;
}
