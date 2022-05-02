//enum contining auido style types to better tracking of audio style
public enum AudioType
{
    Mode2D,
    Mode3D
}

//Enum containing Object types to make it easier to find what database to search in when loading objects from saving
public enum ObjectType
{
    Sound,
    Model,
    Effect
}

//gamestate enum making it easier for manipulation of states
public enum GameState
{
    Mainmenu,
    Application,
    AssetMenu,
    AssetSettings,
    UI,
}
