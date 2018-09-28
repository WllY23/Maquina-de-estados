using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public GameObject Cube;
    public float limite;
    public Vector3 puntosalida;
    void Update()
    {
        if (Cube.transform.position.y < limite)
        {
            Cube.transform.position = puntosalida;
        }
    }
}
