using HiddenWorld.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Spyglass
{
    public class Spyglass : MonoBehaviour
    {
        //environment materials history and change
        public Material toggleMaterial;
        private Material[] originalMaterials;
        private bool isToggled = false;
        private GameObject EnvironmentPrefab;
        private HiddenWorldInputs _input;

        void Start()
        {
            _input = GetComponent<HiddenWorldInputs>();
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
            if (_input.spyglass)
            {
                isToggled = !isToggled;
                Renderer[] renderers = EnvironmentPrefab.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material = isToggled ? toggleMaterial : originalMaterials[i];
                }

                _input.spyglass = false;
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
}
