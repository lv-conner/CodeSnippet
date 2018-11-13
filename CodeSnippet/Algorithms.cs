using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippet
{
    public class Algorithms
    {
        public static int[] SelectSort(bool asc,params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if(arr[i] < arr[j] ^ asc)
                    {
                        var temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
