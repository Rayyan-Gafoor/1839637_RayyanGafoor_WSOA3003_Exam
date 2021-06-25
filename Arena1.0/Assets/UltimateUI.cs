using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateUI : MonoBehaviour
{
    [SerializeField]
    private Image UltimateImage;
    [SerializeField]
    private Text Ready;

    private float UpdateSpeed = 0.5f;

    private float UltPer;
    private float healthNum;


    private void Awake()
    {

        UltPer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().ultimateCountdownPer;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        Ready.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UltPer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().ultimateCountdownPer;
        //Debug.Log(UltPer);
        HandleHealthChange(UltPer);
        if (UltPer == 1)
        {
            StartCoroutine(ReadyTextActive());
        }
        
       
    }
    void HandleHealthChange(float Percent)
    {
        //Percent = HealthBarPer;
        StartCoroutine(BarToPer(Percent));
    }
    private IEnumerator BarToPer(float PCT)
    {
        float preChangePct = UltimateImage.fillAmount;
        float Elapsed = 0f;
        while (Elapsed < UpdateSpeed)
        {
            Elapsed += Time.deltaTime;
            UltimateImage.fillAmount = Mathf.Lerp(preChangePct, PCT, Elapsed / UpdateSpeed);
            yield return null;

        }
        UltimateImage.fillAmount = PCT;
        //HealthImage.fillAmount = Mathf.Lerp(preChangePct, PCT, Elapsed / UpdateSpeed);
    }
    IEnumerator ReadyTextActive()
    {
        //yield return new WaitForSeconds(5);
        /// Debug.Log("ready");
        Ready.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        Ready.gameObject.SetActive(false);
    }

}
