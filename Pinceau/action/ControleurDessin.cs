/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/13/2018
 * Time: 08:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml;
using System.IO;
using System.Diagnostics;
using Pinceau.modele;
using Pinceau.donnee;
using Pinceau.action.commande;

namespace Pinceau
{
	/// <summary>
	/// Description of ControleurDessin.
	/// </summary>
	public class ControleurDessin
	{				
		
		enum FORME{CERCLE,CARRE,TRIANGLE,AUCUNE};
		private FORME formeActive;
		
		private DessinDAO dessinDAO = new DessinDAO();
		private Historique historique = new Historique();
		private Dessin dessin = new Dessin();
		private VuePlancheDessin vuePlancheDessin = null;
		
		public ControleurDessin(VuePlancheDessin vue)
		{
			this.vuePlancheDessin = vue;
			
			// TEST debut
			Dessin dessin = new Dessin();
			Cercle cercle = new Cercle(100,100, new Forme.Couleur(0,0,0));
			dessin.ajouterForme(cercle);
			
			this.dessinerXML(dessin.exporterXML());
			// TEST fin
			
		}
		public void notifierActionNettoyerDessin()
		{
			this.vuePlancheDessin.nettoyerDessin();
			this.historique.memoriserAction(new CommandeNettoyer());		
			
			// TEST debut
			// this.vuePlancheDessin.afficherDessin(this.dessin);
			// TEST fin
		}
		public void notifierActionDessinerCercle()
		{
			this.formeActive = FORME.CERCLE;
			this.vuePlancheDessin.activerBoutonCercle();
			//this.vuePlancheDessin.illuminerActionCercle();
		}
		public void notifierActionDessinerCarre()
		{
			this.vuePlancheDessin.activerBoutonCarre();
			this.formeActive = FORME.CARRE;
		}
		public void notifierActionDessinerTriangle()
		{
			this.vuePlancheDessin.activerBoutonTriangle();
			this.formeActive = FORME.TRIANGLE;
		}
		public void notifierActionSauvegarder()
		{
			string xml = this.dessin.exporterXML();
			this.dessinDAO.ajouterDessin(xml);
			this.historique.memoriserAction(new CommandeSauvegarder());		
		} 
		public void notifierActionClicDessin(int x, int y)
		{
			switch(formeActive)
			{
				case FORME.CERCLE:
					Debug.WriteLine("FORME.CERCLE");
					Cercle cercle = new Cercle(x,y, new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), cercle));
					this.dessin.ajouterForme(cercle);
					this.vuePlancheDessin.afficherCercle(cercle);
					this.vuePlancheDessin.desactiverBoutonCercle();
				break;
				case FORME.CARRE:
					Debug.WriteLine("FORME.CARRE");
					Carre carre = new Carre(x,y,new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), carre));
					this.dessin.ajouterForme(carre);
					this.vuePlancheDessin.afficherCarre(carre);
					this.vuePlancheDessin.desactiverBoutonCarre();
				break;
				case FORME.TRIANGLE:
					Debug.WriteLine("FORME.TRIANGLE");
					Triangle triangle = new Triangle(x,y,new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), triangle));
					this.dessin.ajouterForme(triangle);
					this.vuePlancheDessin.afficherTriangle(triangle);
					this.vuePlancheDessin.desactiverBoutonTriangle();
				break;
				default:
					Debug.WriteLine("DEFAULT");
				break;
			}
			
			this.formeActive = FORME.AUCUNE;
			
		}
		
		public void dessinerXML(string dessinXML)
		{
			Console.WriteLine("dessinerXML() - " + dessinXML);
			
			this.vuePlancheDessin.nettoyerDessin();
			
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
					this.vuePlancheDessin.afficherCercle(cercle);
				}
				
			}
		}
		
	}
}
