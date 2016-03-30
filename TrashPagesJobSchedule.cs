using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ericsson.com_Team.Schedule_Jobs
{
    [ScheduledPlugIn(DisplayName ="Our Sample Scheduled Job", SortIndex =1)]
    public class TrashPagesJobSchedule : ScheduledJobBase
    {
        public override string Execute()
        {
            string resultMessage = string.Empty;

            try
            {
                // Count the number of pages in the recycle bin 
                int pagesInRecycleBin =
                    DataFactory.Instance.GetChildren(
                    PageReference.WasteBasket).Count;

                // Compose a grammatically correct (!) result message for the job history log 
                resultMessage =
                    string.Format(
                    "There {0} {1} {2} in the recycle bin.",
                    (pagesInRecycleBin == 1 ? "is" : "are"),
                    pagesInRecycleBin,
                    (pagesInRecycleBin == 1 ? "page" : "pages"));
            }
            catch
            {
                // Error handling goes here 

                resultMessage = "The job could not be completed.";
            }

            // Return the resulting message (Will be displayed in the scheduled job log) 
            return resultMessage;
        }
         
    }
}