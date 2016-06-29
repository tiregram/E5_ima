using System;
using System.Collections.Generic;
using Projet_IMA.Lights;
using System.Linq;
using System.Text;

namespace Projet_IMA.form
{
    public abstract class Object3D
    {


        private V3 position;
        private Texture texture;
        private Texture bumpMap;
        private Couleur couleur;


        protected Object3D(V3 p_position,
                        Texture p_texture,
                        Couleur p_couleur,
                        Texture p_bumpMap
                        )
        {
            this.couleur = p_couleur;
            this.texture = p_texture;
            this.bumpMap = p_bumpMap;
            this.position = p_position;
        }

        public void setCouleur(Couleur c) { this.couleur = c; }

        protected Object3D(V3 p_position,
                        Couleur p_couleur,
                        Texture p_bumpMap)
            :this(p_position,
                 null,
                 p_couleur,
                 p_bumpMap)
        {

        }

        protected Object3D(V3 p_position,
                       Texture p_texture,
                       Texture p_bumpMap)
           : this(p_position,
                p_texture,
                new Couleur(),
                p_bumpMap)
        {

        }

        public abstract Couleur drawPixel(V3 position);

        // DECALAGE 
        public void setPosition(V3 v)
        {
            this.position = v;
        }

        public V3 getPosition()
        {
            return this.position;
        }
        // TEXTURE
        public void setTexture(Texture ptexture)
        {
            this.texture = ptexture;
        }

        public Texture getTexture()
        {
            return this.texture;
        }

        // BUMP
        public void setBumpMap(Texture pbumpMap)
        {
            this.bumpMap = pbumpMap;
        }

        public Texture getBumpMap()
        {
            return this.bumpMap;
        }


        // color
        public Couleur getCouleur()
        {
            return this.couleur;
        }

        


        protected Couleur getColor(double u, double v)
        {
            if (this.getTexture() == null)
                return this.getCouleur();

            return this.getTexture().LireCouleur((float)u, (float)v);
        }

        protected void getBump(double u, double v, out float dhsdu, out float dhsdv)
        {
            if (this.getBumpMap() == null)
            {
                dhsdu = 0;
                dhsdv = 0;
                return;

            }
            this.getBumpMap().Bump((float)u, (float)v, out dhsdu, out dhsdv);
        }


        public abstract bool testColition(V3 positionStart, V3 direction, out double position);
    }
}
