using System;
using System.Collections.Generic;
using AssemblyCSharp;

namespace AssemblyCSharp
{
	public class Colonie
	{
		Dictionary<Ressources, float> reserves = new Dictionary<Ressources, float>();
		List<Conseiller> conseillers = new List<Conseiller>();

		public Colonie ()
		{
			foreach (Ressources ressource in Enum.GetValues(typeof(Ressources))) {
				reserves.Add(ressource,0.0f);
				}

			reserves.Remove (Ressources.NOURRITURE);
			reserves.Add (Ressources.NOURRITURE,100.0F);

			reserves.Remove (Ressources.EAU);
			reserves.Add (Ressources.EAU,100.0F);

			reserves.Remove (Ressources.OXYGENE);
			reserves.Add (Ressources.OXYGENE,50.0F);

			foreach (CategoriesConseiller c in Enum.GetValues(typeof(CategoriesConseiller))) {
				Conseiller conseiller = new Conseiller();
				conseiller.categorie = c;
				conseillers.Add(conseiller);
			}
		}

		public void jouer() {
			foreach (Conseiller c in conseillers) {
				c.jouer();
			}
		}

		public float getQuantiteDeRessource(Ressources r) {
			return reserves[r];
		}
	}
}

