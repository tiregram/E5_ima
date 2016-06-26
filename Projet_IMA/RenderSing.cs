using Projet_IMA.form;
using Projet_IMA.Lights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_IMA
{
    class RenderSing
    {

         
        //singleton 
        public static RenderSing getCurrentRender()
        {
            if (current == null)
            {
                current = new RenderSing(new V3(0,0,0),
                                         new V3(0,1,0),
                                         -20,
                                         400,
                                         400);
            }

            return current;
        }

        public void clear()
        {
            this.all_light.Clear();
            this.all_object.Clear();

        }
        
        private static RenderSing current;

        public bool alock;

        
        private V3 direction;
        private V3 position;
        private int resolution_X;
        private int resolution_Y;

        public void setResolutionX(int p_x) { this.resolution_X = p_x; }
        public void setResolutionY(int p_y) { this.resolution_Y = p_y; }
        public int getResolutionX() { return this.resolution_X; }
        public int getResolutionY() { return this.resolution_Y; }


        private double eyesdistance;

        public void setEyesPosition(double a) { this.eyesdistance = a;}

        private double ration
        {
            get { return ((double)this.resolution_X) / ((double)this.resolution_Y); }
        }

        public double stepX
        {
            get { return (20.0)/(this.resolution_X)*0.95; }
        }

        public double stepY
        {
            get { return (20.0)/(this.resolution_Y)*0.95; }
        }


        public V3 getPosition(){ return position; }
        public double getMaxX(){ return 10.0 * this.ration; }
        public double getMaxY(){ return 10.0 ;}
        public double getMinX(){ return -10.0 * this.ration;}
        public double getMinY(){ return -10.0 ;}

        public V3 getEyesPosition() { return this.position + new V3(0, (float)this.eyesdistance, 0 ); }

        public void Draw(double x ,double y ,Couleur couleur )
        {

            int x_sceem =  (int)( (x / (20.0 * this.ration)) * this.resolution_X + this.resolution_X / 2);
            int y_screem = (int)( (y / 20.0) * this.resolution_Y + this.resolution_Y / 2);
            //Console.WriteLine("x:"+x_sceem+" y:"+y_screem);
            BitmapEcran.DrawPixel(x_sceem,y_screem,couleur);
        }

        private List<Object3D> all_object;
        private List<Light> all_light;

        private RenderSing(V3 position,V3 direction,double p_eyesDistance ,int x, int y)
        {
            this.resolution_X = x;
            this.resolution_Y = y;
            this.position  = new V3(position); 
            this.direction = new V3(direction);
            this.eyesdistance = p_eyesDistance;

            this.all_object = new List<Object3D>();
            this.all_light = new List<Light>();

            this.alock = true;
        }


        // fluent 
        public RenderSing addObject(Object3D objectToAdd)
        {
            this.all_object.Add(objectToAdd);
            return this;
        }

        public void removeObject(Object3D objectToRemove)
        {
            this.all_object.Remove(objectToRemove);
        }

        public  List<Object3D>  getObject()
        {
            return this.all_object;
        }

        //fluent
        public RenderSing addLight(Light lightToAdd)
        {
            this.all_light.Add(lightToAdd);
            return this;
        }

        public void removeLight(Light lightToRemove)
        {
            this.all_light.Remove(lightToRemove);
        }

        public List<Light> getLight()
        {
            return this.all_light;
        }

    }
}
