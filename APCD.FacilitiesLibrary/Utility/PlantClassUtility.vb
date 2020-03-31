'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantClassUtility.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Utility class for the PlantClass table of the Facilities database.
'             Provides shared methods for accesssing the database as well as other utility functions.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Business
Imports APCD.Facilities.Collections
Imports APCD.Facilities.Data

Namespace APCD.Facilities.Utility

    <Serializable()> Public Class PlantClassUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetLookupTable() As DataTable

            Dim objPlantClassDB As PlantClassDB
            objPlantClassDB = New PlantClassDB
            Return objPlantClassDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strPlantClassName As String) As PlantClass

            Dim objPlantClassDB As PlantClassDB
            objPlantClassDB = New PlantClassDB
            Return objPlantClassDB.GetByLookupName(strPlantClassName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPlantClassID As Int32) As PlantClass

            Dim objPlantClassDB As PlantClassDB
            objPlantClassDB = New PlantClassDB
            Return objPlantClassDB.GetByPrimaryKey(intPlantClassID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
