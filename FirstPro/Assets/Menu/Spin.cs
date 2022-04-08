using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    
    [SerializeField] float spinSpeed;

    private MeshRenderer mesh_Renderer;

    void Awake ()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        float x = Time.time * spinSpeed;
        Vector2 offset = new Vector2 (x,0);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        
    }
}
