using UnityEngine;
using System.Collections;

using System.IO;
using System.Xml;

public class XMLTest : MonoBehaviour 
{
	string playerName = "Bob";
	string sessionStartTime = System.DateTime.Now.Hour.ToString () + ":" + System.DateTime.Now.Minute.ToString () + ":" + System.DateTime.Now.Second.ToString ();

	// Use this for initialization
	void Start () 
	{
		CreatXML ();
	}
	
	void CreatXML()
	{
		//name xml file
		string fileName = "XMLTest.xml";

		//creat xml object
		XmlDocument xml = new XmlDocument ();

		//if there is already an xml
		if (File.Exists (Application.persistentDataPath + "/" + fileName))
		{
			//load in xml
			xml.Load (Application.persistentDataPath + "/" + fileName);
		}

		else
		{
			//creat new xml and elements
			XmlElement root = xml.CreateElement ("GameSession");
			XmlElement id = xml.CreateElement ("ID");

			//get the device id
			id.InnerXml = SystemInfo.deviceUniqueIdentifier;

			//make id a child of root
			root.AppendChild (id);

			//make root a child of xml
			xml.AppendChild (root);
		}

		//session xml
		XmlElement session = xml.CreateElement ("Session");

		//xml time element
		XmlElement timeStamp = xml.CreateElement ("TimeStamp");
		timeStamp.InnerText = sessionStartTime; 

		//make timestamp child of session
		session.AppendChild (timeStamp);

		//xml username element
		XmlElement userName = xml.CreateElement ("UserName");
		userName.InnerText = playerName;

		//make username child of session 
		session.AppendChild (userName);

		//make session a child of overall document
		xml.DocumentElement.AppendChild (session);


		//save xml
		xml.Save (Application.persistentDataPath + "/" + fileName);
			
	}
}
