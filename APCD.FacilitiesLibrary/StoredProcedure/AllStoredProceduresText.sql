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

    INSERT INTOPlant
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

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_Update]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_Update
Author: Mike Farris
Date: 10/03/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_Update(
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

    UPDATE Plant
    SET 
        PlantName = @PlantName,
        PlantDescription = @PlantDescription,
        FacilitySiteEISID = @FacilitySiteEISID,
        PlantStatusID = @PlantStatusID,
        BeginDate = @BeginDate,
        EndDate = @EndDate,
        AddressID = @AddressID,
        PlantClassID = @PlantClassID,
        GovernmentFacilityTypeID = @GovernmentFacilityTypeID,
        NumberOfEmployees = @NumberOfEmployees,
        PlantArea = @PlantArea,
        IsReportedToEIS = @IsReportedToEIS,
        CommentPublic = @CommentPublic,
        CommentInternal = @CommentInternal,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PlantID = @PlantID


END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_Delete]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_Delete
Author: Mike Farris
Date: 10/03/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_Delete(
    @PlantID    int
)

AS

BEGIN

    DELETE FROMPlant
    WHERE
        PlantID = @PlantID

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPrimaryKey]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPrimaryKey
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPrimaryKey(
    @PlantID    int
)

AS

BEGIN

    SELECT 
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
    FROM Plant
    WHERE
        PlantID = @PlantID

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetAll]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetAll
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetAll
AS

BEGIN

    SELECT 
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
    FROM Plant

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetLookupTable]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetLookupTable
Author: Mike Farris
Date: 10/03/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetLookupTable
AS

BEGIN

    SELECT 
        PlantID,
        PlantName
    FROM Plant
    ORDER BY PlantName

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByLookupName]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByLookupName
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByLookupName(
    @PlantName    varchar(100)
)

AS

BEGIN

    SELECT 
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
    FROM Plant
    WHERE
        PlantName = @PlantName

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPlantClassID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPlantClassID]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPlantClassID
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given PlantClassID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPlantClassID
(
    @PlantClassID    int
)

AS

BEGIN

    SELECT 
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
    FROM Plant
    WHERE
        PlantClassID = @PlantClassID

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Plant_GetByPlantStatusID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Plant_GetByPlantStatusID]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: Plant_GetByPlantStatusID
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given PlantStatusID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Plant_GetByPlantStatusID
(
    @PlantStatusID    int
)

AS

BEGIN

    SELECT 
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
    FROM Plant
    WHERE
        PlantStatusID = @PlantStatusID

END

RETURN

GO

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

    INSERT INTOPlantClass
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

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_Delete]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_Delete
Author: Mike Farris
Date: 10/03/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_Delete(
    @PlantClassID    int
)

AS

BEGIN

    DELETE FROMPlantClass
    WHERE
        PlantClassID = @PlantClassID

END

RETURN

GO

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

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_GetAll]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_GetAll
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_GetAll
AS

BEGIN

    SELECT 
        PlantClassID,
        PlantClassName,
        PlantClassDescription,
        HansenAPDefnKey,
        PlantClassIMSCode
    FROM PlantClass

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantClass_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantClass_GetLookupTable]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantClass_GetLookupTable
Author: Mike Farris
Date: 10/03/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantClass_GetLookupTable
AS

BEGIN

    SELECT 
        PlantClassID,
        PlantClassName
    FROM PlantClass
    ORDER BY PlantClassName

END

RETURN

GO

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

    INSERT INTOPlantStatus
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

    DELETE FROMPlantStatus
    WHERE
        PlantStatusID = @PlantStatusID

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_GetByPrimaryKey]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_GetByPrimaryKey
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_GetByPrimaryKey(
    @PlantStatusID    int
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
        PlantStatusID = @PlantStatusID

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PlantStatus_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PlantStatus_GetAll]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: PlantStatus_GetAll
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PlantStatus_GetAll
AS

BEGIN

    SELECT 
        PlantStatusID,
        PlantStatusName,
        PlantStatusDescription,
        PlantStatusIMSCode
    FROM PlantStatus

END

RETURN

GO

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

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Insert]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_Insert
Author: Mike Farris
Date: 10/03/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Insert(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int OUTPUT,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    INSERT INTOsysdiagrams
    (
        name,
        principal_id,
        version,
        definition
    )
    VALUES
    (
        @name,
        @principal_id,
        @version,
        @definition
    )


END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Update]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_Update
Author: Mike Farris
Date: 10/03/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Update(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    UPDATE sysdiagrams
    SET 
        principal_id = @principal_id,
        diagram_id = @diagram_id,
        version = @version,
        definition = @definition
    WHERE
        name = @name


END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Delete]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_Delete
Author: Mike Farris
Date: 10/03/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Delete(
    @name    nvarchar(256)
)

AS

BEGIN

    DELETE FROMsysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByPrimaryKey]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_GetByPrimaryKey
Author: Mike Farris
Date: 10/03/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByPrimaryKey(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetAll]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_GetAll
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetAll
AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id_name]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id_name]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_GetByprincipal_id_name
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given (principal_id, name) passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id_name
(
    @principal_id    int,
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id
        AND name = @name
END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_GetByprincipal_id
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given principal_id passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id
(
    @principal_id    int
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id

END

RETURN

GO

USE Facilities

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByname]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByname]

GO

USE Facilities

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Facilities
Procedure Name: sysdiagrams_GetByname
Author: Mike Farris
Date: 10/03/2011
Description:  Returns all of the records for the given name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByname
(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

