using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro; 
    public float delay = 2f; 
    public float fadeDuration = 2f; 

    private void Start()
    {
        StartCoroutine(FadeIn());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator FadeIn()
    {
        //Set the initial alpha to 0 (invisible)
        Color color = textMeshPro.color;
        color.a = 0;
        textMeshPro.color = color;
        
        yield return new WaitForSeconds(delay);

        // Fade in the text
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeDuration);
            textMeshPro.color = color;
            yield return null;
        }
        
        color.a = 1;
        textMeshPro.color = color;
    }
    
    
    public void Prowl()
    {
        SceneManager.LoadScene("Scenes/Gameplay");
    }
    
}
