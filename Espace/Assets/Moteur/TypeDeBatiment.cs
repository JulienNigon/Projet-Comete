using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class TypeDeBatiment
	{
		public CategoriesConseiller categorie;
		public int niveau;
		public string nom;
		public UnityEngine.Object prefab;
		public float poids;
		public List<Effet> effets = new List<Effet> ();


		public TypeDeBatiment ()
		{
		}
	}
}

