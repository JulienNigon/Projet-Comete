using System;
using AssemblyCSharp;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class Batiment
	{
		public TypeDeBatiment type;
		public Case kase;
		public bool pasEffetBloquant = true;

		public Batiment (TypeDeBatiment type, Case kase)
		{
			this.type = type;
			this.kase = kase;
		}

		public Batiment (TypeDeBatiment type)
		{
			this.type = type;
		}

		public String getNom() {
			return type.nom;
		}

		/* Retourne la description du bâtiment. */
		public String getDescription() {
			return type.description;
		}

		/*Un bâtiment contient une liste d'effets.
		 * Lorsqu'on lui demande de jouer, il applique tous ses effets les
		 * uns après les autres. L'effet n'est pas propre au bâtiment, il 
		 * a donc besoin de recevoir le bâtiment en info pour agir.
		 */
		public void jouer() {
			foreach (Effet effet in type.effets) {
				if (pasEffetBloquant) {
					effet.jouer (this);
				} else {
					pasEffetBloquant = true;
					break;
				}
			}
		}
	}
}

