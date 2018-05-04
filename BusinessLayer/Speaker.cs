using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Speaker
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? Experience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }
		public int RegistrationFee { get; set; }
		public List<BusinessLayer.Session> Sessions { get; set; }

        public int? Register(IRepository repository)
		{
			int? speakerId = null;
	
            validateDataRegister();

            RegistrationFee = assigRegistrationFee(Experience);

            speakerId = repository.SaveSpeaker(this);

            return speakerId;
		}

        public void validateDataRegister()
        {
            bool haveStandard;
            bool isApproved = false;
            int minimumExperience = 10;
            int minimumCertification = 3;
            int maximumVersionWebBrowser = 9;
            if (string.IsNullOrWhiteSpace(FirstName)) throw new ArgumentNullException("First Name is required");
            if (string.IsNullOrWhiteSpace(LastName)) throw new ArgumentNullException("Last name is required.");
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentNullException("Email is required.");
            if (Sessions.Count() == 0) throw new ArgumentException("Can't register speaker with no sessions to present.");

            haveStandard = ((Experience > minimumExperience || HasBlog || Certifications.Count() > minimumCertification || Company.companies.Contains(Employer)));
            if (!haveStandard)
            {
                string emailDomain = Email.Split('@').Last();
                haveStandard = !Domain.domains.Contains(emailDomain) && (!(Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < maximumVersionWebBrowser));
            }
            if (!haveStandard) throw new HandlerException("Speaker doesn't meet our abitrary and capricious standards.");

            foreach (var session in Sessions)
            {
                validateApprovedSession(session);
                if (session.IsApproved)
                {
                    isApproved = true;
                }
            }
            if (!isApproved) throw new HandlerException("No sessions approved.");
        }

        public void validateApprovedSession(Session session)
        {
            session.IsApproved = true;

            foreach (var tech in Technology.technologies)
            {
                if (session.Title.Contains(tech) || session.Description.Contains(tech))
                {
                    session.IsApproved = false;
                    break;
                }
            }
        }

        public int assigRegistrationFee(int? experienceParameter) {
            if (experienceParameter <= 1)
            {
                return 500;
            }
            if (experienceParameter >= 2 && experienceParameter <= 3)
            {
                return 250;
            }
            if (experienceParameter >= 4 && experienceParameter <= 5)
            {
                return 100;
            }
            if (experienceParameter >= 6 && experienceParameter <= 9)
            {
                return 50;
            }
            return 0;
        }
        
	}
}