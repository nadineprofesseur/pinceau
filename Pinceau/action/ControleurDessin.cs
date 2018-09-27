/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/13/2018
 * Time: 08:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using Pinceau.modele;
using Pinceau.donnee;
using Pinceau.action.commande;
using System.Collections.Generic;

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
		private Reserve reserve = new Reserve();
		
		public ControleurDessin(VuePlancheDessin vue)
		{
			this.vuePlancheDessin = vue;
			
			// TEST debut
			// Cercle cercle = new Cercle(100,100, new Forme.Couleur(0,0,0));
			// dessin.ajouterForme(cercle);
			// Cercle cercle2 = new Cercle(200,200, new Forme.Couleur(0,0,0));
			// dessin.ajouterForme(cercle2);
			// this.dessinerXML(dessin.exporterXML());
			// TEST fin
			
		}
		public void notifierActionNettoyerDessin()
		{
			this.vuePlancheDessin.nettoyerDessin();
			//this.historique.memoriserAction(new CommandeNettoyer());		
			
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
		
		
		public void notifierActionDessinerCarreBlanc()
		{
		}
		public void notifierActionDessinerCarreNoir()
		{
		}
		public void notifierActionDessinerPetitCarreRouge()
		{
		}
		public void notifierActionDessinerPetitCarreJaune()
		{
		}
		
		
		public void notifierActionSauvegarder()
		{
			string xml = this.dessin.exporterXML();
			this.dessinDAO.ajouterDessin(xml);
			//this.historique.memoriserAction(new CommandeSauvegarder());		
		} 
		
		public void notifierActionClicDessin(int x, int y)
		{
			switch(formeActive)
			{
				case FORME.CERCLE:
					Debug.WriteLine("FORME.CERCLE");
					Cercle cercle = new Cercle(x,y, new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), cercle, this.vuePlancheDessin));
					this.dessin.ajouterForme(cercle);
					this.vuePlancheDessin.afficherCercle(cercle);
					this.vuePlancheDessin.desactiverBoutonCercle();
				break;
				case FORME.CARRE:
					Debug.WriteLine("FORME.CARRE");
					Carre carre = new Carre(x,y,new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), carre, this.vuePlancheDessin));
					this.dessin.ajouterForme(carre);
					this.vuePlancheDessin.afficherCarre(carre);
					this.vuePlancheDessin.desactiverBoutonCarre();
				break;
				case FORME.TRIANGLE:
					Debug.WriteLine("FORME.TRIANGLE");
					Triangle triangle = new Triangle(x,y,new Forme.Couleur(0,0,0));
					this.historique.memoriserAction(new CommandeDessinerForme(this.dessin.exporterXML(), triangle, this.vuePlancheDessin));
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
		
		public void notifierActionRetournerEnArriere()
		{
			Console.WriteLine("notifierActionRetournerEnArriere()");
			Commande commande = this.historique.abandonnerAction();
			if(null != commande) commande.annuler();
		}
		
		public void dessinerXML(string dessinXML)
		{
			Console.WriteLine("dessinerXML() - " + dessinXML);
			LecteurXML lecteur = new LecteurXML();
			List<Forme> listeForme = lecteur.lireXML(dessinXML);
			foreach(Forme forme in listeForme)
			{
				switch(forme.type)
				{
					case Forme.TYPE_FORME.CERCLE:
						this.vuePlancheDessin.afficherCercle((Cercle)forme);
						break;
					case Forme.TYPE_FORME.CARRE:
						// TODO carre
						break;
					case Forme.TYPE_FORME.TRIANGLE:
						// TODO triangle
						break;
				}
			}
			this.vuePlancheDessin.nettoyerDessin();			
		}
		
	}
}
