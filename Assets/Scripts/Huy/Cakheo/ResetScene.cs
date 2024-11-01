using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public Animator animator;
    public GameComplete gameComplete;
    public GameObject gameOverPanerl;
    public PiontDiCaKheo piontDiCaKheo;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Box"))
        {
            animator.SetBool("T",true);
            StartVibration();
            StartCoroutine(Wait());

        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        gameComplete.isSuccess = false;
        gameOverPanerl.SetActive(true);
        piontDiCaKheo.SetActiveOJController(false);
    }

    public void StartVibration()
    {
        Handheld.Vibrate();
        StartCoroutine(VibrationCoroutine());
    }

    private IEnumerator VibrationCoroutine()
    {
        yield return new WaitForSeconds(0.02f);
    }

}
