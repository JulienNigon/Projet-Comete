using System;
using System.Collections.Generic;
using AssemblyCSharp;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Colonie
	{
		public Dictionary<Ressources, float> reserves = new Dictionary<Ressources, float>();
		public Dictionary<CategoriesConseiller,Conseiller> conseillers = new Dictionary<CategoriesConseiller,Conseiller>();
		public static Colonie instance;
		public List<Batiment> batimentsDisponibles = new List<Batiment> ();

		public List<Colon> colonsEnStase = new List<Colon> ();
		public List<Colon> colonsEveilles = new List<Colon> ();
		public float moral = 100.0f;

		public float alignementBien = 0.0f;
		public float alignementOrdre = 0.0f;

		public Colonie ()
		{
			Debug.Log ("Creation de la colonie");

			instance = this;

			foreach (Ressources ressource in Enum.GetValues(typeof(Ressources))) {
				reserves.Add(ressource,0.0f);
				}

			reserves.Remove (Ressources.NOURRITURE);
			reserves.Add (Ressources.NOURRITURE,100.0F);

			reserves.Remove (Ressources.EAU);
			reserves.Add (Ressources.EAU,100.0F);

			reserves.Remove (Ressources.OXYGENE);
			reserves.Add (Ressources.OXYGENE,50.0F);

			reserves.Remove (Ressources.ENERGIE);
			reserves.Add (Ressources.ENERGIE,3000.0F);

		//	for (int i = 0 ; i < Enum.GetValues(typeof(CategoriesConseiller).Le
			foreach (CategoriesConseiller c in Enum.GetValues(typeof(CategoriesConseiller))) {
				Conseiller conseiller = new Conseiller(c);
				conseillers.Add(c,conseiller);
			}
		}

		public void genererPopulationAleatoire(int nombreDeColons) {
			for (int i = 0; i < nombreDeColons; i++) {
				colonsEnStase.Add (new Colon(DataManager.dataManager.getRandomColon()));
			}
		}

		public void jouer() {
			foreach (CategoriesConseiller c in conseillers.Keys) {
				conseillers[c].jouer();
			}
			for (int i = colonsEnStase.Count - 1; i >= 0; i--) {
				if (!consommer (Ressources.ENERGIE, 3)) tuerColon(colonsEnStase[i]);
			}

			for (int i = colonsEveilles.Count - 1; i >= 0; i--) {
				//TODO : éviter que le colon consomme un peu si il meurt sur O2 ou nourriture
				if (!consommer (Ressources.EAU, 1)) tuerColon(colonsEveilles[i]);
				if (!consommer (Ressources.OXYGENE, 1)) tuerColon(colonsEveilles[i]);
				if (!consommer (Ressources.NOURRITURE, 1)) tuerColon(colonsEveilles[i]);
			}

		}

		public void tuerColon(Colon c) {
			if (colonsEnStase.Contains (c)) {
				colonsEnStase.Remove (c);
			}
			else if (colonsEveilles.Contains (c)) {
				colonsEveilles.Remove (c);
			}
			moral--;
		}

		public float getQuantiteDeRessource(Ressources r) {
			return reserves[r];
		}

		public void produire(Ressources r, float quantite) {
			reserves [r] += quantite;
			//Debug.Log ("Nouvelles réserves :" + reserves [r]);
		}

		public bool consommer(Ressources r, float quantite) {
			if (reserves [r] >= quantite) {
				reserves [r] -= quantite;
				return true;
			} else {
				return false;
			}
		}

		public bool factionEstPresente (Faction faction) {
			bool estPresent = false;
			foreach (Conseiller c in conseillers.Values) {
				if (c.faction.Equals (faction)) {
					estPresent = true;
				}
			}
			return estPresent;
		}

		public void modifierAlignementBien(float modif) {
			alignementBien += modif;
		}

		public void modifierAlignementOrdre(float modif) {
			alignementOrdre += modif;
		}
	}
}

