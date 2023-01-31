using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] BoxCollider2D spikeCollider;
    [SerializeField] SpriteRenderer spikeRenderer;

    public void SpikeOff()
    {
        spikeCollider.enabled = false;
        spikeRenderer.enabled = false;
    }

    public void SpikeOn()
    {
        spikeCollider.enabled = true;
        spikeRenderer.enabled = true;
    }
}
