using Newtonsoft.Json;
using System.Xml.Linq;

namespace RayGUI_cs
{
    public partial struct InternalConstants
    {
        /// <summary>
        /// Keycodes
        /// </summary>
        public List<string> Keycodes;

        /// <summary>
        /// Load data from external files
        /// </summary>
        public void LoadData()
        {
            // Get Keycodes data
            StreamReader stream = new StreamReader("data/keycodes.json");
            string json = stream.ReadToEnd();
            Keycodes = JsonConvert.DeserializeObject<List<string>>(json);
        }
    }
}
