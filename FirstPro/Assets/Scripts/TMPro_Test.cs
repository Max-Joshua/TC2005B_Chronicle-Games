/*
Fill a list of TMP fields with the names obtained from an API
To make the ScrollView content adjust to the contents, use this:
https://unitycoder.com/blog/2016/02/23/ui-scroll-view-automatic-content-height/
Gilberto Echeverria
*/

using UnityEngine;
using TMPro;

public class TMPro_Test : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI field;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform contentTransform;

    public void LoadScores(TopHighScoreList allTopHighScores)
    {
        Debug.Log("Trying to load scores");
        for (int i=0; i<allTopHighScores.top_high_scores.Count; i++) {
            Debug.Log("PRINTING RESULTS SCORE");
            // Create new text objects
            GameObject textTMP = Instantiate(textPrefab);

            // Add them to the ScollView content
            textTMP.transform.SetParent(contentTransform);

            // Set the position of each element
            textTMP.GetComponent<RectTransform>().anchoredPosition =
                new Vector2 (0, 1 * i);

            // Extract the text from the argument object
            DBTopHighScores topHS = allTopHighScores.top_high_scores[i];
            TextMeshProUGUI field = textTMP.GetComponent<TextMeshProUGUI>();
            field.text = "---------------------------\n" + "User: " + topHS.name + " Total Score: " + 
                        topHS.total_score + " Age: " + topHS.age +
                        " Accuracy: " + topHS.accuracy + "Game Time: " + topHS.game_time;
            //Debug.Log("ID: " + us.id_users + " | " + us.name + " " + us.surname);
        }
    }
}