using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;

public class LeaderBoardController : MonoBehaviour
{
    public InputField MemberID;
    private int maxScoresToDisplay = 5;
    public Text[] entries;
    public Text[] entriesLevel2;
    public Text[] entriesLevel3;

    [Header("DO NOT EDIT")]
    private int ID = 403;
    private int ID2 = 416;
    private int ID3 = 417;

    [HideInInspector] public int timeInLevel;

    private void Start()
    {

        LootLockerSDKManager.StartSession("Player", (response) =>
        {
            if (response.success)
            {
                Debug.Log("success"); 
            }
            else
            {
                Debug.Log("failed");
            }

        });
    }

    public void showScores()
    {
        LootLockerSDKManager.GetScoreList(ID, maxScoresToDisplay, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for(int i = 0; i<scores.Length; i++)
                {
                    entries[i].text = (scores[i].rank + ". " + scores[i].member_id + "=" + scores[i].score);
                }
                
                if(scores.Length < maxScoresToDisplay)
                {
                    for(int i = scores.Length; i < maxScoresToDisplay; i++)
                    {
                        entries[i].text = (i + 1).ToString() + ".  none"; 
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void showScoresLevel2()
    {
        LootLockerSDKManager.GetScoreList(ID2, maxScoresToDisplay, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entriesLevel2[i].text = (scores[i].rank + ". " + scores[i].member_id + "=" + scores[i].score);
                }

                if (scores.Length < maxScoresToDisplay)
                {
                    for (int i = scores.Length; i < maxScoresToDisplay; i++)
                    {
                        entriesLevel2[i].text = (i + 1).ToString() + ".  none";
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void showScoresLevel3()
    {
        LootLockerSDKManager.GetScoreList(ID3, maxScoresToDisplay, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entriesLevel3[i].text = (scores[i].rank + ". " + scores[i].member_id + "=" + scores[i].score);
                }

                if (scores.Length < maxScoresToDisplay)
                {
                    for (int i = scores.Length; i < maxScoresToDisplay; i++)
                    {
                        entriesLevel3[i].text = (i + 1).ToString() + ".  none";
                    }
                }
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void submitScore()
    {
        timeInLevel = (int)TimeManager.Instance.measuredTime;

        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(timeInLevel.ToString()), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void submitScoreLevel2()
    {
        timeInLevel = (int)TimeManager.Instance.measuredTime;

        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(timeInLevel.ToString()), ID2, (response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }

    public void submitScoreLevel3()
    {
        timeInLevel = (int)TimeManager.Instance.measuredTime;

        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(timeInLevel.ToString()), ID3, (response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("failed");
            }
        });
    }
}
