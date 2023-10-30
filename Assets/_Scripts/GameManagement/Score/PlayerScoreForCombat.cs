using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScoreForCombat", menuName = "Score/ScoreForCombat")]
public class PlayerScoreForCombat : ScriptableObject
{
    public int ScoreMultiplier = 1;

    public int BulletImpactBaseScore;
    public int HeadBulletImpactBaseScore;
    public int KillBaseScore;
    public int KillWithHeadshotBaseScore;

    public int BulletImpactScore() => BulletImpactBaseScore * ScoreMultiplier;
    public int HeadBulletImpactScore() => HeadBulletImpactBaseScore * ScoreMultiplier;
    public int KillScore() => KillBaseScore * ScoreMultiplier;
    public int KillWithHeadshotScore() => KillWithHeadshotBaseScore * ScoreMultiplier;
}