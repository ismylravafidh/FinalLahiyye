using System.ComponentModel;

namespace Rafidah.MVC.ViewModels
{
	public class EditEducationVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string UniversityName { get; set; }
		public string Time { get; set; }
		public string Description { get; set; }
	}
	public class EditExperienceVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string Time { get; set; }
		public string Description { get; set; }
	}
	public class EditCertificateVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CompanyName { get; set; }
		public string Time { get; set; }
		public string Description { get; set; }
	}
}
