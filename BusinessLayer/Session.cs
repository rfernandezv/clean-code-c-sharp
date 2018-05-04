﻿namespace BusinessLayer
{
    public class Session
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsApproved { get; set; }

		public Session(string title, string description)
		{
			Title = title;
			Description = description;
		}
	}
}
