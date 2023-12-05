using System;

public class ProjectInfoAttribute : Attribute
{
    public string ProjectName { get; }
    public DateTime CreationDate { get; }

    public ProjectInfoAttribute(string projectName)
    {
        ProjectName = projectName;
        CreationDate = DateTime.Now;
    }
}
