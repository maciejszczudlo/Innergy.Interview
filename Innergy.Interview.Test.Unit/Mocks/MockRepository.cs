using System;
using System.Collections.Generic;
using System.Text;

namespace Innergy.Interview.Test.Unit
{
    public class MockRepository
    {




        public static string[] GetExampleInput()
        {
            var data = new[]
            {
                "# Material inventory initial state as of Jan 01 2018",
                "# New materials",
                "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10",
                "Maple Dovetail Drawerbox;COM-124047;WH-A,15",
                "Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2",
                "Yankee Hardware 110 Deg. Hinge;COM-123908;WH-A,10|WH-B,11",
                "# Existing materials, restocked",
                "",
                "Hdw Accuride CB0115-CASSRC - Locking Handle Kit - Black;CB0115-CASSRC;WH-C,13|WH-B,5",
                "",
                "Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm - Paper Back;3M-Cherry-10mm;WH-A,10|WH-B,1",
                "",
                "Veneer - Cherry Rotary 1 FSC;COM-123823;WH-C,10",
                "MDF, CARB2, 1 1/8\";COM-101734;WH-C,8"
            };

            return data;
        }

        public static string[] GetExampleExpectedOutput()
        {
            var data = new[]
            {
                "WH-A (total 50)",
                "3M-Cherry-10mm: 10",
                "COM-100001: 5",
                "COM-123906c: 10",
                "COM-123908: 10",
                "COM-124047: 15",
                "",
                "WH-C (total 33)",
                "CB0115-CASSRC: 13",
                "COM-101734: 8",
                "COM-123823: 10",
                "COM-123906c: 2",
                "",
                "WH-B (total 33)",
                "3M-Cherry-10mm: 1",
                "CB0115-CASSRC: 5",
                "COM-100001: 10",
                "COM-123906c: 6",
                "COM-123908: 11"
            };
            return data;
        }

    }
}
