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
using Pinceau.modele;

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
			this.controleur.notifierActionNettoyerDessin();
		}
		// https://stackoverflow.com/questions/4157717/how-can-i-listen-for-left-mouseclicks-on-a-canvas-in-a-c-sharp-wpf
		void dessin_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			System.Windows.Point position = e.GetPosition(null);
			this.controleur.notifierActionClicDessin((int)position.X,(int)position.Y);
		}
		// Fin gestionnaires d'événements
		
		// Cas d'exception, dans l'application d'edition avec vue non-rafraichissante on ne stocke pas le modele dans la vue
		// Generalement, on le fait on stocke le modele complet dans la vue 
		public void afficherDessin(Dessin dessin)
		{
			foreach(Forme forme in dessin.listeFormes) // pas public, on passe par le get
			{
				switch(forme.type)
				{
					case Forme.TYPE_FORME.CERCLE : 
						this.afficherCercle((Cercle)forme);
					break;
					case Forme.TYPE_FORME.CARRE : 
						this.afficherCarre((Carre)forme);
					break;
					case Forme.TYPE_FORME.TRIANGLE : 
						this.afficherTriangle((Triangle)forme);
					break;
					default: 
					break;
				}
				
			}
		}
		
		public void afficherCercle(Cercle cercle)
		{
			Ellipse rond = new Ellipse();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			rond.Fill = brosse;
			
			rond.Width = 50; 
			rond.Height = 50;
			rond.Margin = new Thickness(cercle.x,cercle.y,0,0);
						
			this.dessin.Children.Add(rond);			
		}
		
		public void afficherCarre(Carre carre)
		{
			Rectangle rectangle = new Rectangle();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			rectangle.Fill = brosse;
			
			rectangle.Margin = new Thickness(carre.x,carre.y,0,0);
			
			rectangle.Width = 50;
			rectangle.Height = 50;
			this.dessin.Children.Add(rectangle);	
		}
		
		public void afficherTriangle(Triangle triangle)
		{
			// TODO programmer triangle ulterieurement
			/*PointCollection listePoints = new PointCollection();
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
			*/
		}
		
		public  void nettoyerDessin()
		{
			this.dessin.Children.Clear();			
		}
		
		public void activerBoutonCercle()
		{			
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(252,250,121); // TODO pas de chiffre magique
			this.actionDessinerCercle.Background = brosse;
		}
		public void desactiverBoutonCercle()
		{
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = SystemColors.ControlLightColor;
			this.actionDessinerCercle.Background = brosse;
		}
		
		public void activerBoutonCarre()
		{
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(252,250,121); // TODO pas de chiffre magique
			this.actionDessinerCarre.Background = brosse;		
		}
		public void desactiverBoutonCarre()
		{
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = SystemColors.ControlLightColor;
			this.actionDessinerCarre.Background = brosse;
		}
		
		public void activerBoutonTriangle()
		{
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(252,250,121); // TODO pas de chiffre magique
			this.actionDessinerTriangle.Background = brosse;		
		}
		public void desactiverBoutonTriangle()
		{
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = SystemColors.ControlLightColor;
			this.actionDessinerTriangle.Background = brosse;
		}
		
	}
}