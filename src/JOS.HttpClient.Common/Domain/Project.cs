namespace JOSHttpClient.Common.Domain
{
    public class Project
    {
        public Project(string name, string url, int stars)
        {
            Name = name;
            Url = url;
            Stars = stars;
        }

        public string Name { get; }
        public string Url { get; }
        public int Stars { get; }

    }
}
