using System;
using Projet_IMA.form;
using Projet_IMA.Lights;

namespace Projet_IMA
{

    static class ProjetEleve
    {
    
        public static Texture skymap;    

        public static void Go()
        {
            /*
              RenderSing.getCurrentRender()
                  .addObject(new Rectangle(   new V3(-50f, 0f, -10f),
                                              new V3(100f, 0f, 0f),
                                              new V3(0, 100f, 0f),
                                              new Texture("brick01.jpg"),
                                              new Texture("lead_bump.jpg")))

                  .addObject(new Rectangle(   new V3(-20.0f, 50f, 10f),
                                              new V3(20f, 20f,10f),
                                              new V3(0,0,20f),
                                              new Texture("lead.jpg"),
                                              new Texture("lead_bump.jpg")))

                  .addObject(new Sphere(      new V3(0.0f, 50f, 0.0f),
                                              15f,
                                              new Texture("carreau.jpg"),
                                              new Texture("bump38.jpg")))

                  .addObject(new Sphere(      new V3(20.0f, 75f, 0.0f), 
                                              10f,
                                              new Couleur(1f,0,0),
                                              new Texture("bump38.jpg")))
                  ;*/
                  
    /*

            RenderSing.getCurrentRender()
                .addLight(new DirectionalLight( new V3(1f, -1f, 1f),
                                                new Couleur(.8f, .8f, .8f)))

                .addLight(new AmbiantLight(     new Couleur(.3f, 0.3f, 0.3f)));
                */
           

            RenderSing rnd = RenderSing.getCurrentRender();

            for (   double x = rnd.getMinX();
                    x < rnd.getMaxX();
                    x+= rnd.stepX)
            {
                
                for (   double z =  rnd.getMinY();
                        z <rnd.getMaxY();
                        z+= rnd.stepY)
                {

                    V3 rayProjection = new V3((float)x, 0.0f, (float)z) - RenderSing.getCurrentRender().getEyesPosition();
                    rayProjection.Normalize();


                    Double positionColition = 0;
                    Double minPosition = Double.MaxValue ;
                    Object3D elementprox = null;

                    foreach (Object3D one in RenderSing.getCurrentRender().getObject())
                    {
                        if (one.testColition(
                                RenderSing.getCurrentRender().getEyesPosition(),
                                rayProjection,
                                out positionColition) && positionColition < minPosition)
                        {
                            minPosition = positionColition;
                            elementprox = one;
                        }
                    }

                    Couleur color_pixel;

                    if (elementprox != null)
                    {
                        color_pixel = elementprox.drawPixel((float) minPosition * rayProjection + RenderSing.getCurrentRender().getEyesPosition());
                        
                    }
                    else
                    {
                        //TODO sky map inplements
                        color_pixel = new Couleur(0,0,0);
                    }

                    RenderSing.getCurrentRender().Draw(x, z, color_pixel);
                }
            }

        }
    }
}
