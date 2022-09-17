using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int targetScene;

    Animator animator;
    public static SceneTransition instance;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        if(instance == null)
        {
            instance = this;
        }
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(targetScene);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void LoadScene(int sceneIndex)
    {
        animator.SetTrigger("Load");
        targetScene = sceneIndex;
    }
    public void LoadScene(string sceneName)
    {
        animator.SetTrigger("Load");
        targetScene = SceneManager.GetSceneByName(sceneName).buildIndex;
    }
}
