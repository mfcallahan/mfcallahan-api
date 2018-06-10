using System.Configuration;

namespace HomepageDev.Data.POCOs
{
    public class BusinessCard
    {
        public string Name { get; set; }
        public string CallSignHam { get; set; }
        public string CallSignGMRS { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ResumeUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string GeoNetUrl { get; set; }

        public BusinessCard()
        {
            Name = ConfigurationManager.AppSettings["devInfoName"];
            Title = ConfigurationManager.AppSettings["devInfoTitle"];
            Address = ConfigurationManager.AppSettings["devInfoAddress"];
            Phone = ConfigurationManager.AppSettings["devInfoPhone"];
            Email = ConfigurationManager.AppSettings["devInfoEmail"];
            CallSignHam = ConfigurationManager.AppSettings["callSignHam"];
            CallSignGMRS = ConfigurationManager.AppSettings["callSignGmrs"];
            ResumeUrl = ConfigurationManager.AppSettings["devInfoResumeUrl"];
            LinkedInUrl = ConfigurationManager.AppSettings["devInfoLinkedInUrl"];
            GitHubUrl = ConfigurationManager.AppSettings["devInfoGitHubUrl"];
            GeoNetUrl = ConfigurationManager.AppSettings["devInfoGeoNetUrl"];
        }
    }
}
