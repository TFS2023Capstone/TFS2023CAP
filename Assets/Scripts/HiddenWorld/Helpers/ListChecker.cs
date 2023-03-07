using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListChecker : MonoBehaviour
{
    public List<int> list1;
    public List<int> list2;

    void Start()
    {
        bool equal = list1.SequenceEqual(list2);

        if (equal)
        {
            Debug.Log("The lists are equal.");
        }
        else
        {
            Debug.Log("The lists are not equal.");
        }
    }
}
