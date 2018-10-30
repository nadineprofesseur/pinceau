/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 2018-10-30
 * Time: 17:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pinceau
{
	/// <summary>
	/// Description of Journal.
	/// </summary>
	public class Journal
	{
		protected bool actif;
		
		public Journal()
		{
			this.actif = true;
		}
		
		public void ecrire(string message)
		{
			if(this.actif) Console.WriteLine(message);
		}
		
		public void activer()
		{
			this.actif = true;
		}
		public void desactiver()
		{
			this.actif = false;
		}
	}
}
