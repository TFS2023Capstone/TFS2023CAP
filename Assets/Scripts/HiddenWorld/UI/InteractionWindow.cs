using System;
using HiddenWorld.Systems;
using TMPro;
using UnityEngine;

namespace HiddenWorld.UI
{
    public class InteractionWindow : UIelement
    {
  //      [SerializeField]
  //      private TextMeshProUGUI levelText;
  //      [SerializeField]
  //      private TextMeshProUGUI attributePoints;
  //      private LevelSystem _LevelSystem;

  //      private void Awake()
  //      {
  //          SetLevelNumber(_LevelSystem.GetLevelNumber());
  //      }

  //      private	void SetLevelNumber (int levelNumber)
  //      {
  //          levelText.text = (levelNumber + 1).ToString();
  //      }

  //      private void OnEnable()
  //      {
  //          SetLevelNumber(_LevelSystem.GetLevelNumber());
  //          SetAtrributePoints(_LevelSystem.GetAttributePoints());
  //          _LevelSystem.OnAttributeSpent += _LevelSystem_OnAttributeSpent;
  //      }

  //      private void _LevelSystem_OnAttributeSpent(object sender, System.EventArgs e)
  //      {
  //          SetAtrributePoints(_LevelSystem.GetAttributePoints());
  //      }

  //      private void SetAtrributePoints (int attributePointsNumber)
  //      {
  //          attributePoints.text = $"Chose {attributePointsNumber} Attribute";
  //      }

		//private void OnDisable()
		//{
  //          _LevelSystem.OnAttributeSpent -= _LevelSystem_OnAttributeSpent;
  //      }
    }
}