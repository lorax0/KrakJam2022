using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particle;

    public void SetEmision(int value)
    {
        var emission = particle.emission;
        emission.rateOverTime = value;
    }
}