using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonException
/// </summary>
public class OCM_CommonException
{
    public OCM_CommonException()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static Exception LastException
    {
        get
        {
            return _LastException;
        }
        set
        {
            if (value != _LastException)
            {
                _LastException = value;
            }
        }
    }

    private static Exception _LastException;

}