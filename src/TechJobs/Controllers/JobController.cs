using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // TODO #1 - get the Job with the given ID and pass it into the view]

            /*JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
            TechJobs.Models.Job jobInfo = jobData.Find(id); //Test using ../Job?id=x

            return View(jobInfo, jobFieldsViewModel); */

           
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            //// Find the job with id 42
            //Job someJob = jobData.Find(42);
            //jobsViewModel.Jobs.Add(jobData.Find(id));//coming up as null even when hardcoding an int
            
            TechJobs.Models.Job jobInfo = new TechJobs.Models.Job(); //Unclear if this is necessary.
            jobInfo = jobData.Find(id);
            jobsViewModel.Jobs = new List(); //Initialize the Jobs list. This appears to solve the null issue. 
            jobsViewModel.Jobs.Add(jobInfo); //System.NullReferenceException: 'Object reference not set to an instance of an object.'
                                            //TechJobs.ViewModels.SearchJobsViewModel.Jobs.get returned null.
            jobsViewModel.Title =  "Job";

            
            return View(jobsViewModel); 

        }

        private IActionResult View(Job jobInfo, JobFieldsViewModel jobFieldsViewModel)
        {
            throw new NotImplementedException();
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // TODO #6 - Validate the ViewModel and if valid, create a 
            // new Job and add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.

            return View(newJobViewModel);
        }
    }

    internal class List : List<Job>
    {
    }
}
