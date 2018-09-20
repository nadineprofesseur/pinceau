/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/18/2018
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Pinceau.donnee
{
	/// <summary>
	/// Description of DessinDAO.
	/// </summary>
	public class DessinDAO
	{
		public DessinDAO()
		{
		}
		
		public void ajouterDessin(string xml)	
		{
			Console.WriteLine(xml); // TEST
			System.IO.File.WriteAllText(@"..\..\sauvegarde\dessin.xml",xml); // TODO gerer les noms de fichiers - les generer
		}
		
	}
}
