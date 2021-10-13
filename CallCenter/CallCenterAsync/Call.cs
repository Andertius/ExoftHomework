namespace CallCenterAsync
{
    public class Call
    {
        public Call(int milliseconds, int number)
        {
            Duration = milliseconds;
            Number = number;
            Status = Status.NotStarted;
        }

        public int Duration { get; }

        public int Number { get; }

        public Status Status { get; set; }

        public override string ToString()
        {
            return $"{Number}. {Status}";
        }
    }
}
