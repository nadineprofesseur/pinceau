﻿/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/27/2018
 * Time: 09:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pinceau.modele
{
	/// <summary>
	/// Description of Reserve.
	/// </summary>
	public class Reserve
	{
		
		protected Carre grandCarreBlanc;
		protected Carre grandCarreNoir;
		protected Carre petitCarreRouge;
		protected Carre petitCarreJaune;
		
		public float PETIT = 15;
		public float GRAND = 25;
		
		public Reserve()
		{
			this.grandCarreBlanc = new Carre(new Forme.Couleur(255,255,255), GRAND);
			this.grandCarreNoir = new Carre(new Forme.Couleur(0,0,0), GRAND);
			// https://www.rapidtables.com/convert/number/hex-to-decimal.html
			this.petitCarreRouge = new Carre(new Forme.Couleur(242,48,48), PETIT); // FFF23030
			this.petitCarreJaune = new Carre(new Forme.Couleur(252,237,121), PETIT); // FFFCED79			
		}
		
		public Carre creerGrandCarreBlanc()
		{
			return this.grandCarreBlanc.cloner();
		}
		
		public Carre creerGrandCarreNoir()
		{
			return this.grandCarreNoir.cloner();
		}
		
		public Carre creerPetitCarreRouge()
		{
			return this.petitCarreRouge.cloner();
		}
		
		public Carre creerPetitCarreJaune()
		{
			return this.petitCarreJaune.cloner();
		}
		
		
		
	}
}
