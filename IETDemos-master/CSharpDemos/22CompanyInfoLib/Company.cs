﻿namespace _22CompanyInfoLib
{
    public class Company:Attribute
    {
		private string _CompanyName;
		private string _DeveloperName;

		public string DeveloperName
		{
			get { return _DeveloperName; }
			set { _DeveloperName = value; }
		}

		public string CompanyName
		{
			get { return _CompanyName; }
			set { _CompanyName = value; }
		}

	}
}
