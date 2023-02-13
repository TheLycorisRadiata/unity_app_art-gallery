using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiInteraction : MonoBehaviour
{
    public void FetchData(string uri)
    {
        StartCoroutine(GetRequest(uri));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] uriSplit = uri.Split('/');
            string uriLastPart = uriSplit[uriSplit.Length - 1];

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("[" + uriLastPart + "] Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("[" + uriLastPart + "] HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("[" + uriLastPart + "] Received: " + webRequest.downloadHandler.text);
                    // CustomClass object = JsonUtility.FromJson<CustomClass>(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}
