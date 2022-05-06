using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_sDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, ps.main.duration );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
