using UnityEngine;
using System.Collections;

public class DontDestroy
{
    public float score;
	private static DontDestroy _s = null;
    public static DontDestroy S {
		get {
			if (_s == null)
				_s = new DontDestroy();
			return _s;
		}
	}

	private DontDestroy()
	{
		score = 0;
	}
}
