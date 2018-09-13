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
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
		}
		
		void actionDessinerTriangle_Click(object sender, RoutedEventArgs e)
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
		void actionDessinerCarre_Click(object sender, RoutedEventArgs e)
		{
			Rectangle carre = new Rectangle();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			carre.Fill = brosse;
			
			carre.Margin = new Thickness(300,300,0,0);
			
			carre.Width = 50;
			carre.Height = 50;
			this.dessin.Children.Add(carre);	
		}
		
		void actionDessinerCercle_Click(object sender, RoutedEventArgs e)
		{
			Ellipse rond = new Ellipse();
			SolidColorBrush brosse = new SolidColorBrush();
			brosse.Color = Color.FromRgb(239,174,23);
			rond.Fill = brosse;
			
			rond.Width = 50;
			rond.Height = 50;
						
			this.dessin.Children.Add(rond);
			
			//this.dessin.setTop(rond, 100);
			//this.dessin.setLeft(rond, 100);
		}
	}
}