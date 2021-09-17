using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Text;

public class AltLeaderBoardController : MonoBehaviour
{
    public string baseURL
    {
        get { return "https://my-user-scoreboard.herokuapp.com/api/"; }
    }

    IEnumerator postDataRoutine()
    {
        Dictionary<string, string> PlayerParameters = new Dictionary<string, string>();

        PlayerParameters.Add("group_num", "3");
        PlayerParameters.Add("group_name", "MSS Games");
        PlayerParameters.Add("game_name", "Alchemical Breakout");
        //PlayerParameters.Add("number", "12345");

        string requestString = JsonConvert.SerializeObject(PlayerParameters);
        byte[] requestData = new UTF8Encoding().GetBytes(requestString);

        UnityWebRequest request = new UnityWebRequest(baseURL + "groups", "POST");
        //UnityWebRequest request = new UnityWebRequest(baseURL + "players", "POST");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(requestData);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        Debug.Log($"Response Code: {request.responseCode}");

        if(string.IsNullOrEmpty(request.error))
        {
            Debug.Log($"Message: {request.downloadHandler.text}");
        }
        else
        {
            Debug.LogError($"Error: {request.error}");
        }
    }

    public void createGroup()
    {
        StartCoroutine(postDataRoutine());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
