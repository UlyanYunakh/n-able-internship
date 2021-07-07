#include <iostream>
#include <vector>
#include <memory>
#include <algorithm>

template <typename T>
class IVectorFormatter
{
public:
    virtual std::vector<T> ToSqureElements(std::vector<T> const &vector) const = 0;
    virtual std::vector<T> ToOnlyEvenNumbers(std::vector<T> const &vector) const = 0;
    virtual T Summarize(std::vector<T> const &vector) const = 0;

    virtual ~IVectorFormatter() = default;
};

template <typename T>
class VectorFormatter : public IVectorFormatter<T>
{
public:
    std::vector<T> ToSqureElements(std::vector<T> const &vector) const override
    {
        std::vector<T> resultVector = vector;

        std::transform(resultVector.begin(), resultVector.end(), resultVector.begin(), [](T item) -> T
                       { return item * item; });

        return resultVector;
    }

    std::vector<T> ToOnlyEvenNumbers(std::vector<T> const &vector) const override
    {
        std::vector<T> resultVector = vector;

        auto lastElemOfResultVector = std::remove_if(resultVector.begin(), resultVector.end(), [](T item)
                                                     { return item % 2 != 0; });

        size_t newSizeOfResultVector = std::distance(resultVector.begin(), lastElemOfResultVector);
        resultVector.resize(newSizeOfResultVector);

        return resultVector;
    }

    T Summarize(std::vector<T> const &vector) const override
    {
        struct Sum
        {
            void operator()(T elem) { sum += elem; }
            T sum{0};
        };

        Sum result = std::for_each(vector.begin(), vector.end(), Sum());

        return result.sum;
    }
};

template <typename T>
void VectorPrint(std::vector<T> const &vector)
{
    for (size_t i = 0; i < vector.size(); i++)
    {
        std::cout << vector[i] << " ";
    }
    std::cout << std::endl;
}

int main()
{
    std::unique_ptr<IVectorFormatter<int>> formatter = std::make_unique<VectorFormatter<int>>();
    
    std::vector<int> vector = {4, 5, 15, 37, 103, 8, 9};
    VectorPrint(vector);

    vector = formatter->ToSqureElements(vector);
    VectorPrint(vector);

    vector = formatter->ToOnlyEvenNumbers(vector);
    VectorPrint(vector);

    std::cout << formatter->Summarize(vector) << std::endl;
    return 0;
}