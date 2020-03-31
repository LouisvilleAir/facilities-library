USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_Insert]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_Insert
Author: Mike Farris
Date: 10/03/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_Insert(
    @PlantClassID    int,
    @PlantClassName    varchar(50),
    @PlantClassDescription    varchar(255),
    @HansenAPDefnKey    int,
    @PlantClassIMSCode    varchar(20)
)

AS

BEGIN

    INSERT INTO PlantClass
    (
        PlantClassID,
        PlantClassName,
        PlantClassDescription,
        HansenAPDefnKey,
        PlantClassIMSCode
    )
    VALUES
    (
        @PlantClassID,
        @PlantClassName,
        @PlantClassDescription,
        @HansenAPDefnKey,
        @PlantClassIMSCode
    )


END

RETURN

GO

