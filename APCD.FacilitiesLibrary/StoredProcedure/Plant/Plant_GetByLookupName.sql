USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByLookupName]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByLookupName
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByLookupName(
    @PlantName    varchar(100)
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
        PlantName = @PlantName

END

RETURN

GO

