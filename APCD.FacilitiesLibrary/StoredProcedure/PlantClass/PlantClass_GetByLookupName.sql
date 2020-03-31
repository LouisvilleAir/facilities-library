USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_GetByLookupName]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_GetByLookupName
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_GetByLookupName(
    @PlantClassName    varchar(50)
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
        PlantClassName = @PlantClassName

END

RETURN

GO

