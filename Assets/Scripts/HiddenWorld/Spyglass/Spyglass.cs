using HiddenWorld.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Spyglass
{
    public class Spyglass : MonoBehaviour
    {
        //Environment
        public Material toggleMaterial;
        private Material[] originalMaterials;
        private bool spyglassToggled = false;
        private GameObject Environment;

        //Terrain
        private Terrain[] terrains;
        private Material[] originalTerrainMaterials;

        private HiddenWorldInputs _input;

        void Start()
        {
            _input = GetComponent<HiddenWorldInputs>();

            //saves the original object material to switch back to
            Environment = GameObject.Find("Environment");
            Renderer[] renderers = Environment.GetComponentsInChildren<Renderer>();
            originalMaterials = new Material[renderers.Length];
            for (int i = 0; i < renderers.Length; i++)
            {
                originalMaterials[i] = renderers[i].material;
            }

            //Terrain
            terrains = FindObjectsOfType<Terrain>();
            originalTerrainMaterials = new Material[terrains.Length];
            for (int i = 0; i < terrains.Length; i++)
            {
                originalTerrainMaterials[i] = terrains[i].materialTemplate;
            }
        }

        void Update()
        {
            if (_input.spyglass)
            {
                spyglassToggled = !spyglassToggled;
                Renderer[] renderers = Environment.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material = spyglassToggled ? toggleMaterial : originalMaterials[i];
                    Debug.Log("The Objects Changed Materials");
                }

                for (int i = 0; i < terrains.Length; i++)
                {
                    terrains[i].materialTemplate = spyglassToggled ? toggleMaterial : originalTerrainMaterials[i];
                }

                _input.spyglass = false;
            }
        }

        void OnDestroy()
        {
            Renderer[] renderers = Environment.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = originalMaterials[i];
            }

            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i].materialTemplate = originalTerrainMaterials[i];
            }
        }
    }
}
