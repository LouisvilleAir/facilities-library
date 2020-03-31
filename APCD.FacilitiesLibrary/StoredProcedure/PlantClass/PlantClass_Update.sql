USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_Update]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_Update
Author: Mike Farris
Date: 10/03/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_Update(
    @PlantClassID    int,
    @PlantClassName    varchar(50),
    @PlantClassDescription    varchar(255),
    @HansenAPDefnKey    int,
    @PlantClassIMSCode    varchar(20)
)

AS

BEGIN

    UPDATE PlantClass
    SET 
        PlantClassName = @PlantClassName,
        PlantClassDescription = @PlantClassDescription,
        HansenAPDefnKey = @HansenAPDefnKey,
        PlantClassIMSCode = @PlantClassIMSCode
    WHERE
        PlantClassID = @PlantClassID


END

RETURN

GO

