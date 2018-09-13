/*
 * Created by SharpDevelop.
 * User: stamandnadine
 * Date: 2018-09-11
 * Time: 17:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Pinceau
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class VuePlancheDessin : Window
	{
		
		private ControleurDessin controleur = null;
		public VuePlancheDessin()
		{
			InitializeComponent();
			this.controleur = new ControleurDessin(this);
			//this.dessin.AddHandler(PointerPressedEvent, new PointerEventHandler());
		}
		
		// Gestionnaires d'événements de la librairie graphique
		void actionDessinerTriangle_Click(object sender, RoutedEventArgs e)
		{
			this.controleur.notifierActionDessinerTriangle();
			//afficherTriangle(0,0);
		}
		void actionDessinerCarre_Click(object sender, RoutedEventArgs e)
		{
			this.controleur.notifierActionDessinerCarre();
			//afficherCarre(0,0);
		}
		void actionDessinerCercle_Click(object sender, RoutedEventArgs e)
		{
			this.controleur.notifierActionDessinerCercle();
			//afficherCercle(0,0);
		}
		void actionNettoyer_Click(object sender, RoutedEventArgs e)
		{
			this.nettoyerDessin();
		}
		// https://stackoverflow.com/questions/4157717/how-can-i-listen-for-left-mouseclicks-on-a-canvas-in-a-c-sharp-wpf
		void dessin_MouseLeftButtonDown(object sender, RoutedEventArgs e)
		{
			this.nettoyerDessin();	
		}
		// Fin gestionnaires d'événements
		
		public void afficherCercle(int x, int y)
		{
			Ellipse rond = new Ellipse();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			rond.Fill = brosse;
			
			rond.Width = 50;
			rond.Height = 50;
			rond.Margin = new Thickness(x,y,0,0);
						
			this.dessin.Children.Add(rond);			
		}
		
		public void afficherCarre(int x, int y)
		{
			Rectangle carre = new Rectangle();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			carre.Fill = brosse;
			
			carre.Margin = new Thickness(x,y,0,0);
			
			carre.Width = 50;
			carre.Height = 50;
			this.dessin.Children.Add(carre);	
		}
		
		public void afficherTriangle(int x, int y)
		{
			PointCollection listePoints = new PointCollection();
			listePoints.Add(new Point(0,0));
			listePoints.Add(new Point(0,1));
			listePoints.Add(new Point(1,1));
			
			Polygon triangle = new Polygon();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			triangle.Fill = brosse;
			
			triangle.Points = listePoints;
			triangle.Width = 50;
			triangle.Height = 50;
			
			this.dessin.Children.Add(triangle);
		}
		
		public  void nettoyerDessin()
		{
			this.dessin.Children.Clear();			
		}
	}
}