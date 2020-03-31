'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantUtility.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Utility class for the Plant table of the Facilities database.
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

    <Serializable()> Public Class PlantUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetLookupTable() As DataTable

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strPlantName As String) As Plant

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByLookupName(strPlantName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPlantID As Int32) As Plant

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByPrimaryKey(intPlantID)

        End Function

        Public Shared Function GetByPlantClassID(ByVal intPlantClassID As Int32) As DataTable

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByPlantClassID(intPlantClassID)

        End Function

        Public Shared Function GetByPlantClassID_Collection(ByVal intPlantClassID As Int32) As Plants

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByPlantClassID_Collection(intPlantClassID)

        End Function

        Public Shared Function GetByPlantStatusID(ByVal intPlantStatusID As Int32) As DataTable

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByPlantStatusID(intPlantStatusID)

        End Function

        Public Shared Function GetByPlantStatusID_Collection(ByVal intPlantStatusID As Int32) As Plants

            Dim objPlantDB As PlantDB
            objPlantDB = New PlantDB
            Return objPlantDB.GetByPlantStatusID_Collection(intPlantStatusID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
