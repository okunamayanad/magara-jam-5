using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCam : MonoBehaviour
{
    [SerializeField] GameObject pickedObject;
    [SerializeField] Vector2 objectDefaultPos;

    int currentCompletedCount;
    [SerializeField] int totalPuzzleCount;
    [SerializeField] GameObject puzzleBitis;
    [SerializeField] GameObject tehditText;

    [SerializeField] GameObject currentMasa;
    [SerializeField] GameObject masaPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity,LayerMask.GetMask("PuzzlePiece"));
            if (hit)
            {
                pickedObject = hit.collider.gameObject;
                objectDefaultPos = pickedObject.transform.position;
            }
        }
        if (Input.GetMouseButton(0))
        {
            if(pickedObject != null)
            {
                pickedObject.transform.position = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (pickedObject != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity, LayerMask.GetMask("PuzzleTarget"));
                if (hit)
                {
                    if(hit.collider.gameObject.GetComponent<PuzzlePiece>().truePiece == pickedObject.GetComponent<SpriteRenderer>().sprite)
                    {
                        pickedObject.transform.localPosition = hit.collider.gameObject.GetComponent<PuzzlePiece>().targetPos;
                        Destroy(hit.collider.gameObject.GetComponent<BoxCollider2D>());
                        hit.collider.gameObject.layer = LayerMask.NameToLayer("Default");
                        Destroy(pickedObject.GetComponent<BoxCollider2D>());
                        hit.collider.gameObject.layer = LayerMask.NameToLayer("Default");
                        currentCompletedCount++;
                        if(currentCompletedCount == totalPuzzleCount)
                        {
                            tehditText.SetActive(true);
                            StartCoroutine(puzzlebitis());
                        }
                    }
                    else
                    {

                        pickedObject.transform.position = objectDefaultPos;
                        objectDefaultPos = Vector2.zero;
                        pickedObject = null;
                    }
                }
                else
                {
                    pickedObject.transform.position = objectDefaultPos;
                    objectDefaultPos = Vector2.zero;
                    pickedObject = null;
                }
            }
        }
    }
    public void Sifirla()
    {
        Destroy(currentMasa.gameObject);
        currentMasa = Instantiate(masaPrefab, transform.parent);
    }
    IEnumerator puzzlebitis()
    {
        yield return new WaitForSecondsRealtime(4);
        puzzleBitis.SetActive(true);
    }
}
