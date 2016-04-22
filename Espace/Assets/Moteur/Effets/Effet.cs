using System;
using UnityEngine;
using System.Xml;

namespace AssemblyCSharp
{
	public class Effet
	{
		public int priorite = 0;

		public Effet ()
		{

		}


		public Effet (XmlNode node)
		{

		}

		public void jouer(Batiment batiment) {
			appliquerEffet (batiment);
			if (batiment.kase.scriptCase.isVisible) {
				appliquerEffetGraphique (batiment);
			}
				
		}

		virtual public void appliquerEffet(Batiment batiment) {}
		virtual public void appliquerEffetGraphique(Batiment batiment) {}


	}
}

