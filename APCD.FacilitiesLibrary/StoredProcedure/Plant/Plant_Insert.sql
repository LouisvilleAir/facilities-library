USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_Insert]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_Insert
Author: Mike Farris
Date: 10/03/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_Insert(
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

    INSERT INTO Plant
    (
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
    )
    VALUES
    (
        @PlantID,
        @PlantName,
        @PlantDescription,
        @FacilitySiteEISID,
        @PlantStatusID,
        @BeginDate,
        @EndDate,
        @AddressID,
        @PlantClassID,
        @GovernmentFacilityTypeID,
        @NumberOfEmployees,
        @PlantArea,
        @IsReportedToEIS,
        @CommentPublic,
        @CommentInternal,
        @AddDate,
        @AddedBy
    )


END

RETURN

GO

