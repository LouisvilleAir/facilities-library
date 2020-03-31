'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantClassConstants.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Constants class for the PlantClass table of the Facilities database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Facilities.Constants

    <Serializable()> Public Class PlantClassConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PlantClassID As String = "PlantClassID" 'primary key
            Public Const PlantClassName As String = "PlantClassName"
            Public Const PlantClassDescription As String = "PlantClassDescription"
            Public Const HansenAPDefnKey As String = "HansenAPDefnKey"
            Public Const PlantClassIMSCode As String = "PlantClassIMSCode"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
