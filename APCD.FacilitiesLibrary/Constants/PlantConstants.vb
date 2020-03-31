'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantConstants.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Constants class for the Plant table of the Facilities database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Facilities.Constants

    <Serializable()> Public Class PlantConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PlantID As String = "PlantID" 'primary key
            Public Const PlantName As String = "PlantName"
            Public Const PlantDescription As String = "PlantDescription"
            Public Const FacilitySiteEISID As String = "FacilitySiteEISID"
            Public Const PlantStatusID As String = "PlantStatusID"
            Public Const BeginDate As String = "BeginDate"
            Public Const EndDate As String = "EndDate"
            Public Const AddressID As String = "AddressID"
            Public Const PlantClassID As String = "PlantClassID"
            Public Const GovernmentFacilityTypeID As String = "GovernmentFacilityTypeID"
            Public Const NumberOfEmployees As String = "NumberOfEmployees"
            Public Const PlantArea As String = "PlantArea"
            Public Const IsReportedToEIS As String = "IsReportedToEIS"
            Public Const CommentPublic As String = "CommentPublic"
            Public Const CommentInternal As String = "CommentInternal"
            Public Const AddDate As String = "AddDate"
            Public Const AddedBy As String = "AddedBy"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
