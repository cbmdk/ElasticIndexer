// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContext.cs" company="Nordic Insurance Software">
//   This is just a copyright file
// </copyright>
// <summary>
//   Defines the DataContextDataContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoleApplication3
{
    using System.Configuration;

    /// <summary>The data context data context.</summary>
    public partial class DataContextDataContext
    {
        public DataContextDataContext() : base(ConfigurationManager.ConnectionStrings["work"].ConnectionString)
        {
            OnCreated();
        }
    }
}