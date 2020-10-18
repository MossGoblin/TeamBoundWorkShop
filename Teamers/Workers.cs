using System;
using System.Collections.Generic;

namespace Teamers
{
    public static class Worker
    {
        public static List<string> getList(string prefix, int count)
        {
            List<string> list = new List<string> {
                "ONE",
                "TWO",
                "THREE",
                "FOUR",
                "FIVE",
                "SIX",
                "SEVEN",
                "EIGHT",
                "NINE",
                "TEN",
                "ELEVEN",
                "TWELVE"
            };

            List<string> result = new List<string>();
            for (int index = 0; index < count; index++)
            {
                result.Add($"{prefix} {list[index % list.Count]}");
            }
            
            return result;
        }

    }
}