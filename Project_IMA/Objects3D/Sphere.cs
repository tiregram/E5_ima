using System;
using Projet_IMA.form;
using Projet_IMA.Lights;


namespace Projet_IMA
{
    public class Sphere: Object3D
    {
        
        private float rayon;


        public Sphere()
            : this(new V3(),0,new Couleur())
        {}

        public Sphere(V3 p_trans, float p_ray, Couleur p_couleur)
            :this(p_trans,p_ray,p_couleur,null)
        {}

        public Sphere(V3 p_trans, float p_ray, Texture p_texture, Texture p_bumpMap)
           : base(p_trans, p_texture, p_bumpMap)
        {
            this.rayon = p_ray;
        }

        public Sphere(V3 p_trans, float p_ray, Couleur p_couleur,Texture p_bumpMap)
            : base(p_trans, p_couleur, p_bumpMap)
        {
            this.rayon = p_ray;
        }

        public float getRayon() { return this.rayon; }
        public void setRayon(float r) { this.rayon = r; }

        public override bool testColition(V3 positionStart,V3 direction ,out double TPositionColition )
        {
            // need aproximation to calculate float
            // calculate the aproximation

            double a;
            double b;
            double c;

            a = (direction.Norme2());
           

            b = 2 * direction * (positionStart - this.getPosition() );

            c = (positionStart - this.getPosition()).Norme2() - (this.rayon * this.rayon) ;

           
            // calcul alpha  = B²-4ac
            double alpha = (b * b) - (4 * a * c);

            

            // 0 result no colition alpha = 0
            if (alpha < 0)
            {
                
                TPositionColition = 0;
                return false;
            }

            // 1 colition tangante
            if (alpha == 0)
            {
                TPositionColition = (-b)/ (2 * a);
                return true;
            }

            // 2 colition 
            if (alpha > 0)
            {
                //Console.WriteLine("alpha");
                double t2 = (-b + Math.Sqrt(alpha)) / (2 * a);
                double t1 = (-b - Math.Sqrt(alpha)) / (2 * a);

                if (0 < t1 && t1 < t2 )
                {
                    TPositionColition = t1;
                    return true;
                }

                if (t1 < 0 &&  0< t2)
                {
                    TPositionColition = t2;
                    return true;
                }

                if (t1 < 0 && t2 < 0)
                {
                    TPositionColition = 0;
                    return false;
                }
            }   

            TPositionColition = 0;
            return false;
        }

        public override Couleur drawPixel(V3 positionInScene)
        {
            V3 posionForSphere = positionInScene - this.getPosition() ;

            float v;
            float u;

            IMA.Invert_Coord_Spherique(posionForSphere,this.rayon,out u,out v);

            V3 vectSphere = new V3((float)(this.rayon * Math.Cos(v) * Math.Cos(u)),
                                          (float)(this.rayon * Math.Cos(v) * Math.Sin(u)),
                                          (float)(this.rayon * Math.Sin(v)));

            V3 copyvectSphere = new V3(vectSphere);
            copyvectSphere.Normalize();

            float dhsdu;
            float dhsdv;

            this.getBump(u / (Math.PI * 2), v / Math.PI + Math.PI / 2, out dhsdu, out dhsdv);


            V3 dmsdu = new V3((float)(-1 * Math.Cos(v) * Math.Sin(u)),
                                (float)(1 * Math.Cos(v) * Math.Cos(u)),
                                0.0f);

            V3 dmsdv = new V3((float)(-1 * Math.Sin(v) * Math.Cos(u)),
                                (float)(-1 * Math.Sin(v) * Math.Sin(u)),
                                (float)(1 * Math.Cos(v)));

            V3 dmpsdu = dmsdu + dhsdu * copyvectSphere;
            V3 dmpsdv = dmsdv + dhsdv * copyvectSphere;


            V3 Np = ((dmpsdu ^ dmpsdv) / (dmpsdu ^ dmpsdv).Norm());

            V3 vecteurBump = Np;

            V3 vect = this.getPosition() + vectSphere;

                Couleur vcolor = new Couleur();

                foreach (Light light in RenderSing.getCurrentRender().getLight())
                {
                    
                    vcolor += light.applyLight(this,vect, vecteurBump, this.getColor(u / (2 * Math.PI), v / Math.PI + Math.PI / 2));
                } 

                return vcolor;
        }
    }
}
