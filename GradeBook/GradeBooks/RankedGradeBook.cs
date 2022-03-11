using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();
            int scoredHigher = 0;
            foreach (Student student in Students)
                if (student.AverageGrade > averageGrade)
                    scoredHigher++;
            double scoredHigherPercent = (double) scoredHigher / (double) Students.Count;
            if (scoredHigherPercent < 0.2)
                return 'A';
            else if (scoredHigherPercent < 0.4)
                return 'B';
            else if (scoredHigherPercent < 0.6)
                return 'C';
            else if (scoredHigherPercent < 0.8)
                return 'D';
            return 'F';
        }
    }
}
