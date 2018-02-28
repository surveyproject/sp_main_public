namespace Votations.NSurvey.DALFactory
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;
    using Votations.NSurvey.IDAL;

    /// <summary>
    /// Factory implementaion for the answer DAL object
    /// </summary>
    public class LibraryFactory
    {
        public static ILibrary Create()
        {
            NameValueCollection config = (NameValueCollection) ConfigurationManager.GetSection("nSurveySettings");
            if (config == null)
            {
                config = ConfigurationManager.AppSettings;
            }
            string assemblyString = config["WebDAL"];
            //string typeName = assemblyString + ".Library";
            // typename: must match namespace; after namechange of assembly, namespace no longer similar to 
            string typeName = "Votations.NSurvey.SQLServerDAL.Library";

            return (ILibrary) Assembly.Load(assemblyString).CreateInstance(typeName);
        }
    }
}

