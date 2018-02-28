﻿namespace Votations.NSurvey.DALFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Votations.NSurvey.IDAL;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Reflection;

    public class FolderFactory
    {
        public static IFolder Create()
        {
            NameValueCollection config = (NameValueCollection)ConfigurationManager.GetSection("nSurveySettings");
            if (config == null)
            {
                config = ConfigurationManager.AppSettings;
            }
            string assemblyString = config["WebDAL"];

            //string typeName = assemblyString + ".Folder";
            // typename: must match namespace; after namechange of assembly, namespace no longer similar to 
            string typeName = "Votations.NSurvey.SQLServerDAL.Folder";

            return (IFolder)Assembly.Load(assemblyString).CreateInstance(typeName);
        }
    }
}
