using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace ETWAN
{
    class BugReport
    {

        private string description;
        private int wieschlimm;
        private string screenshoturl;
        private string title;

        public void saveToFile()
        {
            DataTable dt = new DataTable("bugreport");

            DataRow dr = new DataRow();

            

        }



        private string getTimestamp()
        {
            
            string timestamp = this.wieschlimm.ToString() + DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() ;

            return timestamp;
        }


    }
}
