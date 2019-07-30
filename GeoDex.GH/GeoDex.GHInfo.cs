using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace GeoDex.GH
{
    public class GeoDexGHInfo : GH_AssemblyInfo
  {
    public override string Name
    {
        get
        {
            return "GeoDexGH";
        }
    }
    public override Bitmap Icon
    {
        get
        {
            //Return a 24x24 pixel bitmap to represent this GHA library.
            return null;
        }
    }
    public override string Description
    {
        get
        {
            //Return a short string describing the purpose of this GHA library.
            return "";
        }
    }
    public override Guid Id
    {
        get
        {
            return new Guid("efd53483-05dd-4cf1-88a3-e40954526de4");
        }
    }

    public override string AuthorName
    {
        get
        {
            //Return a string identifying you or your company.
            return "";
        }
    }
    public override string AuthorContact
    {
        get
        {
            //Return a string representing your preferred contact details.
            return "";
        }
    }
}
}
