// These are callbacks (delegates) that can be used by the messengers defined
// in EventHandler.cs.

public delegate void Callback(System.Object arg);

public enum EEventID 	{NONE = -1,
						EVENT_LEFT_MOUSE_CLICKED,
						EVENT_RIGHT_MOUSE_CLICKED,
						EVENT_MOUSE_SCROLL,
						EVENT_MOUSE_MOVED,
						EVENT_KEY_PRESSED,
						EVENT_ON_TURN_CHANGED,
						EVENT_CHANGE_TURN,
						EVENT_RESET_TURN_ORDER,
						EVENT_CENTER_CAMERA_ON_CHARACTER,
						EVENT_LEVEL_LOADED,
						EVENT_GET_PATH_LIST,
						EVENT_SET_START_TARGET,
						EVENT_SET_END_TARGET,
						EVENT_PLAYER_REDUCE_HEALTH,
						COUNT}