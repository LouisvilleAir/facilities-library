USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_GetByLookupName]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_GetByLookupName
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_GetByLookupName(
    @PlantStatusName    varchar(50)
)

AS

BEGIN

    SELECT 
        PlantStatusID,
        PlantStatusName,
        PlantStatusDescription,
        PlantStatusIMSCode
    FROM PlantStatus
    WHERE
        PlantStatusName = @PlantStatusName

END

RETURN

GO

