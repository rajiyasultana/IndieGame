using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class CountDownController : MonoBehaviour
{
    public int countDownTime;
    public TextMeshProUGUI countDownText;
    public void BeginCountdown()
    {
        StartCoroutine(CountDownToStart());    
    }

    IEnumerator CountDownToStart()
    {
        while (countDownTime > 0)
        {
            yield return new WaitForSeconds(0.5f);
            countDownText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }

        countDownText.text = "GO";

        yield return new WaitForSeconds(1.1f);

        SceneManager.LoadScene(1);
    }



}
