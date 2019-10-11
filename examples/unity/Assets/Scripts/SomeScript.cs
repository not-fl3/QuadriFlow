﻿using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
      
public class SomeScript : MonoBehaviour {
    [DllImport("libquadriflow", CallingConvention = CallingConvention.Cdecl)]
    private static extern float quadrangulate([MarshalAs(UnmanagedType.LPStr)] string in_obj_file, StringBuilder out_obj_file, int max_out_len);

    private void Start()
    {
        var obj = 
            @"g cube


v  0.0  0.0  0.0
v  0.0  0.0  1.0
v  0.0  1.0  0.0
v  0.0  1.0  1.0
v  1.0  0.0  0.0
v  1.0  0.0  1.0
v  1.0  1.0  0.0
v  1.0  1.0  1.0

vn  0.0  0.0  1.0
vn  0.0  0.0 - 1.0
vn  0.0  1.0  0.0
vn  0.0 - 1.0  0.0
vn  1.0  0.0  0.0
vn - 1.0  0.0  0.0


f  1//2  7//2  5//2
f  1//2  3//2  7//2 
f  1//6  4//6  3//6 
f  1//6  2//6  4//6 
f  3//3  8//3  7//3 
f  3//3  4//3  8//3 
f  5//5  7//5  8//5 
f  5//5  8//5  6//5 
f  1//4  5//4  6//4 
f  1//4  6//4  2//4 
f  2//1  6//1  8//1 
f  2//1  8//1  4//1 ";

        StringBuilder sb = new StringBuilder(10000);
        
        quadrangulate(obj, sb, sb.Capacity);
        Debug.Log(sb.ToString());
    }
}
