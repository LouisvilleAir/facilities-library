USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_Update]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_Update
Author: Mike Farris
Date: 10/03/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_Update(
    @PlantID    int,
    @PlantName    varchar(100),
    @PlantDescription    varchar(2000),
    @FacilitySiteEISID    int = null,
    @PlantStatusID    int,
    @BeginDate    datetime = null,
    @EndDate    datetime = null,
    @AddressID    int = null,
    @PlantClassID    int,
    @GovernmentFacilityTypeID    int = null,
    @NumberOfEmployees    int = null,
    @PlantArea    real = null,
    @IsReportedToEIS    bit,
    @CommentPublic    varchar(255) = null,
    @CommentInternal    varchar(255) = null,
    @AddDate    datetime = null,
    @AddedBy    int = null
)

AS

BEGIN

    UPDATE Plant
    SET 
        PlantName = @PlantName,
        PlantDescription = @PlantDescription,
        FacilitySiteEISID = @FacilitySiteEISID,
        PlantStatusID = @PlantStatusID,
        BeginDate = @BeginDate,
        EndDate = @EndDate,
        AddressID = @AddressID,
        PlantClassID = @PlantClassID,
        GovernmentFacilityTypeID = @GovernmentFacilityTypeID,
        NumberOfEmployees = @NumberOfEmployees,
        PlantArea = @PlantArea,
        IsReportedToEIS = @IsReportedToEIS,
        CommentPublic = @CommentPublic,
        CommentInternal = @CommentInternal,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PlantID = @PlantID


END

RETURN

GO

