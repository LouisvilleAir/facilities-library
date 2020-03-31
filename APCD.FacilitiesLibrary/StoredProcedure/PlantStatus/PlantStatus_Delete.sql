USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_Delete]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_Delete
Author: Mike Farris
Date: 10/03/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_Delete(
    @PlantStatusID    int
)

AS

BEGIN

    DELETE FROM PlantStatus
    WHERE
        PlantStatusID = @PlantStatusID

END

RETURN

GO

