using System.Collections.Generic;

namespace numsortAPI.Models
{
    public class MyArray
    {
        public int Id { get; set; }
        public double[] Data { get; set; }
    }

    public class MyArrays
    {
        public List<MyArray> MyArrayList { get; set; } 
    }
}
