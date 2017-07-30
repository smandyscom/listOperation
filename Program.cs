using System;
using System.Linq;
using System.Collections.Generic;
namespace listOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<float[]> __list = new List<float[]>(){ 
                new float[]{0,8,0},
                new float[]{4,5,6},
                new float[]{0.577F,0.577F,0.577F},
                new float[]{1,0,0}};

            //Turns to vector length for each vector
            List<float> __normTable =
                __list.Select(new Func<float[],float>(norm2)).ToList();
            
            //Accumulate all row vector in list into a integrated matrix
            float[][] matrix = __list.Aggregate(new float[][]{},
            (float[][] x,float[] y)=>{
                return  x.Append(y).ToArray();
            }).ToArray();

            //filter out those vector which's norm is equlas to 1
            List<float[]> __unityTable = __list.Where(x=>norm2(x)==1).ToList();

        }

        static float norm2(float[] vector)
        {
            return vector.Sum(x=>x*x);
        }
    }
}
