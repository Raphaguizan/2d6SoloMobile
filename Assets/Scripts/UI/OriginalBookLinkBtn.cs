using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OriginalBookLinkBtn : MonoBehaviour
{
    [SerializeField]
    private string url = "https://newtonrocha.wordpress.com/2020/02/07/baixe-agora-o-sistema-2d6solo-regras-narrativistas-e-customizaveis-para-jogos-de-rpg-sem-mestre-e-ganhe-o-sistema-pocket-2d6world-versao-2-0-de-brinde-nitrogames/";

    public void OpenLink() 
    { 
        // Let's see that web page!
        Application.OpenURL(url);
    }
}
