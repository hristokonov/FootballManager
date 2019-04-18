using FM.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Services.Interfaces
{
    public interface IManagerService
    {
        Manager CreateManager(string firstName, string lastName, string nationality);
        Manager RetrieveManager(string firstName, string lastName);
        Manager HireManager(string firstName, string lastName, string name, string city);
        Manager FireManager(string firstName, string lastName, string name, string city);

    }
}
