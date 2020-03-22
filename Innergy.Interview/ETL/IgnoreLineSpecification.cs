namespace Innergy.Interview
{
    public class IgnoreLineSpecification : IIgnoreLineSpecification
    {
        public bool IsToBeIgnored(string line)
        {
            return line.StartsWith("#") || string.IsNullOrEmpty(line);
        }
    }
}