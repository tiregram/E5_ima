namespace Projet_IMA
{
    public class ZBuffer
    {
        public double[,] distanceZ;

        public ZBuffer(int px,int py)
        {
            this.distanceZ = new double[px,py];

            for (int vx = 0 ; vx < px; vx++ )
            {
                for (int vy = 0; vy < py; vy++)
                {
                    this.distanceZ[vx,vy] = double.MaxValue;
                }
            }       
        }

        public double this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0||
                    x >this.distanceZ.GetLength(0) || y > this.distanceZ.GetLength(1)
                    ) { return 0.0; }

                return this.distanceZ[x,y];
            }

            set
            {
                if (x < 0 || y < 0 ||
                    x > this.distanceZ.GetLength(0) || y > this.distanceZ.GetLength(1)) { return; }

                this.distanceZ[x,y] = value;
            }
        }



    }
}
