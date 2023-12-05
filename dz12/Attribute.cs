using System;


[AttributeUsage(AttributeTargets.Class)]
public class DeveloperInfoAttribute : Attribute
{
    // Имя разработчика
    public string DeveloperName { get; private set; }

    // Название организации
    public string OrganizationName { get; private set; }


    // Конструктор атрибута
    public DeveloperInfoAttribute(string developerName, string organizationName)
    {
        DeveloperName = developerName;
        OrganizationName = organizationName;
    }
}

