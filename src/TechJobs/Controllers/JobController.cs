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

            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            
            TechJobs.Models.Job jobInfo = new TechJobs.Models.Job(); //Unclear if this is necessary.
            jobInfo = jobData.Find(id);
            jobsViewModel.Jobs = new List(); //Initialize the Jobs list. This appears to solve the null issue. 
            jobsViewModel.Jobs.Add(jobInfo); //System.NullReferenceException: 'Object reference not set to an instance of an object.'
                                            //TechJobs.ViewModels.SearchJobsViewModel.Jobs.get returned null.
            jobsViewModel.Title =  "Job";

            
            return View(jobsViewModel); 

        }

        //private void JobController()
        //{
          //  throw new NotImplementedException();
        //}

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

            //Check that Name isn't blank
            String aName = newJobViewModel.Name;

            if (aName != null)
            {

                Employer anEmployer = jobData.Employers.Find(newJobViewModel.EmployerID);
                Location aLocation = jobData.Locations.Find(newJobViewModel.LocationID);
                CoreCompetency aCoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetenciesID);
                PositionType aPosition = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID);

                //Create the job and set all properties
                Job newJob = new Job
                {

                    // set properties within braces
                    Name = aName,
                    Employer = anEmployer,
                    Location = aLocation,
                    CoreCompetency = aCoreCompetency,
                    PositionType = aPosition

                };

                //Put it in the database
                jobData.Jobs.Add(newJob); //Note: Doesn't actually update the job_data.csv file, unclear if required for assignment

                //NOTE: Doesn't work more than one time during same session. Perhaps because not updating the actual CSV?


                // "...redirect to the Job detail (Index) action/view for the new Job."

                int lastitem = jobData.Jobs.Count; //Get the ID for the last item added

                return Redirect("/Job?id=" + lastitem);

            }
            
            return View(newJobViewModel); //The template will display name is a required field.

        }
    }

    internal class List : List<Job>
    {
    }
}
