﻿using System;
using System.Collections.Generic;
using Projet_IMA.form;
using Projet_IMA.Lights;
using System.Linq;
using System.Text;


namespace Projet_IMA
{
    public class Sphere: Object3D
    {
        
        private float rayon;
        
        public Sphere(V3 p_trans, float p_ray, Couleur p_couleur)
            :this(p_trans,p_ray,p_couleur,null)
        {           
            
        }

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

        public override bool testColition(V3 positionStart,V3 direction ,out double TPositionColition )
        {
            // need aproximation to calculate float
            // calculate the aproximation

            double a;
            double b;
            double c;

            a = direction* direction;
            b = 2 *direction* (positionStart - this.getPosition() );
            c = (positionStart-this.getPosition())* (positionStart - this.getPosition()) - this.rayon * this.rayon ;


            // calcul alpha  = B²-4ac
            double alpha = b * b - 4 * a * c;

            

            // 0 result no colition alpha = 0
            if (alpha < 0)
            {
                
                TPositionColition = 0;
                return false;
            }

            // 1 colition tangante
            if (Double.Equals(alpha,0))
            {
                TPositionColition = (-b)/ (2 * a);
                return true;
            }

            // 2 colition 
            if (alpha > 0)
            {
                double t1 = (-b + Math.Sqrt(alpha)) / (2 * a);
                double t2 = (-b - Math.Sqrt(alpha)) / (2 * a);

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
                    return true;
                }
            }   

            TPositionColition = 0;
            return false;
        }


        public override void draw(ZBuffer zBuffer,List<Light> listLight)
        {
            for (double u = 0.0; u <2*Math.PI ;u += 0.005  )
            {
                for (double v = -Math.PI/2; v < Math.PI/2; v += 0.005)
                {
                    V3 vectSphere =  new V3( (float)  (this.rayon * Math.Cos(v) * Math.Cos(u)),
                                             (float)  (this.rayon * Math.Cos(v) * Math.Sin(u)),
                                             (float)  (this.rayon * Math.Sin(v)));

                    V3 copyvectSphere = new V3(vectSphere);
                    copyvectSphere.Normalize();

                    float dhsdu;
                    float dhsdv;

                    this.getBump(u/(Math.PI*2),v/Math.PI + Math.PI/2, out dhsdu,out  dhsdv);


                    V3 dmsdu = new V3(  (float)(-1  * Math.Cos(v) * Math.Sin(u)),
                                        (float)(1 * Math.Cos(v) * Math.Cos(u)),
                                        0.0f);

                    V3 dmsdv = new V3(  (float)(-1  * Math.Sin(v) * Math.Cos(u)),
                                        (float)(-1 * Math.Sin(v) * Math.Sin(u)),
                                        (float)(1  * Math.Cos(v)));

                    V3 dmpsdu = dmsdu + dhsdu * copyvectSphere;
                    V3 dmpsdv = dmsdv + dhsdv * copyvectSphere;
                   

                    V3 Np = ((dmpsdu ^ dmpsdv) / (dmpsdu ^ dmpsdv).Norm());

                    V3 vecteurBump = Np;

                    V3 vect = this.getPosition() + vectSphere;

                    int xecr = (int)vect.x;
                    int yecr = (int)vect.z;

                    if (vect.y < zBuffer[xecr,yecr])
                    {
                        Couleur vcolor = new Couleur();
                       
                        foreach (Light light in listLight)
                            vcolor += light.applyLight(this,vecteurBump,this.getColor(u/(2*Math.PI),v/Math.PI + Math.PI / 2));

                        zBuffer[xecr, yecr] = vect.y;
                        BitmapEcran.DrawPixel(xecr,yecr,vcolor);
                    }
                }
            }

        }
    }
}