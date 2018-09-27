/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/20/2018
 * Time: 09:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Pinceau.modele;
using System.Collections.Generic;

namespace Pinceau.action.commande
{
	/// <summary>
	/// Description of CommandeDessinerForme.
	/// </summary>
	public class CommandeDessinerForme : Commande
	{
		
		protected Forme nouvelleForme = null;
		protected string dessinAvant = "";
		protected LecteurXML lecteurXML = new LecteurXML();
		protected VuePlancheDessin vuePlancheDessin;
		
		public CommandeDessinerForme(string dessin, Forme forme, VuePlancheDessin vuePlancheDessin)
		{
			Console.WriteLine("new CommandeDessinerForme - memorise" + dessin);
			this.dessinAvant = dessin;
			this.nouvelleForme = forme;
			this.vuePlancheDessin = vuePlancheDessin;
		}
		public override void executer()
		{
		}
		public override void annuler()
		{
			Console.WriteLine("CommandeDessinerForme.annuler()");
			List<Forme> listeFormes = lecteurXML.lireXML(this.dessinAvant);
			this.vuePlancheDessin.nettoyerDessin();
			foreach(Forme forme in listeFormes) this.vuePlancheDessin.afficherCercle((Cercle)forme); // TODO gerer autres formes
		}

	}
}
