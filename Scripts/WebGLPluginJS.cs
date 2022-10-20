using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class WebGLPluginJS : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern void GameFinished();

}