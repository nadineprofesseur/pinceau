/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/25/2018
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.IO;

using System.Collections.Generic;

namespace Pinceau.modele
{
	/// <summary>
	/// Description of LecteurXML.
	/// </summary>
	public class LecteurXML
	{
		public LecteurXML()
		{
		}
		
		public List<Forme> lireXML(string dessinXML)	
		{
			List<Forme> listeFormesFinale = new List<Forme>();
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(dessinXML);
			
			XmlNodeList listeFormes = doc.GetElementsByTagName("Forme");
			foreach(XmlNode noeudForme in listeFormes)
			{
				XmlElement elementForme = (XmlElement)noeudForme;								
				int x = Int32.Parse(elementForme.GetElementsByTagName("x").Item(0).InnerText);
				//Console.WriteLine("x " + x);
				int y = Int32.Parse(elementForme.GetElementsByTagName("y").Item(0).InnerText);
				//Console.WriteLine("y " + y);
				
				// TODO parser couleur
				//string couleur = elementForme.GetElementsByTagName("couleur").Item(0).InnerText;
				//Console.WriteLine("couleur " + couleur);
				string type = elementForme.GetElementsByTagName("type").Item(0).InnerText;
				if(type.CompareTo("CERCLE") == 0) // CompareTo retourne 0 quand deux chaines sont identiques
				{
					Cercle cercle = new Cercle(x,y, new Forme.Couleur(0,0,0));
					//this.vuePlancheDessin.afficherCercle(cercle);
					listeFormesFinale.Add(cercle);
				}
			}
			
			return listeFormesFinale;
		}
	}
}
