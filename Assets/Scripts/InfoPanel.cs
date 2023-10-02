using Managers;
using UnityEngine;

public class InfoPanel : MonoBehaviour
{

    [SerializeField]
    private GameObject _info_panel;
    [SerializeField]
    private SoundManager _sound_manager;

    public void CloseInfoPanel()
    {
        _sound_manager.PlaySoundFx(0, 0.25f);
        _info_panel.SetActive(false);
    }
}
