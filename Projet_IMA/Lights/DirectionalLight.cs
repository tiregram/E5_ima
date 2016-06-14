using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Projet_IMA.form;

namespace Projet_IMA.Lights
{
    class DirectionalLight:Light
    {
        private V3 direction;

        public DirectionalLight(V3 p_direction ,Couleur p_couleur):base(p_couleur)
        {
            this.direction = p_direction;
        }


        public override Couleur applyLight(Object3D b, V3 v, Couleur color_surface)
        {
            return this.diffuse(b,v,color_surface) + this.specular(b,v,color_surface);
        }

        public  Couleur diffuse(Object3D b, V3 v, Couleur color_surface)
        {
            V3 vectpoint_lamp = this.direction;
            V3 vectPoint_tang = v;

            return color_surface * this.couleur * Math.Max((vectpoint_lamp * vectPoint_tang) / (vectpoint_lamp.Norm() * vectPoint_tang.Norm()), 0.0f);
        }

        public  Couleur specular(Object3D b, V3 v, Couleur color_surface)
        {
            V3 copy_v = new V3(v);
            copy_v.Normalize();
            V3 copy_pos = new V3(this.direction);
            copy_pos.Normalize();

            float sca = (copy_pos * copy_v);
            V3 v_curent_perfect = (copy_v * sca * 2.0f) - copy_pos;
            V3 v_current_oeil = -(v + b.getPosition()) + ProjetEleve.eyesPosition;

            float a = (float)Math.Pow((Math.Max((v_curent_perfect * v_current_oeil) / (v_curent_perfect.Norm() * v_current_oeil.Norm()), 0)), 30);
            return this.couleur * a;
        }

    }
}
