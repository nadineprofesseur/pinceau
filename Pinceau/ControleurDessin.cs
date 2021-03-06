﻿/*
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

namespace Pinceau
{
	/// <summary>
	/// Description of ControleurDessin.
	/// </summary>
	public class ControleurDessin
	{				
		
		protected Dessin dessin = new Dessin();
		private VuePlancheDessin vuePlancheDessin = null;
		enum FORME{CERCLE,CARRE,TRIANGLE,AUCUNE};
		private FORME formeActive;
		
		public ControleurDessin(VuePlancheDessin vue)
		{
			this.vuePlancheDessin = vue;
			
			// TEST debut
			Dessin dessin = new Dessin();
			Cercle cercle = new Cercle(100,100, new Forme.Couleur(0,0,0));
			dessin.ajouterForme(cercle);
			// TEST fin
			
		}
		public void notifierActionNettoyerDessin()
		{
			this.vuePlancheDessin.nettoyerDessin();
			
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
		private DessinDAO dessinDAO = new DessinDAO();
		public void notifierActionSauvegarder()
		{
			string xml = this.dessin.exporterXML();
			this.dessinDAO.ajouterDessin(xml);
		}
		public void notifierActionClicDessin(int x, int y)
		{
			switch(formeActive)
			{
				case FORME.CERCLE:
					Debug.WriteLine("FORME.CERCLE");
					Cercle cercle = new Cercle(x,y, new Forme.Couleur(0,0,0));
					this.dessin.ajouterForme(cercle);
					this.vuePlancheDessin.afficherCercle(cercle);
					this.vuePlancheDessin.desactiverBoutonCercle();
				break;
				case FORME.CARRE:
					Debug.WriteLine("FORME.CARRE");
					Carre carre = new Carre(x,y,new Forme.Couleur(0,0,0));
					this.dessin.ajouterForme(carre);
					this.vuePlancheDessin.afficherCarre(carre);
					this.vuePlancheDessin.desactiverBoutonCarre();
				break;
				case FORME.TRIANGLE:
					Debug.WriteLine("FORME.TRIANGLE");
					Triangle triangle = new Triangle(x,y,new Forme.Couleur(0,0,0));
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
		
	}
}
