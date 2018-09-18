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
		public enum TYPE_FORME {CERCLE, CARRE, TRIANGLE, AUCUNE}; 
		// defaut de cette maniere d'identifier le type : classe de base est modifiee par chaque classe deriveee ajoutee - negatif
		// le probleme resulte du fait que les formes n'ont pas de classe Vues et donc le polymorphisme des formes est impossible dans les vues
		
		public int x {get; set;}
		public int y {get; set;}
		public Couleur couleur {get;set;}
		public TYPE_FORME type {get;set;}
		
		public Forme(int x, int y, Couleur couleur)
		{
			this.x = x;
			this.y = y;
			this.couleur = couleur;
			this.type = TYPE_FORME.AUCUNE;
		}				
		
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
	}
}
