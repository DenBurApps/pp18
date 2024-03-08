using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualBall : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _lockPanel;
    [SerializeField] private GameObject _selectPanel;
    [SerializeField] private Button _selectButton;
    public Action ItemSelected;

    private void Awake()
    {
        _selectButton.onClick.AddListener(OnSelectButtonClick);
    }

    public void OnSelectButtonClick()
    {
        var ball = SaveSystem.LoadData<BallsSaveData>();
        ball.CurrentBall = _index;
        SaveSystem.SaveData(ball);
        ItemSelected?.Invoke();
    }

    public void LockItem()
    {
        _lockPanel.SetActive(true);
        _selectButton.interactable = false;
    }

    public void UnlockItem()
    {
        _lockPanel.SetActive(false);
        _selectButton.interactable = true;
    }

    public void SelectItem()
    {
        _selectPanel.SetActive(true);
    }

    public void UnselectItem()
    {
        _selectPanel.SetActive(false);
    }
}
