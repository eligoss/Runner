using Runner.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Runner.DAL
{
    public class UserXmlProvider : IXmlProvider
    {
        private readonly string _path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public UserXmlProvider()
        {
            this._path = AppDomain.CurrentDomain.BaseDirectory + "/Users.xml" ;
        }

        public void AddRecord(User user)
        {
            //temporary
            var allRecords = Deserialize().ToList();
            allRecords.Add(user);
            Serialize(allRecords);
        }

        public void RemoveRecord(Guid id)
        {
            XElement root = XElement.Load(_path);

            var userXElement = root.Elements("User").SingleOrDefault(q => (Guid)q.Attribute("Id") == id);

            userXElement.Remove();

            root.Save(_path);
        }

        public IEnumerable<User> GetAllRecords()
        {
            return Deserialize();
        }

        public User GetRecord(Guid Id)
        {
            XElement root = XElement.Load(_path);

            var userXElement = root.Elements("User").SingleOrDefault(q => (Guid)q.Attribute("Id") == Id);

            return Deserialize(userXElement);
        }

        public void UpdateRecord(User user)
        {
            XElement root = XElement.Load(_path);

            var userXElement = root.Elements("User").SingleOrDefault(q => (Guid)q.Attribute("Id") == user.Id);

            userXElement.SetElementValue("Login", user.Login);
            userXElement.SetElementValue("Password", user.Password);

            root.Save(_path);
        }        

        public void Serialize(IEnumerable<User> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (TextWriter writer = new StreamWriter(_path))
            {
                serializer.Serialize(writer, list);
            };
        }

        private User Deserialize(XElement element)
        {
            var serializer = new XmlSerializer(typeof(User));
            return (User)serializer.Deserialize(element.CreateReader());
        }

        private IEnumerable<User> Deserialize()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<User>));

            List<User> result;

            using (TextReader reader = new StreamReader(_path))
            {
                object obj = deserializer.Deserialize(reader);
                result = (List<User>)obj;
            }

            return result;
        }
    }
}