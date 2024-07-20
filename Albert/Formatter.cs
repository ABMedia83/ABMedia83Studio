

namespace Albert
{

    /// <summary>
    /// A special Delegate for creating a Xml Document 
    /// </summary>
    /// <param name="_xElement"></param>
    public delegate void XmlFileEventHandler(XElement? _xElement);


    /// <summary>
    /// A Module that creates Json and Xml documents;
    /// </summary>
    public static class Formatter
    {
        #region Json Logic 

        /// <summary>
        /// Saves object to a Json format 
        /// </summary>
        /// <param name="_obj"></param>
        /// <param name="_fileName"></param>
        public static void WriteToJsonFile(object _obj, string _fileName)
        {
            //Convert Object to Json 
            string json = Serialize(_obj);
            //Save to a Document File 
            WriteAllText(_fileName, json);
        }

        public static T ReadFromJsonFile<T>(string _fileName)
        {
            //Put the Json into a string 
            string? json = ReadAllText(_fileName!);          
            
            //Convert it into the Type 
            return Deserialize<T>(json!)!;
        }




        #endregion
        #region Xml Logic 


        public static void WriteToXmlDocument(string _fileName, string _headTag, string _documentTag, XmlFileEventHandler _method)
        {
            //Create the Xml Document 
            XElement xml = new XElement(_headTag);
            //Create the document tag 
            XElement document = new XElement(_documentTag);
            //Add document tag the head tag 
            xml.Add(document);

            //Create the Xml Document with the Method 
            _method.Invoke(document);

            xml.Save(_fileName);
        }

        public static void ReadFromXmlDocument(string _fileName, string _documentTag, XmlFileEventHandler _method)
        {
            var xml = XElement.Load(_fileName);
            var document = xml.Element(_documentTag);
            //Execute Method 
            _method.Invoke(document);
        }



        #endregion 
    }
}
