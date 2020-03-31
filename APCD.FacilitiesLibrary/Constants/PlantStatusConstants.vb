'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantStatusConstants.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Constants class for the PlantStatus table of the Facilities database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Facilities.Constants

    <Serializable()> Public Class PlantStatusConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PlantStatusID As String = "PlantStatusID" 'primary key
            Public Const PlantStatusName As String = "PlantStatusName"
            Public Const PlantStatusDescription As String = "PlantStatusDescription"
            Public Const PlantStatusIMSCode As String = "PlantStatusIMSCode"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
