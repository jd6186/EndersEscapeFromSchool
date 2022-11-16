using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int materialLength = GetComponent<MeshRenderer>().materials.Length;
    }

}
