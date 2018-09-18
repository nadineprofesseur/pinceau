/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/18/2018
 * Time: 16:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pinceau.modele
{
	/// <summary>
	/// Description of Forme.
	/// </summary>
	public class Forme
	{
		public int x {get; set;}
		public int y {get; set;}
		public Couleur couleur {get;set;}
		
		// A cause de la contrainte architecturale qui empeche d'utiliser Color dans le modele
		public class Couleur
		{
			public int rouge {get;set;}
			public int vert {get;set;}
			public int bleu {get;set;}
			
			public Couleur (int r, int v, int b)
			{
				this.rouge = r;
				this.vert = v;
				this.bleu = b;
			}
		}
				
		
		public Forme()
		{
		}		
		
		public Forme(int x, int y, Couleur couleur)
		{
			this.x = x;
			this.y = y;
			this.couleur = couleur;
		}
		public Forme(int x, int y, int r, int v, int b)
		{
			this.x = x;
			this.y = y;
			this.couleur = new Couleur(r,v,b);
		}
		
	}
}
