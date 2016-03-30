using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ericsson.com_Team.Schedule_Jobs
{
    [ScheduledPlugIn(DisplayName = "ScheduledJobExample")]
    public class ScheduledJobExample : ScheduledJobBase
    {
        private bool _stopSignaled;

        public ScheduledJobExample()
        {
            IsStoppable = true;
        }
        public override void Stop()
        {
            _stopSignaled = true;
        }
        public override string Execute()
        {
            OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));
            if (_stopSignaled)
            {
                return "Stop of job was called";
            }

            return "Job is successfully executed";
        }
    }
}