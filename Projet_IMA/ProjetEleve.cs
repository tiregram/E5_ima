using System;
using System.Collections.Generic;
using System.Linq;
using Projet_IMA.form;
using System.Text;
using Projet_IMA.Lights;

namespace Projet_IMA
{
    static class ProjetEleve
    {
        public static V3  eyesPosition;

        public static void Go()
        {
            eyesPosition = new V3(0, -3000f, 0);



            List<Object3D> listElement = new List<Object3D>();
            //ground
            listElement.Add(new Rectangle(new V3(-50f, 0f, -10f), new V3(100f, 0f, 0f), new V3(0, 100f, 0f), new Texture("brick01.jpg"), new Texture("lead_bump.jpg")));

            listElement.Add(new Rectangle(new V3(-20.0f, 50f, 10f), new V3(20f, 20f,0),new V3(0,0,20f),new Texture("lead.jpg"),new Texture("lead_bump.jpg")));
            listElement.Add(new Sphere(new V3(0.0f, 50f, 0.0f), 15f, new Texture("carreau.jpg"), new Texture("bump38.jpg")));

            listElement.Add(new Sphere(new V3(20.0f, 75f, 0.0f), 20f, new Couleur(1f,0,0), new Texture("bump38.jpg")));
            

            //listElement.Add(new Sphere(new V3(200.0f, 100f, 200f), 60f, new Texture("lead.jpg"), new Texture("lead_bump.jpg")));
            //listElement.Last().setBumpMap(new Texture("lead_bump.jpg"));

            //listElement.Add( new Boule(new V3(300f, 100f, 300f), 60f,new Couleur(0.0f, 0.0f, 1f)));
            //listElement.Last().setTexture(new Texture("brick01.jpg"));


            //listElement.Add( new Boule(new V3(250.0f, 50f, 300f), 80.0f,   new Couleur(0.0f, 1f, 0.0f)));
            //listElement.Last().setTexture(new Texture("rock.jpg"));

            List<Light> listLight = new List<Light>();

            listLight.Add(new DirectionalLight(new V3(1f, 1f, 1f), new Couleur(.7f, .7f, .7f)));
            listLight.Add(new AmbiantLight(new Couleur(.1f, 0.1f, 0.1f)));

            double L = 10;
            double H = 10;
            System.Console.WriteLine("rendu begin");

            V3 centre = new V3(0.0f, -10.0f, 0.0f);

            for (double x = -L; x < L; x += ((2 * L) / 957.0))
            {
                
                for (double z = -H; z < H; z += ((2 * H) / 569.0))
                {

                    V3 rayProjection =   new V3((float)x, 0.0f, (float)z) - centre;
                    
                    rayProjection.Normalize();
                    //rayProjection = - rayProjection;
                    //Console.WriteLine(rayProjection.x +"," + rayProjection.y+","+rayProjection.z);

                    Double positionColition = 0;
                    Double minPosition = Double.MaxValue ;
                    Object3D elementprox = null;

                    // test with the forms
                    foreach (Object3D one in listElement)
                    {
                        if (one.testColition(centre, rayProjection, out positionColition) && positionColition < minPosition)
                        {
                            minPosition = positionColition;
                            elementprox = one;
                        }
                    }
                    if (elementprox !=  null) {
                        Couleur color_pixel = elementprox.drawPixel((float)minPosition * rayProjection + centre, listLight);
                        BitmapEcran.DrawPixel((int)((x + 10) * 957 / 20), (int)((z + 10) * (568 / 20)), color_pixel);
                    }

                }
            }
            System.Console.WriteLine("rendu end");
            //foreach (Object3D obj in listElement)
            //  obj.draw(zb,listLight);

        }
    }
}
