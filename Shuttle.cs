using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Popups;

namespace KHBPbus
{
    public class Shuttle
    {

        private TimeSpan time;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        private List<string> days;
        public List<string> Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }

        private string busStop;

        public string BusStop
        {
            get
            {
                return busStop;
            }

            set
            {
                busStop = value;
            }
        }


        private string direction;

        public string Direction
        {
            get
            {
                return direction;
            }

            set
            {
                direction = value;
            }
        }

        public Shuttle() { }

        public Shuttle(TimeSpan time, List<string> days, string busStop, string direction)
        {
            this.time = time;
            this.days = days;
            this.busStop = busStop;
            this.Direction = direction;
        }

        public bool isActiveOnDay(string dayToCheck)
        {
            if (dayToCheck == "Today")
                dayToCheck = System.DateTime.Now.DayOfWeek.ToString();
            foreach (string day in days)
                if (dayToCheck == day)
                    return true;

            return false;
        }

        public static async Task SaveObjectToXml<T>(T objectToSave, string filename)
        {
            // stores an object in XML format in file called 'filename'
            
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists).AsTask().ConfigureAwait(false);
            Stream stream = await file.OpenStreamForWriteAsync().ConfigureAwait(false);

            using (stream)
            {
                serializer.Serialize(stream, objectToSave);
            }
        }

        public static async Task<T> ReadObjectFromXmlFileAsync<T>(string filename)
        {
            // this reads XML content from a file ("filename") and returns an object  from the XML
            T objectFromXml = default(T);
            var serializer = new XmlSerializer(typeof(T));
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync(filename);
            Stream stream = await file.OpenStreamForReadAsync();
            objectFromXml = (T)serializer.Deserialize(stream);
            stream.Dispose();
            return objectFromXml;
        }

    }
}

