USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPlantStatusID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPlantStatusID]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPlantStatusID
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given PlantStatusID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPlantStatusID
(
    @PlantStatusID    int
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
        PlantStatusID = @PlantStatusID

END

RETURN

GO

