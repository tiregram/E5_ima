using System;
using System.Collections.Generic;
using Projet_IMA.Lights;

using System.Linq;
using System.Text;

namespace Projet_IMA.form
{
    class Rectangle : Object3D
    {
        V3 largeur;
        V3 longueur;

        private Rectangle(V3 p_position, V3 p_largeur, V3 p_longueur, Texture difuse, Couleur p_couleur, Texture bump)
            : base(p_position, difuse, p_couleur, bump)
        {
            this.largeur = p_largeur;
            this.longueur = p_longueur;
        }


        public Rectangle(V3 p_position, V3 p_largeur, V3 p_longueur, Couleur p_couleur)
           : this(p_position, p_largeur, p_longueur, null, p_couleur, null)
        { }

        public Rectangle(V3 p_position, V3 p_largeur, V3 p_longueur, Texture difuse, Texture bump)
         : this(p_position, p_largeur, p_longueur, difuse, new Couleur(), bump)
        { }

        public Rectangle(V3 p_position, V3 p_largeur, V3 p_longueur, Couleur couleur, Texture bump)
         : this(p_position, p_largeur, p_longueur, null, couleur, bump)
        { }


        public override bool testColition(V3 positionStart, V3 direction, out double TPositionColition)
        {

            V3 n = (this.largeur ^ this.longueur);
            n.Normalize();

            V3 R0a = this.getPosition() - positionStart;
            double t = (R0a * n) / (direction * n);



            if (t < 0)
            {
                TPositionColition = 0;
                return false;

            }


            V3 ai = (float)t * direction + positionStart - this.getPosition();

            double la = (this.largeur * ai) / (this.largeur * this.largeur);
            double lo = (this.longueur * ai) / (this.longueur * this.longueur);

            if (0 < lo && lo < 1 && 0 < la && la < 1)
            {
                TPositionColition = t;
                return true;
            }

            TPositionColition = 0;
            return false;


        }



        public override Couleur drawPixel(V3 position)
        {
            V3 ai = position - this.getPosition();

            double la = (this.largeur * ai) / (this.largeur * this.largeur);
            double lo = (this.longueur * ai) / (this.longueur * this.longueur);

            V3 vectRect = ((float)la * this.largeur) + ((float)lo * this.longueur);

            V3 copyVectRect = new V3(vectRect);
            copyVectRect.Normalize();

            float dhsdu;
            float dhsdv;

            this.getBump(la, lo, out dhsdu, out dhsdv);


            V3 dmsdu = new V3((float)(-1 * Math.Cos(lo) * Math.Sin(la)),
                                (float)(1 * Math.Cos(lo) * Math.Cos(la)),
                                0.0f);

            V3 dmsdv = new V3((float)(-1 * Math.Sin(lo) * Math.Cos(la)),
                                (float)(-1 * Math.Sin(lo) * Math.Sin(la)),
                                (float)(1 * Math.Cos(lo)));

            V3 dmpsdu = dmsdu + dhsdu * copyVectRect;
            V3 dmpsdv = dmsdv + dhsdv * copyVectRect;


            V3 Np = ((dmpsdu ^ dmpsdv) / (dmpsdu ^ dmpsdv).Norm());

            V3 vecteurBump = Np;

            V3 position_point = this.getPosition() + vectRect;



            Couleur vcolor = new Couleur();

            foreach (Light light in RenderSing.getCurrentRender().getLight())
            {
                vcolor += light.applyLight(this, position_point ,vecteurBump, this.getColor(la, lo));
            }

            return vcolor;

        }
    }

    
}
