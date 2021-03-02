using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
class Utility
{
    public static Vector3[] FloatArray2Vector3Array(float[] f)
    {
        int count = f.Length / 3;
        Vector3[] ret = new Vector3[count];
        GCHandle dest = GCHandle.Alloc(ret, GCHandleType.Pinned);
        Marshal.Copy(f, 0, dest.AddrOfPinnedObject(), f.Length);
        dest.Free();
        return ret;
    }
}
