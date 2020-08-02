namespace BinarySearch
{
    public struct Interval
    {
        private int _start;
        private int _finish;

        public int Start
        {
            get => _start;
            set => _start = value;
        }

        public int Finish
        {
            get => _finish;
            set => _finish = value;
        }

        public Interval(int start, int finish)
        {
            _start = start;
            _finish = finish;
        }
    }
}