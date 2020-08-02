namespace BinarySearch.Extensions
{
    public static class IntervalExtensions
    {
        public static bool LengthIsMoreOrEqualsZero(this Interval interval)
        {
            var inter = interval;
            return inter.Finish - inter.Start >= 0;
        }

        public static int GetMiddlePosition(this Interval interval)
        {
            var inter = interval;
            var start = inter.Start;
            return start + (inter.Finish - start) / 2;
        }

        public static Interval GetLowerInterval(this Interval interval, int middlePosition)
        {
            var inter = interval;
            var middlePos = middlePosition;
            return new Interval(inter.Start, middlePos - 1);
        }
        
        public static Interval GetHigherInterval(this Interval interval, int middlePosition)
        {
            var inter = interval;
            var middlePos = middlePosition;
            return new Interval(middlePos + 1, inter.Finish);
        }
    }
}