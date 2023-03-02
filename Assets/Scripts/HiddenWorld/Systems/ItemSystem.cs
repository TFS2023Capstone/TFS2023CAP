using System;
using System.Collections;
using UnityEngine;

namespace HiddenWorld.Systems
{
    public class ItemSystem : MonoBehaviour
    {
        public enum ItemType
        {
            none, Spyglass
        }
        public ItemType currentItem = ItemType.none;
        public string CurrentItemName
		{
			get
			{
                return Enum.GetName(typeof(ItemType), currentItem);
			}
		}

        public void ChangeWeapon(ItemType weaponTypeToChangeTo)
        {
            switch (weaponTypeToChangeTo)
            {
                case ItemType.none:
                    currentItem = ItemType.none;
                    break;
                case ItemType.Spyglass:
                    currentItem = ItemType.Spyglass;
                    break;
            }
        }
    }
}
