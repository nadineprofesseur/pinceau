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
	/// Description of Carre.
	/// </summary>
	public class Carre : Forme
	{
		public Carre(int x, int y, Couleur couleur) : base(x, y, couleur)
		{
			this.type = TYPE_FORME.CARRE;			
		}
	}
}
