'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantClassDB.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Data access class for the PlantClass table of the Facilities database.
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

    <Serializable()> Friend Class PlantClassDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared PlantClassID As Int32 'primary key
            Public Shared PlantClassName As Int32
            Public Shared PlantClassDescription As Int32
            Public Shared HansenAPDefnKey As Int32
            Public Shared PlantClassIMSCode As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "PlantClass_Insert"
            Public Const Update As String = "PlantClass_Update"
            Public Const Delete As String = "PlantClass_Delete"
            Public Const GetByPrimaryKey As String = "PlantClass_GetByPrimaryKey"
            Public Const GetAll As String = "PlantClass_GetAll"
            Public Const GetLookupTable As String = "PlantClass_GetLookupTable"
            Public Const GetByLookupName As String = "PlantClass_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPlantClassID As OleDbParameter 'primary key
        Private m_prmstrPlantClassName As OleDbParameter
        Private m_prmstrPlantClassDescription As OleDbParameter
        Private m_prmintHansenAPDefnKey As OleDbParameter
        Private m_prmstrPlantClassIMSCode As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PlantClassID As String = "@PlantClassID"
            Public Const PlantClassName As String = "@PlantClassName"
            Public Const PlantClassDescription As String = "@PlantClassDescription"
            Public Const HansenAPDefnKey As String = "@HansenAPDefnKey"
            Public Const PlantClassIMSCode As String = "@PlantClassIMSCode"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPlantClass As PlantClass) As Int32

            Return Me.DMLHelper(objPlantClass, DMLType.Insert)

        End Function

        Friend Function Update(ByVal objPlantClass As PlantClass) As Int32

            Return Me.DMLHelper(objPlantClass, DMLType.Update)

        End Function

        Friend Function Delete(ByVal objPlantClass As PlantClass) As Int32

            Return Me.DMLHelper(objPlantClass, DMLType.Delete)

        End Function

        Private Function DMLHelper(ByVal objPlantClass As PlantClass, ByVal iDMLType As DMLType) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPlantClass, iDMLType)
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

            Me.m_prmintPlantClassID = Nothing
            Me.m_prmintPlantClassID = New OleDbParameter

            Me.m_prmstrPlantClassName = Nothing
            Me.m_prmstrPlantClassName = New OleDbParameter

            Me.m_prmstrPlantClassDescription = Nothing
            Me.m_prmstrPlantClassDescription = New OleDbParameter

            Me.m_prmintHansenAPDefnKey = Nothing
            Me.m_prmintHansenAPDefnKey = New OleDbParameter

            Me.m_prmstrPlantClassIMSCode = Nothing
            Me.m_prmstrPlantClassIMSCode = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPlantClass As PlantClass, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPlantClassID
                            .ParameterName = ParameterName.PlantClassID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantClass.PlantClassID
                        End With

                        With .m_prmstrPlantClassName
                            .ParameterName = ParameterName.PlantClassName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassName
                        End With

                        With .m_prmstrPlantClassDescription
                            .ParameterName = ParameterName.PlantClassDescription
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassDescription
                        End With

                        With .m_prmintHansenAPDefnKey
                            .ParameterName = ParameterName.HansenAPDefnKey
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantClass.HansenAPDefnKey
                        End With

                        With .m_prmstrPlantClassIMSCode
                            .ParameterName = ParameterName.PlantClassIMSCode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassIMSCode
                        End With

                    Case DMLType.Update

                        With .m_prmintPlantClassID
                            .ParameterName = "@PlantClassID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantClass.PlantClassID
                        End With

                        With .m_prmstrPlantClassName
                            .ParameterName = "@PlantClassName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassName
                        End With

                        With .m_prmstrPlantClassDescription
                            .ParameterName = "@PlantClassDescription"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassDescription
                        End With

                        With .m_prmintHansenAPDefnKey
                            .ParameterName = "@HansenAPDefnKey"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantClass.HansenAPDefnKey
                        End With

                        With .m_prmstrPlantClassIMSCode
                            .ParameterName = "@PlantClassIMSCode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlantClass.PlantClassIMSCode
                        End With

                    Case DMLType.Delete

                        With .m_prmintPlantClassID
                            .ParameterName = "@PlantClassID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlantClass.PlantClassID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(4) {}
                    commandParameters(0) = Me.m_prmintPlantClassID
                    commandParameters(1) = Me.m_prmstrPlantClassName
                    commandParameters(2) = Me.m_prmstrPlantClassDescription
                    commandParameters(3) = Me.m_prmintHansenAPDefnKey
                    commandParameters(4) = Me.m_prmstrPlantClassIMSCode
                Case DMLType.Update
                    commandParameters = New OleDbParameter(4) {}
                    commandParameters(0) = Me.m_prmintPlantClassID
                    commandParameters(1) = Me.m_prmstrPlantClassName
                    commandParameters(2) = Me.m_prmstrPlantClassDescription
                    commandParameters(3) = Me.m_prmintHansenAPDefnKey
                    commandParameters(4) = Me.m_prmstrPlantClassIMSCode
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintPlantClassID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PlantClassID = dr.GetOrdinal(PlantClassConstants.FieldName.PlantClassID)
            FieldOrdinal.PlantClassName = dr.GetOrdinal(PlantClassConstants.FieldName.PlantClassName)
            FieldOrdinal.PlantClassDescription = dr.GetOrdinal(PlantClassConstants.FieldName.PlantClassDescription)
            FieldOrdinal.HansenAPDefnKey = dr.GetOrdinal(PlantClassConstants.FieldName.HansenAPDefnKey)
            FieldOrdinal.PlantClassIMSCode = dr.GetOrdinal(PlantClassConstants.FieldName.PlantClassIMSCode)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strPlantClassName As String) As PlantClass

            Dim objPlantClass As PlantClass = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlantClass As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmstrPlantClassName As OleDbParameter = New OleDbParameter

            With prmstrPlantClassName
                .ParameterName = ParameterName.PlantClassName
                .Direction = ParameterDirection.Input
                .Value = strPlantClassName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrPlantClassName

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlantClass = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByLookupName, commandParameters)
            If (drPlantClass.HasRows) Then
                objPlantClass = New PlantClass
                Call SetFieldOrdinalValues(drPlantClass)
                drPlantClass.Read()
                With objPlantClass
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassID))) Then
                        .PlantClassID = CInt(drPlantClass(FieldOrdinal.PlantClassID))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassName))) Then
                        .PlantClassName = CStr(drPlantClass(FieldOrdinal.PlantClassName))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassDescription))) Then
                        .PlantClassDescription = CStr(drPlantClass(FieldOrdinal.PlantClassDescription))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.HansenAPDefnKey))) Then
                        .HansenAPDefnKey = CInt(drPlantClass(FieldOrdinal.HansenAPDefnKey))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassIMSCode))) Then
                        .PlantClassIMSCode = CStr(drPlantClass(FieldOrdinal.PlantClassIMSCode))
                    End If
                End With
            End If
            drPlantClass.Close()
            cnFacilities.Close()

            Return objPlantClass

        End Function

        Friend Function GetByPrimaryKey(ByVal intPlantClassID As Int32) As PlantClass

            Dim objPlantClass As PlantClass = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlantClass As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmintPlantClassID As OleDbParameter = New OleDbParameter

            With prmintPlantClassID
                .ParameterName = ParameterName.PlantClassID
                .Direction = ParameterDirection.Input
                .Value = intPlantClassID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPlantClassID

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlantClass = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPlantClass.HasRows) Then
                objPlantClass = New PlantClass
                Call SetFieldOrdinalValues(drPlantClass)
                drPlantClass.Read()
                With objPlantClass
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassID))) Then
                        .PlantClassID = CInt(drPlantClass(FieldOrdinal.PlantClassID))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassName))) Then
                        .PlantClassName = CStr(drPlantClass(FieldOrdinal.PlantClassName))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassDescription))) Then
                        .PlantClassDescription = CStr(drPlantClass(FieldOrdinal.PlantClassDescription))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.HansenAPDefnKey))) Then
                        .HansenAPDefnKey = CInt(drPlantClass(FieldOrdinal.HansenAPDefnKey))
                    End If
                    If (Not IsDBNull(drPlantClass(FieldOrdinal.PlantClassIMSCode))) Then
                        .PlantClassIMSCode = CStr(drPlantClass(FieldOrdinal.PlantClassIMSCode))
                    End If
                End With
            End If
            drPlantClass.Close()
            cnFacilities.Close()

            Return objPlantClass

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
