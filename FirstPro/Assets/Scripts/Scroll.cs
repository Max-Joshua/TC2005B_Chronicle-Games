using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

 [SerializeField] float scrollSpeed;

    private MeshRenderer mesh_Renderer;

    void Awake ()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        float x = Time.time * scrollSpeed;
        Vector2 offset = new Vector2 (x, 0);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
