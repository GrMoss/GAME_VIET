using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public Animator animator;

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
        Time.timeScale = 0;
        SceneManager.LoadScene("DiCaKheo");
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
