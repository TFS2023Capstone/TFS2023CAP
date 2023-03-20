using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyglass : MonoBehaviour
{
    //environment materials history and change
    public Material toggleMaterial;
    private Material[] originalMaterials;
    private bool isToggled = false;
    private GameObject EnvironmentPrefab;

   

    void Start()
    {
        //saves the original material to switch back to
        EnvironmentPrefab = GameObject.Find("Environment");
        Renderer[] renderers = EnvironmentPrefab.GetComponentsInChildren<Renderer>();
        originalMaterials = new Material[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalMaterials[i] = renderers[i].material;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            isToggled = !isToggled;
            Renderer[] renderers = EnvironmentPrefab.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = isToggled ? toggleMaterial : originalMaterials[i];
            }
        }
    }

    void OnDestroy()
    {
        Renderer[] renderers = EnvironmentPrefab.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = originalMaterials[i];
        }
    }
}