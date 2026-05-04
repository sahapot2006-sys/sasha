namespace Master_floor
{
    public static class DiscountCalculator
    {
        public static string CalculateDiscount(double sum)
        {
            if (sum < 10000) return "0%";
            if (sum >= 10000 && sum < 50000) return "5%";
            if (sum >= 50000 && sum < 300000) return "10%";
            return "15%";
        }
    }
}