namespace BusinessLayer
{
    public class WebBrowser
	{
		public BrowserName Name { get; set; }
		public int MajorVersion { get; set; }

		public WebBrowser(BrowserName browser, int majorVersion)
		{
            Name = browser;
            MajorVersion = majorVersion;
		}
        
		public enum BrowserName
		{
			Unknown,
			InternetExplorer,
			Firefox,
			Chrome,
			Opera,
			Safari,
			Dolphin,
			Konqueror,
			Linx
		}
	}
}
