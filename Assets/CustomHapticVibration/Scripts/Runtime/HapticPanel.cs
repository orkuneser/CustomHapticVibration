using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HapticPanel : MonoBehaviour
{
    [SerializeField] private GameObject _hapticPanel;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _openButton;
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _hapticButton;

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OpenHapticPanel);
        _closeButton.onClick.AddListener(CloseHapticPanel);
        _hapticButton.onClick.AddListener(OnClickHaptic);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OpenHapticPanel);
        _closeButton.onClick.RemoveListener(CloseHapticPanel);
        _hapticButton.onClick.RemoveListener(OnClickHaptic);
    }

    private void OnClickHaptic()
    {
        if (_inputField.text == "")
            return;

        long value = long.Parse(_inputField.text);
        CustomVibration.Vibrate(value);
    }

    private void OpenHapticPanel()
    {
        _hapticPanel.SetActive(true);
        _hapticPanel.transform.localScale = Vector3.zero;
        _hapticPanel.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.Linear);
    }

    private void CloseHapticPanel()
    {
        _hapticPanel.transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.Linear).OnComplete(() =>
        {
            _hapticPanel.SetActive(false);
        });
    }
}
