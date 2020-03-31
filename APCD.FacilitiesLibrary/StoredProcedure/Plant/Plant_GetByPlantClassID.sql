USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPlantClassID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPlantClassID]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPlantClassID
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given PlantClassID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPlantClassID
(
    @PlantClassID    int
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
        PlantClassID = @PlantClassID

END

RETURN

GO

