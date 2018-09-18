/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 09/18/2018
 * Time: 16:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Pinceau.modele
{
	/// <summary>
	/// Equivalent de carte dans votre projet
	/// </summary>
	public class Dessin
	{
		public List<Forme> listeFormes {get;set;} // TOOSO pas de set car on ne veut pas remplacer l'objet liste, sa gestion est controllee par Dessin
		
		public Dessin()
		{
			this.listeFormes = new List<Forme>(); // Ne pas oublier d'instancier la collection avant de l'utiliser !!!
		}
		
		public void ajouterForme(Forme forme)
		{
			// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=netframework-4.7.2	
			// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add?view=netframework-4.7.2#System_Collections_Generic_List_1_Add__0_
			this.listeFormes.Add(forme);
		}
	}
}
