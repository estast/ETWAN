using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace MakeMyMapFolder
{

    [Serializable]
    class Configuration
    {

        public string path;

        public Configuration()
        {

        }

        
        public Configuration(string givemetehpath)
        {
            path = givemetehpath;
        }

        public Configuration load()
        {

            Configuration config;

            FileStream fs = new FileStream("local.conf", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            config = (Configuration)bf.Deserialize(fs);
            fs.Close();

            return config ;
        }

        public void save()
        {
            FileStream fs = new FileStream("local.conf", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Close();
        }

    }
}
