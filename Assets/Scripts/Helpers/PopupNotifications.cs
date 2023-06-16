using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupNotifications : MonoBehaviour
{
    public TMP_Text popupText;

    private Animator popupAnimator;
    private Queue<string> popupQueue;
    private Coroutine queueChecker;

    private void Start()
    {
        popupAnimator = GetComponent<Animator>();
        popupQueue = new Queue<string>();

        AddToQueue("Completed Objective");
        AddToQueue("JK");
        AddToQueue("HaHa");
    }

    public void AddToQueue(string text)
    {
        popupQueue.Enqueue(text);
        if (queueChecker == null)
            queueChecker = StartCoroutine(CheckQueue());
    }

    private void ShowPopup(string text)
    {
        popupText.text = text;
        popupAnimator.Play("PopupAnimation");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupQueue.Dequeue());
            do
            {
                yield return null;
            } while (!popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));

        } while (popupQueue.Count > 0);
        queueChecker = null;
    }
}
