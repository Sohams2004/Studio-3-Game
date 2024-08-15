using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDissolve : MonoBehaviour
{
    [SerializeField] Material dissolveMaterial;
    [SerializeField] float dissolveSpeed;
    [SerializeField] float dissolveThreshold;

    void Dissovle()
    {
        dissolveThreshold += Time.deltaTime * dissolveSpeed;
        dissolveMaterial.SetFloat("_DissolveThreshold", dissolveThreshold);
    }

    private void Update()
    {
        Dissovle();
    }
}
