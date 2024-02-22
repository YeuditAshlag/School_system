namespace school_server
{
    public enum Year { First = 1, Second, Third }

    public class Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string familyName { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public bool active { get; set; }
        public int marksAvg { get; set; }
        public DateTime birthDate { get; set; }
        public int profession { get; set; }
        public int year { get; set; }
    }
}
