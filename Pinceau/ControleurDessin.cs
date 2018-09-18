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

namespace Pinceau
{
	/// <summary>
	/// Description of ControleurDessin.
	/// </summary>
	public class ControleurDessin
	{				
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
		public void notifierActionClicDessin(int x, int y)
		{
			switch(formeActive)
			{
				case FORME.CERCLE:
					Debug.WriteLine("FORME.CERCLE");
					this.vuePlancheDessin.afficherCercle(0,0);
					this.vuePlancheDessin.desactiverBoutonCercle();
				break;
				case FORME.CARRE:
					Debug.WriteLine("FORME.CARRE");
					this.vuePlancheDessin.afficherCarre(0,0);
					this.vuePlancheDessin.desactiverBoutonCarre();
				break;
				case FORME.TRIANGLE:
					Debug.WriteLine("FORME.TRIANGLE");
					this.vuePlancheDessin.afficherTriangle(0,0);
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
