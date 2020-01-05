using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel : BaseViewModel
    {
        // TODO #7.1 - Extract members common to JobFieldsViewModel
        // to BaseViewModel

        // The search results
        public List<Job> Jobs { get; set; }

        //Below 2 lines combined into BaseViewModel
        // The column to search, defaults to all
        //public JobFieldType Column { get; set; } = JobFieldType.All;

        // The search value
        [Display(Name = "Keyword:")]
        public string Value { get; set; } = "";

        //Below 2 lines combined into BaseViewModel
        // All columns, for display
        //public List<JobFieldType> Columns { get; set; }

        //Below 2 lines combined into BaseViewModel
        // View title
        //public string Title { get; set; } = "";

        public SearchJobsViewModel()
        {
            // Populate the list of all columns
            BaseViewModel baseViewModel = new BaseViewModel();

            //Below combined into BaseViewModel
            //Columns = new List<JobFieldType>();

            //foreach (JobFieldType enumVal in Enum.GetValues(typeof(JobFieldType)))
            //{
               // Columns.Add(enumVal);
            //}

        }
    }
}
