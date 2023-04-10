using HiddenWorld.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiddenWorld.Spyglass
{
    public class EnemyOverlay : MonoBehaviour
    {
        public Material toggleMaterial;
        private Material[] originalMaterials;
        private bool spyglassToggled = false;
        private GameObject Enemy;

        private HiddenWorldInputs _input;

        // Start is called before the first frame update
        void Start()
        {
            _input = GetComponent<HiddenWorldInputs>();

            //saves the original object material to switch back to
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            Renderer[] renderers = Enemy.GetComponentsInChildren<Renderer>();
            originalMaterials = new Material[renderers.Length];
            for (int i = 0; i < renderers.Length; i++)
            {
                originalMaterials[i] = renderers[i].material;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_input.spyglass)
            {
                spyglassToggled = !spyglassToggled;
                Renderer[] renderers = Enemy.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material = spyglassToggled ? toggleMaterial : originalMaterials[i];
                    Debug.Log("The Enemy Changed Materials");
                }
            }
        }

        void OnDestroy()
        {
            Renderer[] renderers = Enemy.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material = originalMaterials[i];
            }
        }
    }
}

