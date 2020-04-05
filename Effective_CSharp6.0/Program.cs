using System;
using System.Collections.Generic;
using Utilities;

namespace Experiment
{
    class Program
    {
        static void Main(string[] args)
        {            
            var notEnoughBasicWidgets = new List<Widget>()
            {
                new Widget(WidgetType.Basic), 
                new Widget(WidgetType.Basic), 
                new Widget(WidgetType.Extra), 
                new Widget(WidgetType.Basic), 
                new Widget(WidgetType.Extra), 
            };

            WidgetBuilder builder = new WidgetBuilder(notEnoughBasicWidgets);

            if (!builder.TryBuildFoundation())
            {
                ReportErrorToUser("Test Conditions Failed. Please check widgets");
            }

            try
            {
                builder.BuildFoundation();
            }
            catch (WorkerException e)
            {
                ReportErrorToUser(e.ToString());
            }

            Console.ReadKey();
        }

        private static void ReportErrorToUser(string testConditionsFailedPleaseCheckWidgets)
        {
            testConditionsFailedPleaseCheckWidgets.LogToConsole();
        }
    }
}