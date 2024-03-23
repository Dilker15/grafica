using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace televisorFinal
{
    public  class Television
    {
         private float[] vertices = {
             -0.5f,0.5f,0f,
             0.5f,0.5f,0f,			//parte superior de la tv
             0.5f,-0.5f,0f,
             -0.5f,-0.5f,0f,

             -0.3f,0.7f,0f,
             0.7f,0.7f,0f,			// parte trasera de la tv
             0.7f,-0.2f,0f,

             -0.2f,-0.5f,0f,
             0.2f,-0.5f,0f,			// parte inferior de la tv
             -0.2f,-0.6f,0f,
             0.2f,-0.6f,0f
         };
 


         private int[] indices = {
                 0,1, 1,2,  2,3 ,3,0,         //caja principal.
                 0,4, 4,5, 5,1, 5,6 , 6,2,        //caja trasera.
                 7,8,  8,10, 9,10,  7,9
         };

    





        public Television() { 
          
        }

        public float[] getVertices() {
            return vertices;
        }


        public int getFirst(int pos) {
            return this.indices[pos];
        }

        public int[] getIndices() {
            return this.indices;
        }

        public int cantidadVertices() {
            return this.vertices.Length;
        }


        public int cantidadIndices() {
            return this.indices.Length;
        }
    }
}
