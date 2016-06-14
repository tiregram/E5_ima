using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Projet_IMA.form;

namespace Projet_IMA.Lights
{
   public abstract class Light
    {
        protected Couleur couleur;

        protected Light(Couleur pcol)
        {
            this.couleur = pcol; 
        }

        public abstract Couleur applyLight(Object3D b,V3 v, Couleur color_surface);
    }
}
