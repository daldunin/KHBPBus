using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace KHBPbus
{
    static class JSONTools
    {
        private static string fileName;

        public static string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
            }
        }

        private static List<Shuttle> listOfArrivals = new List<Shuttle>();

        public static List<Shuttle> ListOfArrivals
        {
            get
            {
                return listOfArrivals;
            }

            set
            {
                listOfArrivals = value;
            }
        }

        public static async Task writeJsonAsync()
        {
            var serializer = new DataContractJsonSerializer(typeof(List<Shuttle>));
            using (var stream = await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
                          FileName,
                          CreationCollisionOption.ReplaceExisting))
            {
                serializer.WriteObject(stream, ListOfArrivals);
            }
        }

        public static async Task deserializeJsonAsync()
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<Shuttle>));

            var myStream = await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(FileName);

            ListOfArrivals = (List<Shuttle>)jsonSerializer.ReadObject(myStream);
        }


    }
}
