'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantStatusUtility.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Utility class for the PlantStatus table of the Facilities database.
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

    <Serializable()> Public Class PlantStatusUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objPlantStatusDB As PlantStatusDB
            objPlantStatusDB = New PlantStatusDB
            Return objPlantStatusDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objPlantStatusDB As PlantStatusDB
            objPlantStatusDB = New PlantStatusDB
            Return objPlantStatusDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strPlantStatusName As String) As PlantStatus

            Dim objPlantStatusDB As PlantStatusDB
            objPlantStatusDB = New PlantStatusDB
            Return objPlantStatusDB.GetByLookupName(strPlantStatusName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPlantStatusID As Int32) As PlantStatus

            Dim objPlantStatusDB As PlantStatusDB
            objPlantStatusDB = New PlantStatusDB
            Return objPlantStatusDB.GetByPrimaryKey(intPlantStatusID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
