﻿using System;
using System.Collections.Generic;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class JobFieldsViewModel : BaseViewModel
    {
        // TODO #7.2 - Extract members common to SearchJobsViewModel
        // to BaseViewModel

        //Below 2 lines combined into BaseViewModel
        // The current column
        //public JobFieldType Column { get; set; }

        // All fields in the given column
        public IEnumerable<JobField> Fields { get; set; }

        //Below 2 lines combined into BaseViewModel
        // All columns, for display
        //public List<JobFieldType> Columns { get; set; }
 
        //Below 2 lines combined into BaseViewModel
        // View title
        //public string Title { get; set; } = "";

        public JobFieldsViewModel()
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
