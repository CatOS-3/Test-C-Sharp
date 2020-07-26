using System;

namespace Test
{
    public class TestQuest
    {
        public String[] Answer { get; }

        public String Quest { get; }

        public int Correct { get; }

        public TestQuest(String q, String a1, String a2, String a3, String a4, int c)
        {
            Answer = new String[4];
            Quest = q;
            Answer[0] = a1;
            Answer[1] = a2;
            Answer[2] = a3;
            Answer[3] = a4;
            Correct = c;
        }
    }
}