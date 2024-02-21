using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCutscene : MonoBehaviour
{
    public static bool isCutsceneOn;
    public Animator cameraAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isCutsceneOn = true;
            cameraAnimator.SetBool("Cutscene1", true);
            Invoke(nameof(StopCutscene), 3f);
        }
    }

    void StopCutscene()
    {
        isCutsceneOn = false;
        cameraAnimator.SetBool("Cutscene1", false);
        Destroy(gameObject);
    }
}
