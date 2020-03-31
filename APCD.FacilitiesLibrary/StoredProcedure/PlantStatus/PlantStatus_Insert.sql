USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_Insert]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_Insert
Author: Mike Farris
Date: 10/03/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_Insert(
    @PlantStatusID    int,
    @PlantStatusName    varchar(50),
    @PlantStatusDescription    varchar(255),
    @PlantStatusIMSCode    varchar(10)
)

AS

BEGIN

    INSERT INTO PlantStatus
    (
        PlantStatusID,
        PlantStatusName,
        PlantStatusDescription,
        PlantStatusIMSCode
    )
    VALUES
    (
        @PlantStatusID,
        @PlantStatusName,
        @PlantStatusDescription,
        @PlantStatusIMSCode
    )


END

RETURN

GO

