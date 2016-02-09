using System.Configuration;

namespace ConsoleApplication3
{
    public partial class DataContextDataContext
    {
        public DataContextDataContext() : base(ConfigurationManager.ConnectionStrings["Dev-connString"].ConnectionString)
        {
            OnCreated();
        }
    }
}