USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_GetByPrimaryKey]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_GetByPrimaryKey
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_GetByPrimaryKey(
    @PlantClassID    int
)

AS

BEGIN

    SELECT 
        PlantClassID,
        PlantClassName,
        PlantClassDescription,
        HansenAPDefnKey,
        PlantClassIMSCode
    FROM PlantClass
    WHERE
        PlantClassID = @PlantClassID

END

RETURN

GO

