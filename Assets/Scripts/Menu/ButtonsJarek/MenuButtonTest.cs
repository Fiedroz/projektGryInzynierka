using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtonTest : MonoBehaviour
{
    [SerializeField] GameObject designatedPanel;
    [SerializeField] MenuController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] GameObject currentPanel;
    [SerializeField] public int thisIndex;
    [SerializeField] bool isPlayButton = false;
    CameraController camControl;
    void Start()
    {
        camControl = Camera.main.GetComponent<CameraController>();
    }
    void Update()
    {
        detectChange();
    }
    public void DoAction()
    {
        if (designatedPanel != null)
        {
            designatedPanel.SetActive(true);
            camControl.SetFocusedPanel(designatedPanel);
            currentPanel.SetActive(false);
        }
        else if (isPlayButton)
        {
            SceneManager.LoadScene(1);
        }
    }
    private void detectChange()
    {
        if (menuButtonController.index == thisIndex)
        {
            EventSystem.current.SetSelectedGameObject(this.gameObject);
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }
}
