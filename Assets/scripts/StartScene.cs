using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{

    public List<Image> buttons;

    private int selectedButton = -1;

    void Start()
    {
        if (buttons.Count > 0)
        {
            updateSelector(0);
        }
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    // exit the game
    public void ExitGame()
    {
        Application.Quit();
    }

    private void updateSelector(int index)
    {
        Color selectedColor;
        if (selectedButton != -1)
        {
            selectedColor = buttons[selectedButton].color;
            buttons[selectedButton].color = new Color(selectedColor.r, selectedColor.g, selectedColor.b, 0.5f);
        }
        selectedButton = index;
        selectedColor = buttons[index].color;
        buttons[index].color = new Color(selectedColor.r, selectedColor.g, selectedColor.b, 1f);
    }

    void Update()
    {
        if (buttons.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (selectedButton < buttons.Count - 1)
                {
                    updateSelector(selectedButton + 1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (selectedButton > 0)
                {
                    updateSelector(selectedButton - 1);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                if (selectedButton == 0)
                {
                    StartGame();
                }
                else if (selectedButton == 1)
                {
                    ExitGame();
                }
            }
        }
    }
}
