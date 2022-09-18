using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriter : MonoBehaviour
{
    [SerializeField] float writingDelay = 0.1f;
    [SerializeField] float delDelay = 0.025f;
    public string text;
    string currentText;
    TextMeshProUGUI tmp;
    [SerializeField] GameObject nextText;
    [SerializeField] float transDelay;
    [SerializeField] bool deleteText = true;

    [SerializeField] AudioClip seslendirme;
    AudioSource source;
    // Start is called before the first frame update
    void Awake()
    {
        tmp = this.gameObject.GetComponent<TextMeshProUGUI>();
        source = this.gameObject.GetComponent<AudioSource>();
        if(source == null)
        {
            source = this.gameObject.AddComponent<AudioSource>();
        }
        source.clip = seslendirme;
        source.Play();
    }
    private void Start()
    {
        StartCoroutine(WriteText());
    }
    private void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            this.StopAllCoroutines();
            if (tmp.text != text)
            {
                tmp.text = text;
                StartCoroutine(NextText(transDelay));
            }
        }*/
    }
    IEnumerator WriteText()
    {
        print("Writing Text");
        for (int i = 0; i <= text.Length; i++)
        {
            currentText = text.Substring(0, i);
            tmp.text = currentText;
            if (text.Substring(i, 0) == " ")
            {
                print("Space Detected");

            }
            yield return new WaitForSecondsRealtime(writingDelay);
        }
        print("Done Writing Text");
        print("Starting To Delete Text");
        if(deleteText)
            StartCoroutine(DelText(transDelay));
        else
        {
            tmp.text = "";
            if (nextText != null)
            {
                nextText.SetActive(true);
            }
        }
    }

    IEnumerator DelText(float delay)
    {
        print("Deleting Text");
        yield return new WaitForSecondsRealtime(delay);
        for (int i = text.Length; i >= 0; i--)
        {
            currentText = text.Substring(0, i);
            tmp.text = currentText;
            yield return new WaitForSecondsRealtime(delDelay);
        }
        print("Done Deleting Text");
        StartCoroutine(NextText(delay));
    }

    IEnumerator NextText(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        print("Gettting Next Text");

        gameObject.SetActive(false);
        if (nextText != null)
        {
            nextText.SetActive(true);
        }
    }
}
