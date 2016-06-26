using System;
using System.Collections.Generic;
using Projet_IMA.form;
using System.Linq;
using System.Text;

namespace Projet_IMA.Lights
{
    class AmbiantLight:Light
    {
        public AmbiantLight(Couleur col) : base(col)
        {

        }

        public override Couleur applyLight(Object3D b,V3 pos , V3 v, Couleur color_surface)
        {
            return this.couleur * color_surface; 
        }
    }
}
