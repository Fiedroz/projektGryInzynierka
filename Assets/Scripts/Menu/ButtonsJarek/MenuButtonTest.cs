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
    public bool isSelected = false;

    private NavigationControls navigationControls;
    void Start()
    {
        camControl = Camera.main.GetComponent<CameraController>();
        navigationControls = new NavigationControls();
        navigationControls.Enable();
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
            SceneManager.LoadScene(sceneName: "MainGame");
        }
    }
    private void detectChange()
    {
        if (menuButtonController.index == thisIndex)
        {
            this.isSelected = true;
            EventSystem.current.SetSelectedGameObject(this.gameObject);
            animator.SetBool("selected", true);
            if (navigationControls.Navigation.Confirm.triggered && navigationControls.Navigation.Confirm.ReadValue<float>() > 0)
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
            this.isSelected = false;
            animator.SetBool("selected", false);
        }
    }
}
