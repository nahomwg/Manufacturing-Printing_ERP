using System;
using ExceedERP.Core.Domain.Construction;
using Kendo.Mvc.UI;

namespace ExceedERP.Web.Models
{
    public class ProjectTaskScheduleViewModel:   IGanttTask
    {
        public ProjectTaskScheduleViewModel()
        {
        }

        public ProjectTaskScheduleViewModel(ProjectTaskSchedule projectTaskSchedule)
        {
                ProjectTaskScheduleId = projectTaskSchedule.ProjectTaskScheduleId;
                Title = projectTaskSchedule.TaskName;
                Start = DateTime.SpecifyKind(projectTaskSchedule.StartDate, DateTimeKind.Utc);
                End = DateTime.SpecifyKind(projectTaskSchedule.EndDate, DateTimeKind.Utc);
                StartTimezone = projectTaskSchedule.StartTimezone;
                EndTimezone = projectTaskSchedule.EndTimezone;
                Description = projectTaskSchedule.Description;
                IsAllDay = projectTaskSchedule.IsAllDay;
                RecurrenceRule = projectTaskSchedule.RecurrenceRule;
                RecurrenceException = projectTaskSchedule.RecurrenceException;
                RecurrenceID = projectTaskSchedule.RecurrenceId;
        }

        public int ProjectTaskScheduleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        private DateTime start;
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        private DateTime end;
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        public decimal PercentComplete { get; set; }
        public bool Summary { get; set; }
        public bool Expanded { get; set; }
        public int OrderId { get; set; }

        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }
        public int RecurrenceID { get; set; }
        public string RecurrenceException { get; set; }
        public bool IsAllDay { get; set; }


        public ProjectTaskSchedule ToEntity()
        {
            return new ProjectTaskSchedule
            {
                ProjectTaskScheduleId = ProjectTaskScheduleId,
                TaskName = Title,
                StartDate = Start,
                EndDate = End,
                StartTimezone = StartTimezone,
                EndTimezone = EndTimezone,
                Description = Description,
                IsAllDay = IsAllDay,
                RecurrenceRule = RecurrenceRule,
                RecurrenceException = RecurrenceException,
                RecurrenceId = RecurrenceID
            };
        }
    }
}
