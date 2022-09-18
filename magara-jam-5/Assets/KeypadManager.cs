using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    int counter;

    [SerializeField] Canvas canvas;
    [SerializeField] GameObject passLight;
    [SerializeField] List<TextMeshProUGUI> inputs = new List<TextMeshProUGUI>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Key(int value)
    {
        inputs[counter].text = value.ToString();
        counter++;
        if (counter >= inputs.Count)
        {
            StartCoroutine(Pass());
        }
    }
    IEnumerator Pass()
    {
        canvas.sortingOrder = -10;
        passLight.SetActive(true);
        yield return new WaitForSeconds(1f);
        passLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        passLight.SetActive(true);
        yield return new WaitForSeconds(1f);
        passLight.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneTransition.instance.LoadScene(8);
    }
}
