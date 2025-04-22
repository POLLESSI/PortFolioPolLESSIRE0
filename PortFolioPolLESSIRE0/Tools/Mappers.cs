using PortFolioPolLESSIRE0.DTOs;
using PortFolioPolLESSIRE0.DAL.Entities;

namespace PortFolioPolLESSIRE0.Tools
{
    public static class Mappers
    {
#nullable disable
        public static Certification CertificationToDal(this CertificationDTO cert)
        {
            return new Certification
            {
                Name = cert.Name,
                Authority = cert.Authority,
                LicenceNumber = cert.LicenceNumber,
                Url = cert.Url,
                LicenceDate = cert.LicenceDate,
            };
        }

        public static Contact ContactToDal(this ContactDTO cont)
        {
            return new Contact
            {
                Name = cont.Name,
                Email = cont.Email,
                Phone = cont.Phone
            };
        }

        public static Education EducationToDal(this EducationDTO educ)
        {
            return new Education
            {
                School = educ.School,
                Degree = educ.Degree,
                FieldOfStudy = educ.FieldOfStudy,
                StartDate = educ.StartDate,
                EndDate = educ.EndDate,
                Description = educ.Description
            };
        }

        public static Experience ExperienceToDal(this ExperienceDTO expe)
        {
            return new Experience
            {
                Company = expe.Company,
                Position = expe.Position,
                Description = expe.Description,
                StartDate = expe.StartDate,
                EndDate = expe.EndDate
            };
        }

        public static Interest InterestToDal(this InterestDTO inter)
        {
            return new Interest
            {
                Name = inter.Name,
                Description = inter.Description
            };
        }

        public static Language LanguageToDal(this LanguageDTO lang)
        {
            return new Language
            {
                Name = lang.Name,
                Level = lang.Level
            };
        }

        public static Project ProjectToDal(this ProjectDTO proj)
        {
            return new Project
            {
                Name = proj.Name,
                Description = proj.Description,
                Url = proj.Url,
                StartDate = proj.StartDate,
                EndDate = proj.EndDate
            };
        }
        public static Skill SkillToDal(this SkillDTO sk)
        {
            return new Skill
            {
                Name = sk.Name,
                Level = sk.Level,
                Description = sk.Description
            };
        }
    }
}



















//Copyrite https://github.com/POLLESSI