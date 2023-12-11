using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScoreForCombat", menuName = "Score/ScoreForCombat")]
public class PlayerScoreForCombat : ScriptableObject
{
    public int ScoreMultiplier = 1;

    public int ScoreForBulletImpact;
    public int ScoreForHeadBulletImpact;
    public int ScoreForKill;
    public int ScoreForKillWithHeadshot;

    public int BulletImpactScore() => ScoreForBulletImpact * ScoreMultiplier;
    public int HeadBulletImpactScore() => ScoreForHeadBulletImpact * ScoreMultiplier;
    public int KillScore() => ScoreForKill * ScoreMultiplier;
    public int KillWithHeadshotScore() => ScoreForKillWithHeadshot * ScoreMultiplier;
}