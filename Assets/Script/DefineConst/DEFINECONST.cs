public static class OPERATIONTYPE
{
    public const int PLUS = 0;
    public const int MINUS = 1;
}


public static class BrightnessConstIndex
{
    public static readonly float BaseLight = 5.0f;
    public static readonly float ItemLight = 10.0f;
}

public static class HF_Constance
{
    public const float BOXMOVE = 1;
    public const float SWAMPTILE = 1;
    public const float TREETILE = 1;
    public const float MAPCHANGE = 1;
}

public static class SceneConstIndex
{
    public static readonly int MAINTITLE = 0;
    public static readonly int CHAPTER1 = 1;
    public static readonly int CHAPTER2 = 2;
    public static readonly int CHAPTER3 = 3;
    public static readonly int CHAPTER4 = 4;
    public static readonly int CHAPTER5 = 5;
    public static readonly int CHAPTERSAVE = 6;
    public static readonly int INTRO = 7;
}

public static class Constants
{
    public const short DR = 1;
    public const short DL = 2;
    public const short DU = 3;
    public const short DD = 4;
}

public static class RayConstants
{
    public const float objectRayLength = 0.3f;
    public const float talkRayLength = 0.5f;
}

public class SoundType
{
    public const int breakTree = 0;
    public const int switchOperation = 1;
    public const int itemPickUp = 0;
    public const int torchSound = 0;
    public const int collapseSound = 1;

    public const int oneBoxSound = 0;
    public const int twoBoxSound = 1;
    public const int threeBoxSound = 2;
    public const int fourBoxSound = 1;
    public const int fiveBoxSound = 1;

    public const int inventoryOpen = 1;
    public const int healSound = 2;
    public const int potalSound = 3;
    public const int sceneSound = 4;
    public const int damageSound = 5;
}

public enum Direction
{
    Right,
    Left,
    Up,
    Down
}

public enum TalkProperty
{
    Disposable,
    Reusable
}

public enum BoxSoundType
{
    Beach,
    Forest,
    Cave,
    Ruins,
    LastMap
}