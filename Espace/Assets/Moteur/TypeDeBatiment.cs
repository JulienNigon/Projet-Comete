using System;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

namespace AssemblyCSharp
{
	public class TypeDeBatiment
	{
		public CategoriesConseiller categorie;
		public int niveau;
		public string nom;
		public UnityEngine.Object prefab;
		public int poids;
		public List<Effet> effets = new List<Effet> ();
		public String description;


		public TypeDeBatiment ()
		{
		}

		public void ajouterEffet(Effet effet) {
			for (int i = 0; i < effets.Count; i++) {
				if (effets [0].priorite < effet.priorite) {
					effets.Insert (i,effet);
					break;
				}
			}
			effets.Add (effet);
		}
	}
}

