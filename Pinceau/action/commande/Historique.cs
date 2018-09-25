/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/20/2018
 * Time: 09:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Pinceau.action.commande
{
	/// <summary>
	/// Description of Historique.
	/// </summary>
	public class Historique
	{
	
		protected Stack<Commande> dernieresActions = new Stack<Commande>();
		public Historique()
		{
		}
		
		public void memoriserAction(Commande commande)
		{
			this.dernieresActions.Push(commande);
		}
		
		public Commande abandonnerAction()
		{
			if(this.dernieresActions.Count > 0)
				return this.dernieresActions.Pop();
			return null;
		}
		
	}
}
