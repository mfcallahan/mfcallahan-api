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
            Name = ConfigurationManager.AppSettings["devInfoName"].ToString();
            Title = ConfigurationManager.AppSettings["devInfoTitle"].ToString();
            Address = ConfigurationManager.AppSettings["devInfoAddress"].ToString();
            Phone = ConfigurationManager.AppSettings["devInfoPhone"].ToString();
            Email = ConfigurationManager.AppSettings["devInfoEmail"].ToString();
            CallSignHam = ConfigurationManager.AppSettings["callSignHam"].ToString();
            CallSignGMRS = ConfigurationManager.AppSettings["callSignGmrs"].ToString();
            ResumeUrl = ConfigurationManager.AppSettings["devInfoResumeUrl"].ToString();
            LinkedInUrl = ConfigurationManager.AppSettings["devInfoLinkedInUrl"].ToString();
            GitHubUrl = ConfigurationManager.AppSettings["devInfoGitHubUrl"].ToString();
            GeoNetUrl = ConfigurationManager.AppSettings["devInfoGeoNetUrl"].ToString();
        }
    }
}
