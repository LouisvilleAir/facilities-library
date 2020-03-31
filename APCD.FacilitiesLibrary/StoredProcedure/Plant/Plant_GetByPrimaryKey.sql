USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPrimaryKey]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPrimaryKey
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPrimaryKey(
    @PlantID    int
)

AS

BEGIN

    SELECT 
        PlantID,
        PlantName,
        PlantDescription,
        FacilitySiteEISID,
        PlantStatusID,
        BeginDate,
        EndDate,
        AddressID,
        PlantClassID,
        GovernmentFacilityTypeID,
        NumberOfEmployees,
        PlantArea,
        IsReportedToEIS,
        CommentPublic,
        CommentInternal,
        AddDate,
        AddedBy
    FROM Plant
    WHERE
        PlantID = @PlantID

END

RETURN

GO

