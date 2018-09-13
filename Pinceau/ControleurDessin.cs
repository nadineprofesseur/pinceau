/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/13/2018
 * Time: 08:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pinceau
{
	/// <summary>
	/// Description of ControleurDessin.
	/// </summary>
	public class ControleurDessin
	{
		private VuePlancheDessin vuePlancheDessin = null;
		
		public ControleurDessin(VuePlancheDessin vue)
		{
			this.vuePlancheDessin = vue;
		}
	}
}
