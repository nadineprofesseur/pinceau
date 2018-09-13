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
		enum FORME{CERCLE,CARRE,TRIANGLE};
		private FORME formeActive;
		
		public ControleurDessin(VuePlancheDessin vue)
		{
			this.vuePlancheDessin = vue;
		}
		public void notifierActionNettoyerDessin()
		{
			this.vuePlancheDessin.nettoyerDessin();
		}
		public void notifierActionDessinerCercle()
		{
			this.formeActive = FORME.CERCLE;
			//this.vuePlancheDessin.illuminerActionCercle();
		}
		public void notifierActionDessinerCarre()
		{
			this.formeActive = FORME.CARRE;
		}
		public void notifierActionDessinerTriangle()
		{
			this.formeActive = FORME.TRIANGLE;
		}
		public void notifierActionClicDessin(int x, int y)
		{
			this.vuePlancheDessin.nettoyerDessin();
		}
	}
}
