using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSceneNhayBaoBo : MonoBehaviour
{
    // public Animator animator;
    public GameComplete2 gameComplete2;
    public GameObject gameOverPanerl;
    public NhayBaoBoPoint nhayBaoBoPoint;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Box"))
        {
            FindObjectOfType<AudioManager>().Play("Vacham");
            // animator.SetBool("T",true);
            StartVibration();
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        gameComplete2.isSuccess = false;
        gameOverPanerl.SetActive(true);
        nhayBaoBoPoint.SetActiveOJController(false);
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
