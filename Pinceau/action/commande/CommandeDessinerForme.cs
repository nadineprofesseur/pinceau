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

namespace Pinceau.action.commande
{
	/// <summary>
	/// Description of CommandeDessinerForme.
	/// </summary>
	public class CommandeDessinerForme : Commande
	{
		
		protected Forme nouvelleForme = null;
		protected string dessinAvant = "";
		
		public CommandeDessinerForme(string dessin, Forme forme)
		{
			Console.WriteLine("new CommandeDessinerForme - memorise" + dessin);
			this.dessinAvant = dessin;
			this.nouvelleForme = forme;
		}
		public override void executer()
		{
		}
		public override void annuler()
		{
		}

	}
}
