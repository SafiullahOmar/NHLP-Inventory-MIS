using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum MESSAGE_TYPE
{
    WARNING = 0,
    INFORMATION = 1,
    SUCCESS = 2,
    FAILURE = 3
}
public enum SCHOOL_TYPE
{
    NONE=0,
    GENERAL_EDUCATION=1,
    ISLAMIC_EDUCATION=2,
    TECHNICAL_EDUCATION=3,
    TEACHER_TRAINING=4,
    LITERACY=5,
    MANAGEMENT_OFFICES=6,
    QABL_AZ_MAKTAB=7
}
public enum SCHOOL_STAGE
{
    NONE=0,
    IBTEDAYA=1,
    MOTAWASITA=2,
    LESSA=3,
    TAKHNEEKAM_AALEE=5,
    TAKHNEEKAM_NEEMA_AALEE=6,
    QABL_AZ_MAKTAB=7,
    SEWADE_HAYATEE=80,
    DARUL_MAALEMEEN=90,
    DARUL_ULOOM=91,
    WAZARAT=99,
    REYASATE_WALAYATEE_MAARIF=100,
    MUDEERAT_HUZAA_TALEEMI=101,
    MUDEERAT_MAARIF_WOLASWALEE=102,
    MADRASSA_ISLAMI=103,
    DARUL_HIFAZ=104,
    RIYASAT_E_MARKAZEE=105,
    MUDEERAT_E_SEWADE_HAYATEE=106,
    MAKTAB_E_MARDAMEE=107,
    SHPAI_LESSA=108

}
/// <summary>
/// Summary description for AllEnum
/// </summary>
public class AllEnum
{
	public AllEnum()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}