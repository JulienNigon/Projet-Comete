using System;
using System.Collections.Generic;


namespace AssemblyCSharp
{
	public class GestionnaireDePartie
	{

		public List<Case> cases = new List<Case>(); /*Liste des cases du jeu*/
		public int tour = 0;
		public Joueur joueur;
		public Colonie colonie;

		public static int maxXCases = 1000;
		public static int maxYCases = 1000;
		public Case[,] grille = new Case[maxXCases,maxYCases]; 
		public static GestionnaireDePartie instance;


		public GestionnaireDePartie ()
		{
			DataManager dm = new DataManager ();
			joueur = new Joueur ();
			colonie = new Colonie ();
			colonie.genererPopulationAleatoire (20);
			instance = this;
		}

		public void jouerUnTour() {
			colonie.jouer ();
			foreach (Case kase in cases) {
				kase.jouer();
			}
			tour++;
		}



		//"case" est un mot clef du langage. On utilisera donc le merveilleux mot "kase".
		public void ajouterUneCase(Case kase) {
			cases.Add(kase);
			grille [kase.coordX + (maxXCases/2) , kase.coordZ + (maxYCases/2)] = kase;
		}

		public Case obtenirCase(int x, int y) {
			return grille [x + (maxXCases / 2), y + (maxYCases / 2)];
		}
	}
}

