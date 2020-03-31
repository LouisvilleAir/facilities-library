USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_Update]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_Update
Author: Mike Farris
Date: 10/03/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_Update(
    @PlantStatusID    int,
    @PlantStatusName    varchar(50),
    @PlantStatusDescription    varchar(255),
    @PlantStatusIMSCode    varchar(10)
)

AS

BEGIN

    UPDATE PlantStatus
    SET 
        PlantStatusName = @PlantStatusName,
        PlantStatusDescription = @PlantStatusDescription,
        PlantStatusIMSCode = @PlantStatusIMSCode
    WHERE
        PlantStatusID = @PlantStatusID


END

RETURN

GO

