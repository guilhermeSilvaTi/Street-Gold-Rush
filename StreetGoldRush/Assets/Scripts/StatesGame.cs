using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesGame : MonoBehaviour
{
    private static bool activeGame;
    private static int coin;

    private static float velocity = 10;
    private static float timeRespawn = 2.5f;
    private static int level = 1;

    private static float volumeMusic = 0.5f;
    private static float volumeFX = 0.5f;
    private static EnumHability hability;

    public static void ResetGame()
    {
        activeGame = true;
        coin = 0;
        velocity = 10;
        timeRespawn = 2.5f;
        level = 1;
    }
    public static EnumHability GetHability() { return hability; }
    public static void SetHability(EnumHability value) { hability = value; }
    public static int GetLevel() { return level; }
    public static void SetLevel(int value) { level = value; }
    public static float GetVolumeMusic() { return volumeMusic; }
    public static void SetVolumeMusic(float value) { volumeMusic = value; }
    public static float GetVolumeFX() { return volumeFX; }
    public static void SetVolumeFX(float value) { volumeFX = value; }
    public static float GetTimeRespwan() { return timeRespawn; }
    public static void SetTimeRespawn(float value) { timeRespawn = value; }
    public static float GetVelocity() { return velocity; }
    public static void SetVelocity(float value) { velocity += value; }
    public static void SetActiveGame(bool value) { activeGame = value; }
    public static bool GetActiveGame() { return activeGame; }
    public static void SetCoin(int value) { coin += value; }
    public static int GetCoin() { return coin; }
}
