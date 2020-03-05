using System;

namespace ConturTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var nsc = new NumberStringsComparer();
            var ttt = nsc.Compare("OneTwoNineThree", "OneThreeFive");
            var ttt0 = nsc.Compare("OneThreeFive","OneTwoNineThree");
            var ttt1 = nsc.Compare("One", "One");
            var ttt2 = nsc.Compare("OneTwo", "OneTwo");
            var ttt3 = nsc.Compare("OneTwoThree", "OneTwoFive");
            var ttt4 = nsc.Compare("OneTwoFive", "OneTwoThree");
        }
    }
}