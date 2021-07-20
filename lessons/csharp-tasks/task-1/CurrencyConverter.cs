namespace task_1
{
    public static class CurrencyConverter
    {
        public static decimal ConvertToUSD(decimal BYN, decimal exchangeRates = 2.589m) => BYN * exchangeRates;
    }
}