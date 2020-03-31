USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_GetLookupTable]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_GetLookupTable
Author: Mike Farris
Date: 10/03/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_GetLookupTable
AS

BEGIN

    SELECT 
        PlantStatusID,
        PlantStatusName
    FROM PlantStatus
    ORDER BY PlantStatusName

END

RETURN

GO

