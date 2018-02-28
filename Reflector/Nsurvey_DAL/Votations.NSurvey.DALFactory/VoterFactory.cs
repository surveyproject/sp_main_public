namespace Votations.NSurvey.DALFactory
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;
    using Votations.NSurvey.IDAL;

    /// <summary>
    /// Factory implementaion for the voter DAL object
    /// </summary>
    public class VoterFactory
    {
        public static IVoter Create()
        {
            NameValueCollection config = (NameValueCollection) ConfigurationManager.GetSection("nSurveySettings");
            if (config == null)
            {
                config = ConfigurationManager.AppSettings;
            }
            string assemblyString = config["WebDAL"];
            //string typeName = assemblyString + ".Voter";
            // typename: must match namespace; after namechange of assembly, namespace no longer similar to 
            string typeName = "Votations.NSurvey.SQLServerDAL.Voter";

            return (IVoter) Assembly.Load(assemblyString).CreateInstance(typeName);
        }
    }
}

