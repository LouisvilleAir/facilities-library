'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantStatusDB.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Data access class for the PlantStatus table of the Facilities database.
'             Provides Insert, Update, Delete, and Select operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports System.Data.OleDb
Imports Tools.Data
Imports APCD.Facilities.Business
Imports APCD.Facilities.Collections
Imports APCD.Facilities.Constants
Imports APCD.Facilities.Globals

Namespace APCD.Facilities.Data

    <Serializable()> Friend Class PlantStatusDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared PlantStatusID As Int32 'primary key
            Public Shared PlantStatusName As Int32
            Public Shared PlantStatusDescription As Int32
            Public Shared PlantStatusIMSCode As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "PlantStatus_Insert"
            Public Const Update As String = "PlantStatus_Update"
            Public Const Delete As String = "PlantStatus_Delete"
            Public Const GetByPrimaryKey As String = "PlantStatus_GetByPrimaryKey"
            Public Const GetAll As String = "PlantStatus_GetAll"
            Public Const GetLookupTable As String = "PlantStatus_GetLookupTable"
            Public Const GetByLookupName As String = "PlantStatus_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPlantStatusID As OleDbParameter 'primary key
        Private m_prmstrPlantStatusName As OleDbParameter
        Private m_prmstrPlantStatusDescription As OleDbParameter
        Private m_prmstrPlantStatusIMSCode As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PlantStatusID As String = "@PlantStatusID"
            Public Const PlantStatusName As String = "@PlantStatusName"
            Public Const PlantStatusDescription As String = "@PlantStatusDescription"
            Public Const PlantStatusIMSCode As String = "@PlantStatusIMSCode"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPlantStatus As PlantStatus) As Int32

            Return Me.DMLHelper(objPlantStatus, DMLType.Insert)

        End Function

        Friend Function Update(ByVal objPlantStatus As PlantStatus) As Int32

            Return Me.DMLHelper(objPlantStatus, DMLType.Update)

        End Function

        Friend Function Delete(ByVal objPlantStatus As PlantStatus) As Int32

            Return Me.DMLHelper(objPlantStatus, DMLType.Delete)

        End Function

        Private Function DMLHelper(ByVal objPlantStatus As PlantStatus, ByVal iDMLType As DMLType) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPlantStatus, iDMLType)
                commandParameters = .GetParameterArray(iDMLType)
                Select Case iDMLType
                    Case DMLType.Insert
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Insert, commandParameters)
                    Case DMLType.Update
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Update, commandParameters)
                    Case DMLType.Delete
                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Delete, commandParameters)
                End Select
            End With

            Return intReturnValue

        End Function

#End Region '----- DML -----

#Region "----- Helper Methods -----"

        Private Sub InitializeParameterObjects()

            Me.m_prmintPlantStatusID = Nothing
            Me.m_prmintPlantStatusID = New OleDbParameter

            Me.m_prmstrPlantStatusName = Nothing
            Me.m_prmstrPlantStatusName = New OleDbParameter

            Me.m_prmstrPlantStatusDescription = Nothing
            Me.m_prmstrPlantStatusDescription = New OleDbParameter

            Me.m_prmstrPlantStatusIMSCode = Nothing
            Me.m_prmstrPlantStatusIMSCode = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPlantStatus As PlantStatus, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPlantStatusID
                            .ParameterName = ParameterName.PlantStatusID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantStatus.PlantStatusID
                        End With

                        With .m_prmstrPlantStatusName
                            .ParameterName = ParameterName.PlantStatusName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusName
                        End With

                        With .m_prmstrPlantStatusDescription
                            .ParameterName = ParameterName.PlantStatusDescription
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusDescription
                        End With

                        With .m_prmstrPlantStatusIMSCode
                            .ParameterName = ParameterName.PlantStatusIMSCode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusIMSCode
                        End With

                    Case DMLType.Update

                        With .m_prmintPlantStatusID
                            .ParameterName = "@PlantStatusID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantStatus.PlantStatusID
                        End With

                        With .m_prmstrPlantStatusName
                            .ParameterName = "@PlantStatusName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusName
                        End With

                        With .m_prmstrPlantStatusDescription
                            .ParameterName = "@PlantStatusDescription"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusDescription
                        End With

                        With .m_prmstrPlantStatusIMSCode
                            .ParameterName = "@PlantStatusIMSCode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantStatus.PlantStatusIMSCode
                        End With

                    Case DMLType.Delete

                        With .m_prmintPlantStatusID
                            .ParameterName = "@PlantStatusID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantStatus.PlantStatusID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(3) {}
                    commandParameters(0) = Me.m_prmintPlantStatusID
                    commandParameters(1) = Me.m_prmstrPlantStatusName
                    commandParameters(2) = Me.m_prmstrPlantStatusDescription
                    commandParameters(3) = Me.m_prmstrPlantStatusIMSCode
                Case DMLType.Update
                    commandParameters = New OleDbParameter(3) {}
                    commandParameters(0) = Me.m_prmintPlantStatusID
                    commandParameters(1) = Me.m_prmstrPlantStatusName
                    commandParameters(2) = Me.m_prmstrPlantStatusDescription
                    commandParameters(3) = Me.m_prmstrPlantStatusIMSCode
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintPlantStatusID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PlantStatusID = dr.GetOrdinal(PlantStatusConstants.FieldName.PlantStatusID)
            FieldOrdinal.PlantStatusName = dr.GetOrdinal(PlantStatusConstants.FieldName.PlantStatusName)
            FieldOrdinal.PlantStatusDescription = dr.GetOrdinal(PlantStatusConstants.FieldName.PlantStatusDescription)
            FieldOrdinal.PlantStatusIMSCode = dr.GetOrdinal(PlantStatusConstants.FieldName.PlantStatusIMSCode)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strPlantStatusName As String) As PlantStatus

            Dim objPlantStatus As PlantStatus = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlantStatus As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmstrPlantStatusName As OleDbParameter = New OleDbParameter

            With prmstrPlantStatusName
                .ParameterName = ParameterName.PlantStatusName
                .Direction = ParameterDirection.Input
                .Value = strPlantStatusName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrPlantStatusName

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlantStatus = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByLookupName, commandParameters)
            If (drPlantStatus.HasRows) Then
                objPlantStatus = New PlantStatus
                Call SetFieldOrdinalValues(drPlantStatus)
                drPlantStatus.Read()
                With objPlantStatus
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusID))) Then
                        .PlantStatusID = CInt(drPlantStatus(FieldOrdinal.PlantStatusID))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusName))) Then
                        .PlantStatusName = CStr(drPlantStatus(FieldOrdinal.PlantStatusName))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusDescription))) Then
                        .PlantStatusDescription = CStr(drPlantStatus(FieldOrdinal.PlantStatusDescription))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusIMSCode))) Then
                        .PlantStatusIMSCode = CStr(drPlantStatus(FieldOrdinal.PlantStatusIMSCode))
                    End If
                End With
            End If
            drPlantStatus.Close()
            cnFacilities.Close()

            Return objPlantStatus

        End Function

        Friend Function GetByPrimaryKey(ByVal intPlantStatusID As Int32) As PlantStatus

            Dim objPlantStatus As PlantStatus = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlantStatus As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmintPlantStatusID As OleDbParameter = New OleDbParameter

            With prmintPlantStatusID
                .ParameterName = ParameterName.PlantStatusID
                .Direction = ParameterDirection.Input
                .Value = intPlantStatusID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPlantStatusID

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlantStatus = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPlantStatus.HasRows) Then
                objPlantStatus = New PlantStatus
                Call SetFieldOrdinalValues(drPlantStatus)
                drPlantStatus.Read()
                With objPlantStatus
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusID))) Then
                        .PlantStatusID = CInt(drPlantStatus(FieldOrdinal.PlantStatusID))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusName))) Then
                        .PlantStatusName = CStr(drPlantStatus(FieldOrdinal.PlantStatusName))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusDescription))) Then
                        .PlantStatusDescription = CStr(drPlantStatus(FieldOrdinal.PlantStatusDescription))
                    End If
                    If (Not IsDBNull(drPlantStatus(FieldOrdinal.PlantStatusIMSCode))) Then
                        .PlantStatusIMSCode = CStr(drPlantStatus(FieldOrdinal.PlantStatusIMSCode))
                    End If
                End With
            End If
            drPlantStatus.Close()
            cnFacilities.Close()

            Return objPlantStatus

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
