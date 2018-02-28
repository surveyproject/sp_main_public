namespace Votations.NSurvey.DALFactory
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;
    using Votations.NSurvey.IDAL;

    /// <summary>
    /// Factory implementation for the survey DAL object
    /// </summary>
    public class SurveyFactory
    {
        public static ISurvey Create()
        {
            NameValueCollection config = (NameValueCollection) ConfigurationManager.GetSection("nSurveySettings");
            if (config == null)
            {
                config = ConfigurationManager.AppSettings;
            }

            /// web.config: nSurveySettings: add key="WebDAL" value="SurveyProject.SQLServerDAL" ...
            string assemblyString = config["WebDAL"];

            //string typeName = assemblyString + ".Survey";
            // typename: must match namespace; after namechange of assembly, namespace no longer similar to 
            string typeName = "Votations.NSurvey.SQLServerDAL.Survey";

            return (ISurvey) Assembly.Load(assemblyString).CreateInstance(typeName);
        }
    }
}

