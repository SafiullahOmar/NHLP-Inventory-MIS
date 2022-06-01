using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CLSReport
/// </summary>
public class CLSReport
{
    string year = "", condition = "";


    public CLSReport()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Year
    {
        get
        {
            return year;
        }
        set
        {
            year = value;
        }
    }
    public string Condition
    {
        get { return condition; }
        set { condition = value; }
    }
    #region Enrollment By Language
    public string EnByLang_Pashto_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 14 Female]
FROM         SMIS_EnrollmentByLanguage INNER JOIN
                      SMIS_School ON SMIS_EnrollmentByLanguage.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolDetails ON SMIS_SchoolDetails.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolStage ON SMIS_School.CurrentStageID = SMIS_SchoolStage.StageID INNER JOIN
                      SMIS_District ON SMIS_School.DistrictID = SMIS_District.DistrictID INNER JOIN
                      SMIS_Province ON SMIS_District.ProvinceID = SMIS_Province.ProvinceID AND SMIS_District.ProvinceID = SMIS_Province.ProvinceID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Dari_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 

                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")  and SMIS_School.isdeleted=0 and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Uzbaki_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Turkmany_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Balochi_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Nooristani_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Pashai_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                       
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Wakhani_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName
                   
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Pashto_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
dbo.SMIS_District.DistrictName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName
                       
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Dari_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                        dbo.SMIS_District.DistrictName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName, dbo.SMIS_EnrollmentByLanguage.GradeID,dbo.SMIS_District.DistrictName
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Uzbaki_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
dbo.SMIS_District.DistrictName,
                     SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Turkmany_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname
                       
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Balochi_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLangNooristani_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName, dbo.SMIS_District.Districtname
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Pashai_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                        dbo.SMIS_District.Districtname,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname
                       
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Wakhani_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and SMIS_School.isdeleted=0 and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName, dbo.SMIS_District.Districtname
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Pashto_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, SMIS_Province.ProvinceName,SMIS_Province.ProvinceEngName, SMIS_District.DistrictName,SMIS_School.SchoolID, SMIS_School.SchoolName, 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 1 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashto ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashto ELSE 0 END) AS [Grade 14 Female]
FROM         SMIS_EnrollmentByLanguage INNER JOIN
                      SMIS_School ON SMIS_EnrollmentByLanguage.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolDetails ON SMIS_SchoolDetails.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolStage ON SMIS_School.CurrentStageID = SMIS_SchoolStage.StageID INNER JOIN
                      SMIS_District ON SMIS_School.DistrictID = SMIS_District.DistrictID INNER JOIN
                      SMIS_Province ON SMIS_District.ProvinceID = SMIS_Province.ProvinceID AND SMIS_District.ProvinceID = SMIS_Province.ProvinceID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"   " + condition + @"
 GROUP BY SMIS_School.SchoolName, SMIS_School.SchoolID, SMIS_Province.ProvinceID, SMIS_Province.ProvinceName, SMIS_District.DistrictName,SMIS_Province.ProvinceEngName
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Dari_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                        dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleDari ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleDari ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @")  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName,
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Uzbaki_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleUzbaki ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleUzbaki ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Turkmany_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleTurkamani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleTurkamani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Balochi_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleBalochi ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleBalochi ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName
                       
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Nooristani_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleNooristani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleNooristani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName, dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName
                  
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Pashai_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                        dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MalePashai ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemalePashai ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName
                      
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByLang_Wakhani_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName, 
                    dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName,
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END)  AS [Grade 1 Male],  
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 1 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 2 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 2 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 3 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 4 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 5 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 6 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 7 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 8 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 9 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 10 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 11 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 12 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 13 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.MaleWakhani ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_EnrollmentByLanguage.gradeid = 14 THEN SMIS_EnrollmentByLanguage.FemaleWakhani ELSE 0 END) AS [Grade 14 Female]
FROM         dbo.SMIS_EnrollmentByLanguage INNER JOIN
                      dbo.SMIS_School ON dbo.SMIS_EnrollmentByLanguage.SchoolID = dbo.SMIS_School.SchoolID INNER JOIN
                      dbo.SMIS_District INNER JOIN
                      dbo.SMIS_Province ON dbo.SMIS_District.ProvinceID = dbo.SMIS_Province.ProvinceID ON dbo.SMIS_School.DistrictID = dbo.SMIS_District.DistrictID INNER JOIN
                      dbo.SMIS_SchoolStage ON dbo.SMIS_School.CurrentStageID = dbo.SMIS_SchoolStage.StageID INNER JOIN dbo.smis_SchoolDetails on dbo.smis_SchoolDetails.SchoolID=dbo.smis_School.SchoolID
WHERE     (dbo.SMIS_EnrollmentByLanguage.Year = " + year + @") and dbo.smis_SchoolDetails.year=" + year + @"  and dbo.SMIS_SchoolDetails.Year =" + year + @" " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName, dbo.SMIS_District.Districtname,dbo.SMIS_School.SchoolName
                     
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    #endregion

    #region Enrollment By Teaching Language
    public string EnByTeachinLang_ProLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName,
             
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 1 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 2 Female],
					  SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 14 Female]
FROM         SMIS_School INNER JOIN
                      SMIS_SchoolDetails ON SMIS_SchoolDetails.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolStage ON SMIS_School.CurrentStageID = SMIS_SchoolStage.StageID INNER JOIN
                      SMIS_District ON SMIS_School.DistrictID = SMIS_District.DistrictID INNER JOIN
                      SMIS_Province ON SMIS_District.ProvinceID = SMIS_Province.ProvinceID AND SMIS_District.ProvinceID = SMIS_Province.ProvinceID INNER JOIN
                      SMIS_Enrollment ON SMIS_School.SchoolID = SMIS_Enrollment.SchoolID
WHERE     (dbo.SMIS_Enrollment.Year = " + year + @") and SMIS_School.isdeleted=0 " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName 
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByTeachingLang_DisLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName,
             
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 1 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 2 Female],
					  SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 14 Female]
FROM         SMIS_School INNER JOIN
                      SMIS_SchoolDetails ON SMIS_SchoolDetails.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolStage ON SMIS_School.CurrentStageID = SMIS_SchoolStage.StageID INNER JOIN
                      SMIS_District ON SMIS_School.DistrictID = SMIS_District.DistrictID INNER JOIN
                      SMIS_Province ON SMIS_District.ProvinceID = SMIS_Province.ProvinceID AND SMIS_District.ProvinceID = SMIS_Province.ProvinceID INNER JOIN
                      SMIS_Enrollment ON SMIS_School.SchoolID = SMIS_Enrollment.SchoolID
WHERE     SMIS_School.isdeleted=0 and (dbo.SMIS_Enrollment.Year = " + year + @") " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    public string EnByTeachingLang_SchLevel
    {
        get
        {
            return @"Select Row_NUMBER() over (order by dbo.SMIS_Province.ProvinceID) as SrNo, dbo.SMIS_Province.ProvinceName,dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName,
             
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 1 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 1 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 1 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 2 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 2 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 2 Female],
					  SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 3 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 3 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 3 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 4 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 4 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 4 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 5 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 5 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 5 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 6 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 6 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 6 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 7 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 7 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 7 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 8 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 8 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 8 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 9 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 9 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 9 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 10 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 10 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 10 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 11 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 11 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 11 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 12 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 12 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 12 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 13 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 13 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 13 Female], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.MaleEnroll ELSE 0 END) AS [Grade 14 Male], 
                      SUM(CASE WHEN SMIS_Enrollment.gradeid = 14 THEN SMIS_Enrollment.FemaleEnroll ELSE 0 END) AS [Grade 14 Female]
FROM         SMIS_School INNER JOIN
                      SMIS_SchoolDetails ON SMIS_SchoolDetails.SchoolID = SMIS_School.SchoolID INNER JOIN
                      SMIS_SchoolStage ON SMIS_School.CurrentStageID = SMIS_SchoolStage.StageID INNER JOIN
                      SMIS_District ON SMIS_School.DistrictID = SMIS_District.DistrictID INNER JOIN
                      SMIS_Province ON SMIS_District.ProvinceID = SMIS_Province.ProvinceID AND SMIS_District.ProvinceID = SMIS_Province.ProvinceID INNER JOIN
                      SMIS_Enrollment ON SMIS_School.SchoolID = SMIS_Enrollment.SchoolID
WHERE     SMIS_School.isdeleted=0 and(dbo.SMIS_Enrollment.Year = " + year + @") " + condition + @"
GROUP BY dbo.SMIS_Province.ProvinceID, dbo.SMIS_Province.ProvinceName, dbo.SMIS_Province.ProvinceEngName,dbo.SMIS_District.DistrictName,dbo.SMIS_School.SchoolName
 ORDER BY dbo.SMIS_Province.ProvinceID";
        }
    }
    #endregion
}