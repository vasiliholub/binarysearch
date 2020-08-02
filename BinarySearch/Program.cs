using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using BinarySearch.Extensions;

namespace BinarySearch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // var array = ArrayContainerFactory.CreateArray().OrderBy(x => x).ToArray();

            var array = new[] {1, 3, 5, 7, 17, 18, 235, 10556};

            // var length = array.Length;
            // var randomPos = new Random().Next(length - 1);
            // var randomValue = array[randomPos];
            //
            // Console.WriteLine($"Number elements in array is {length}");
            //
            // Console.WriteLine($"Been searched value is {randomValue}");
            //
            // Console.WriteLine($"Been searched position is {randomPos}");


            // Console.WriteLine($"Found position is {CustomBinarySearch2(array, randomValue)}");
            // var interval = new Interval(0, array.Length - 1);
            // Console.WriteLine($"Found position is {CustomBinarySearch3(array, 775)}");
            //
            // var iterations = new[] {500, 100000, 1000000, 1000000000};
            //
            // var ordinaryDivision = new OrdinaryDivision();
            //
            // var shiftDivision = new ShiftDivision();
            //
            // var displayDivisionTimeDifference = new DisplayDivisionTime(5);
            //
            // foreach (var iteration in iterations)
            // {
            //     var ordinaryTime = displayDivisionTimeDifference.GetRunningTimeInSeconds(ordinaryDivision);
            //     var shiftTime = displayDivisionTimeDifference.GetRunningTimeInSeconds(shiftDivision);
            //
            //     Console.WriteLine(
            //         $"Elapsed difference in performance between ordinary division and shift operation with {iteration} iterations is " +
            //         $"{displayDivisionTimeDifference.Difference()} times");
            // }
            
            Console.WriteLine(Convert.ToInt32(null));
        }

        public interface IDivisionOnTwo
        {
            int DivideOnTwo(int number);
        }


        private static string Difference(long firstValue, long secondValue)
        {
            return Math.Round((secondValue / (double) firstValue), 5).ToString(CultureInfo.InvariantCulture);
        }

        public class DisplayDivisionTime
        {
            public DisplayDivisionTime(int iterationNumber, int dividedValue)
            {
                IterationNumber = iterationNumber;
                DividedValue = dividedValue;
            }

            public DisplayDivisionTime(int dividedValue)
            {
                DividedValue = dividedValue;
            }

            public int IterationNumber { get; set; }

            public int DividedValue { get; set; }

            public double Difference()
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                for (var i = 0; i < IterationNumber; i++)
                {
                    var value = DividedValue / 2;
                }

                stopwatch.Start();
                var division = stopwatch.Elapsed.Ticks;
                
                stopwatch.Restart();
                for (var i = 0; i < IterationNumber; i++)
                {
                    var value = DividedValue >> 1;
                }
                stopwatch.Stop();

                var shift = stopwatch.Elapsed.Ticks;

                return shift / division;
            }

            public long GetRunningTimeInSeconds(IDivisionOnTwo checkedDivisionType)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Reset();
                stopwatch.Start();
                for (var i = 0; i < IterationNumber; i++)
                {
                    var value = checkedDivisionType.DivideOnTwo(DividedValue);
                }

                stopwatch.Stop();
                var seconds = stopwatch.Elapsed.TotalSeconds;
                var milliseconds = stopwatch.Elapsed.TotalMilliseconds;
                var ticks = stopwatch.Elapsed.Ticks;
                return ticks;
            }
        }

        public class OrdinaryDivision : IDivisionOnTwo
        {
            public int DivideOnTwo(int number)
            {
                return number / 2;
            }
        }

        public class ShiftDivision : IDivisionOnTwo
        {
            public int DivideOnTwo(int number)
            {
                return number >> 1;
            }
        }

        private static int CustomBinarySearch3(int[] array, int searchedValue)
        {
            var length = array.Length;
            var left = 0;
            var right = length - 1;
            // 1 2 5 6 7 9
            while (right >= left)
            {
                var middlePos = left + (right - left) / 2;
                var middleValue = array[middlePos];
                if (middleValue == searchedValue)
                {
                    return middlePos;
                }

                if (middleValue < searchedValue)
                {
                    left = middlePos + 1;
                }
                else
                {
                    right = middlePos - 1;
                }
            }

            return -1;
        }

        private static int? CustomBinarySearchRecursively(int[] collection, Interval interval, int searching)
        {
            // If interval length less than zero return null
            // Count middle position
            var middlePosition = interval.GetMiddlePosition();
            // Get middle value
            var middleValue = collection[middlePosition];

            // Compare middle value with searched value

            // If searched value is less than middle value
            if (searching < middleValue)
            {
                // Count lower interval
                // Call method recursively with counted interval
                return CustomBinarySearchRecursively(collection, interval.GetLowerInterval(middlePosition), searching);
            }

            // If searched value is more than middle value
            if (searching > middleValue)
            {
                // Count higher interval
                // Call method recursively with counted interval
                return CustomBinarySearchRecursively(collection, interval.GetHigherInterval(middlePosition), searching);
            }

            // If we reach here then searching value equals middle value (as far as it is not less not more)
            // So return middle position
            return middlePosition;
        }

        private static int? CustomBinarySearch2(IReadOnlyCollection<int> collection, int searching)
        {
            // Get local array instance from parameter
            var array = collection.ToArray();
            // Get local instance of the searching value
            var searched = searching;
            // Retrieve collection length
            var length = array.Length;
            // Count initial interval
            var interval = new Interval(0, length - 1);
            // While interval length more than zero or equals do following 
            while (interval.LengthIsMoreOrEqualsZero())
            {
                // Count middle position
                var middlePosition = interval.GetMiddlePosition();
                // Get value of the middle position (here and after middle value)
                var middleValue = array[middlePosition];

                // Compare middle value with searched value
                if (middleValue == searched)
                {
                    // If searched value equals middle value then return middle position
                    return middlePosition;
                }

                // If searched value exceeds middle value then
                if (searched > middleValue)
                {
                    // Count higher interval
                    interval = interval.GetHigherInterval(middlePosition);
                }

                // If searched value doesn't exceed middle value then
                if (searched < middleValue)
                {
                    // Count lower interval 
                    interval = interval.GetLowerInterval(middlePosition);
                }

                // Go next while iteration
            }

            // Return null as far as we didn't find element position which value equals searched value.
            return null;
        }

        private static int? CustomBinarySearch(IEnumerable<int> sortedCollection, int searchedValue)
        {
            var collection = sortedCollection as int[] ?? sortedCollection.ToArray();
            var length = collection.Length;

            var start = 0;
            var finish = length - 1;
            while (start <= finish)
            {
                var middle = start + (finish - start) / 2;
                var middleValue = collection[middle];
                if (middleValue == searchedValue)
                {
                    return middleValue;
                }

                if (middleValue < searchedValue)
                {
                    start = middle + 1;
                }

                if (middleValue > searchedValue)
                {
                    finish = middle - 1;
                }
            }

            return null;
        }
    }
}