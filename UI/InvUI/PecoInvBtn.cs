using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PecoInvBtn : MonoBehaviour
{
    public GameObject[] effects = new GameObject[6];

    private GameObject myEffect;
    
    private Button btn;

    private InvPanelManager _panelManager;
    private InvDescriptor _descriptor;
    
    private void Awake()
    {
        btn = GetComponent<Button>();
        myEffect = transform.GetChild(0).gameObject;

        _panelManager = FindObjectOfType<InvPanelManager>(true);
        _descriptor = GetComponent<InvDescriptor>();
        
        btn.onClick.AddListener((() =>
        {

            for (int i = 0; i < 6; i++)
            {
                effects[i].SetActive(false);
            }
            
            myEffect.SetActive(true);
            
            
            // 정보 체인지
            _panelManager.title.GetComponent<TextMeshProUGUI>().text = _descriptor.title;
            _panelManager.desc1.GetComponent<TextMeshProUGUI>().text = _descriptor.value1;
            _panelManager.desc2.GetComponent<TextMeshProUGUI>().text = _descriptor.value2;
            _panelManager.val1.GetComponent<TextMeshProUGUI>().text = _descriptor.desc1;
            _panelManager.val2.GetComponent<TextMeshProUGUI>().text = _descriptor.desc2;
            _panelManager.portrait.GetComponent<Image>().sprite = _descriptor.sprite;
        }));
    }
}
