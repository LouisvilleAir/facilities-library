'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantDB.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Data access class for the Plant table of the Facilities database.
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

    <Serializable()> Friend Class PlantDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared PlantID As Int32 'primary key
            Public Shared PlantName As Int32
            Public Shared PlantDescription As Int32
            Public Shared FacilitySiteEISID As Int32
            Public Shared PlantStatusID As Int32
            Public Shared BeginDate As Int32
            Public Shared EndDate As Int32
            Public Shared AddressID As Int32
            Public Shared PlantClassID As Int32
            Public Shared GovernmentFacilityTypeID As Int32
            Public Shared NumberOfEmployees As Int32
            Public Shared PlantArea As Int32
            Public Shared IsReportedToEIS As Int32
            Public Shared CommentPublic As Int32
            Public Shared CommentInternal As Int32
            Public Shared AddDate As Int32
            Public Shared AddedBy As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "Plant_Insert"
            Public Const Update As String = "Plant_Update"
            Public Const Delete As String = "Plant_Delete"
            Public Const GetByPrimaryKey As String = "Plant_GetByPrimaryKey"
            Public Const GetAll As String = "Plant_GetAll"
            Public Const GetLookupTable As String = "Plant_GetLookupTable"
            Public Const GetByLookupName As String = "Plant_GetByLookupName"
            Public Const GetByPlantClassID As String = "Plant_GetByPlantClassID"
            Public Const GetByPlantStatusID As String = "Plant_GetByPlantStatusID"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPlantID As OleDbParameter 'primary key
        Private m_prmstrPlantName As OleDbParameter
        Private m_prmstrPlantDescription As OleDbParameter
        Private m_prmintFacilitySiteEISID As OleDbParameter
        Private m_prmintPlantStatusID As OleDbParameter
        Private m_prmdtBeginDate As OleDbParameter
        Private m_prmdtEndDate As OleDbParameter
        Private m_prmintAddressID As OleDbParameter
        Private m_prmintPlantClassID As OleDbParameter
        Private m_prmintGovernmentFacilityTypeID As OleDbParameter
        Private m_prmintNumberOfEmployees As OleDbParameter
        Private m_prmdblPlantArea As OleDbParameter
        Private m_prmblnIsReportedToEIS As OleDbParameter
        Private m_prmstrCommentPublic As OleDbParameter
        Private m_prmstrCommentInternal As OleDbParameter
        Private m_prmdtAddDate As OleDbParameter
        Private m_prmintAddedBy As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PlantID As String = "@PlantID"
            Public Const PlantName As String = "@PlantName"
            Public Const PlantDescription As String = "@PlantDescription"
            Public Const FacilitySiteEISID As String = "@FacilitySiteEISID"
            Public Const PlantStatusID As String = "@PlantStatusID"
            Public Const BeginDate As String = "@BeginDate"
            Public Const EndDate As String = "@EndDate"
            Public Const AddressID As String = "@AddressID"
            Public Const PlantClassID As String = "@PlantClassID"
            Public Const GovernmentFacilityTypeID As String = "@GovernmentFacilityTypeID"
            Public Const NumberOfEmployees As String = "@NumberOfEmployees"
            Public Const PlantArea As String = "@PlantArea"
            Public Const IsReportedToEIS As String = "@IsReportedToEIS"
            Public Const CommentPublic As String = "@CommentPublic"
            Public Const CommentInternal As String = "@CommentInternal"
            Public Const AddDate As String = "@AddDate"
            Public Const AddedBy As String = "@AddedBy"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPlant As Plant) As Int32

            Return Me.DMLHelper(objPlant, DMLType.Insert)

        End Function

        Friend Function Update(ByVal objPlant As Plant) As Int32

            Return Me.DMLHelper(objPlant, DMLType.Update)

        End Function

        Friend Function Delete(ByVal objPlant As Plant) As Int32

            Return Me.DMLHelper(objPlant, DMLType.Delete)

        End Function

        Private Function DMLHelper(ByVal objPlant As Plant, ByVal iDMLType As DMLType) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPlant, iDMLType)
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

            Me.m_prmintPlantID = Nothing
            Me.m_prmintPlantID = New OleDbParameter

            Me.m_prmstrPlantName = Nothing
            Me.m_prmstrPlantName = New OleDbParameter

            Me.m_prmstrPlantDescription = Nothing
            Me.m_prmstrPlantDescription = New OleDbParameter

            Me.m_prmintFacilitySiteEISID = Nothing
            Me.m_prmintFacilitySiteEISID = New OleDbParameter

            Me.m_prmintPlantStatusID = Nothing
            Me.m_prmintPlantStatusID = New OleDbParameter

            Me.m_prmdtBeginDate = Nothing
            Me.m_prmdtBeginDate = New OleDbParameter

            Me.m_prmdtEndDate = Nothing
            Me.m_prmdtEndDate = New OleDbParameter

            Me.m_prmintAddressID = Nothing
            Me.m_prmintAddressID = New OleDbParameter

            Me.m_prmintPlantClassID = Nothing
            Me.m_prmintPlantClassID = New OleDbParameter

            Me.m_prmintGovernmentFacilityTypeID = Nothing
            Me.m_prmintGovernmentFacilityTypeID = New OleDbParameter

            Me.m_prmintNumberOfEmployees = Nothing
            Me.m_prmintNumberOfEmployees = New OleDbParameter

            Me.m_prmdblPlantArea = Nothing
            Me.m_prmdblPlantArea = New OleDbParameter

            Me.m_prmblnIsReportedToEIS = Nothing
            Me.m_prmblnIsReportedToEIS = New OleDbParameter

            Me.m_prmstrCommentPublic = Nothing
            Me.m_prmstrCommentPublic = New OleDbParameter

            Me.m_prmstrCommentInternal = Nothing
            Me.m_prmstrCommentInternal = New OleDbParameter

            Me.m_prmdtAddDate = Nothing
            Me.m_prmdtAddDate = New OleDbParameter

            Me.m_prmintAddedBy = Nothing
            Me.m_prmintAddedBy = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPlant As Plant, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPlantID
                            .ParameterName = ParameterName.PlantID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantID
                        End With

                        With .m_prmstrPlantName
                            .ParameterName = ParameterName.PlantName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.PlantName
                        End With

                        With .m_prmstrPlantDescription
                            .ParameterName = ParameterName.PlantDescription
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.PlantDescription
                        End With

                        With .m_prmintFacilitySiteEISID
                            .ParameterName = ParameterName.FacilitySiteEISID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.FacilitySiteEISID
                        End With

                        With .m_prmintPlantStatusID
                            .ParameterName = ParameterName.PlantStatusID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantStatusID
                        End With

                        With .m_prmdtBeginDate
                            .ParameterName = ParameterName.BeginDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.BeginDate
                        End With

                        With .m_prmdtEndDate
                            .ParameterName = ParameterName.EndDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.EndDate
                        End With

                        With .m_prmintAddressID
                            .ParameterName = ParameterName.AddressID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.AddressID
                        End With

                        With .m_prmintPlantClassID
                            .ParameterName = ParameterName.PlantClassID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantClassID
                        End With

                        With .m_prmintGovernmentFacilityTypeID
                            .ParameterName = ParameterName.GovernmentFacilityTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.GovernmentFacilityTypeID
                        End With

                        With .m_prmintNumberOfEmployees
                            .ParameterName = ParameterName.NumberOfEmployees
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.NumberOfEmployees
                        End With

                        With .m_prmdblPlantArea
                            .ParameterName = ParameterName.PlantArea
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Single

                            .Value = objPlant.PlantArea
                        End With

                        With .m_prmblnIsReportedToEIS
                            .ParameterName = ParameterName.IsReportedToEIS
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Boolean
                            .Value = objPlant.IsReportedToEIS
                        End With

                        With .m_prmstrCommentPublic
                            .ParameterName = ParameterName.CommentPublic
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.CommentPublic
                        End With

                        With .m_prmstrCommentInternal
                            .ParameterName = ParameterName.CommentInternal
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.CommentInternal
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = ParameterName.AddDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = ParameterName.AddedBy
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.AddedBy
                        End With

                    Case DMLType.Update

                        With .m_prmintPlantID
                            .ParameterName = "@PlantID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantID
                        End With

                        With .m_prmstrPlantName
                            .ParameterName = "@PlantName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.PlantName
                        End With

                        With .m_prmstrPlantDescription
                            .ParameterName = "@PlantDescription"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.PlantDescription
                        End With

                        With .m_prmintFacilitySiteEISID
                            .ParameterName = "@FacilitySiteEISID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.FacilitySiteEISID
                        End With

                        With .m_prmintPlantStatusID
                            .ParameterName = "@PlantStatusID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantStatusID
                        End With

                        With .m_prmdtBeginDate
                            .ParameterName = "@BeginDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.BeginDate
                        End With

                        With .m_prmdtEndDate
                            .ParameterName = "@EndDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.EndDate
                        End With

                        With .m_prmintAddressID
                            .ParameterName = "@AddressID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.AddressID
                        End With

                        With .m_prmintPlantClassID
                            .ParameterName = "@PlantClassID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantClassID
                        End With

                        With .m_prmintGovernmentFacilityTypeID
                            .ParameterName = "@GovernmentFacilityTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.GovernmentFacilityTypeID
                        End With

                        With .m_prmintNumberOfEmployees
                            .ParameterName = "@NumberOfEmployees"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.NumberOfEmployees
                        End With

                        With .m_prmdblPlantArea
                            .ParameterName = "@PlantArea"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Single
                            .Value = objPlant.PlantArea
                        End With

                        With .m_prmblnIsReportedToEIS
                            .ParameterName = "@IsReportedToEIS"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Boolean
                            .Value = objPlant.IsReportedToEIS
                        End With

                        With .m_prmstrCommentPublic
                            .ParameterName = "@CommentPublic"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.CommentPublic
                        End With

                        With .m_prmstrCommentInternal
                            .ParameterName = "@CommentInternal"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPlant.CommentInternal
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = "@AddDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPlant.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = "@AddedBy"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.AddedBy
                        End With

                    Case DMLType.Delete

                        With .m_prmintPlantID
                            .ParameterName = "@PlantID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPlant.PlantID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(16) {}
                    commandParameters(0) = Me.m_prmintPlantID
                    commandParameters(1) = Me.m_prmstrPlantName
                    commandParameters(2) = Me.m_prmstrPlantDescription
                    commandParameters(3) = Me.m_prmintFacilitySiteEISID
                    commandParameters(4) = Me.m_prmintPlantStatusID
                    commandParameters(5) = Me.m_prmdtBeginDate
                    commandParameters(6) = Me.m_prmdtEndDate
                    commandParameters(7) = Me.m_prmintAddressID
                    commandParameters(8) = Me.m_prmintPlantClassID
                    commandParameters(9) = Me.m_prmintGovernmentFacilityTypeID
                    commandParameters(10) = Me.m_prmintNumberOfEmployees
                    commandParameters(11) = Me.m_prmdblPlantArea
                    commandParameters(12) = Me.m_prmblnIsReportedToEIS
                    commandParameters(13) = Me.m_prmstrCommentPublic
                    commandParameters(14) = Me.m_prmstrCommentInternal
                    commandParameters(15) = Me.m_prmdtAddDate
                    commandParameters(16) = Me.m_prmintAddedBy
                Case DMLType.Update
                    commandParameters = New OleDbParameter(16) {}
                    commandParameters(0) = Me.m_prmintPlantID
                    commandParameters(1) = Me.m_prmstrPlantName
                    commandParameters(2) = Me.m_prmstrPlantDescription
                    commandParameters(3) = Me.m_prmintFacilitySiteEISID
                    commandParameters(4) = Me.m_prmintPlantStatusID
                    commandParameters(5) = Me.m_prmdtBeginDate
                    commandParameters(6) = Me.m_prmdtEndDate
                    commandParameters(7) = Me.m_prmintAddressID
                    commandParameters(8) = Me.m_prmintPlantClassID
                    commandParameters(9) = Me.m_prmintGovernmentFacilityTypeID
                    commandParameters(10) = Me.m_prmintNumberOfEmployees
                    commandParameters(11) = Me.m_prmdblPlantArea
                    commandParameters(12) = Me.m_prmblnIsReportedToEIS
                    commandParameters(13) = Me.m_prmstrCommentPublic
                    commandParameters(14) = Me.m_prmstrCommentInternal
                    commandParameters(15) = Me.m_prmdtAddDate
                    commandParameters(16) = Me.m_prmintAddedBy
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintPlantID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PlantID = dr.GetOrdinal(PlantConstants.FieldName.PlantID)
            FieldOrdinal.PlantName = dr.GetOrdinal(PlantConstants.FieldName.PlantName)
            FieldOrdinal.PlantDescription = dr.GetOrdinal(PlantConstants.FieldName.PlantDescription)
            FieldOrdinal.FacilitySiteEISID = dr.GetOrdinal(PlantConstants.FieldName.FacilitySiteEISID)
            FieldOrdinal.PlantStatusID = dr.GetOrdinal(PlantConstants.FieldName.PlantStatusID)
            FieldOrdinal.BeginDate = dr.GetOrdinal(PlantConstants.FieldName.BeginDate)
            FieldOrdinal.EndDate = dr.GetOrdinal(PlantConstants.FieldName.EndDate)
            FieldOrdinal.AddressID = dr.GetOrdinal(PlantConstants.FieldName.AddressID)
            FieldOrdinal.PlantClassID = dr.GetOrdinal(PlantConstants.FieldName.PlantClassID)
            FieldOrdinal.GovernmentFacilityTypeID = dr.GetOrdinal(PlantConstants.FieldName.GovernmentFacilityTypeID)
            FieldOrdinal.NumberOfEmployees = dr.GetOrdinal(PlantConstants.FieldName.NumberOfEmployees)
            FieldOrdinal.PlantArea = dr.GetOrdinal(PlantConstants.FieldName.PlantArea)
            FieldOrdinal.IsReportedToEIS = dr.GetOrdinal(PlantConstants.FieldName.IsReportedToEIS)
            FieldOrdinal.CommentPublic = dr.GetOrdinal(PlantConstants.FieldName.CommentPublic)
            FieldOrdinal.CommentInternal = dr.GetOrdinal(PlantConstants.FieldName.CommentInternal)
            FieldOrdinal.AddDate = dr.GetOrdinal(PlantConstants.FieldName.AddDate)
            FieldOrdinal.AddedBy = dr.GetOrdinal(PlantConstants.FieldName.AddedBy)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strPlantName As String) As Plant

            Dim objPlant As Plant = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlant As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmstrPlantName As OleDbParameter = New OleDbParameter

            With prmstrPlantName
                .ParameterName = ParameterName.PlantName
                .Direction = ParameterDirection.Input
                .Value = strPlantName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrPlantName

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlant = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByLookupName, commandParameters)
            If (drPlant.HasRows) Then
                objPlant = New Plant
                Call SetFieldOrdinalValues(drPlant)
                drPlant.Read()
                With objPlant
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantID))) Then
                        .PlantID = CInt(drPlant(FieldOrdinal.PlantID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantName))) Then
                        .PlantName = CStr(drPlant(FieldOrdinal.PlantName))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantDescription))) Then
                        .PlantDescription = CStr(drPlant(FieldOrdinal.PlantDescription))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.FacilitySiteEISID))) Then
                        .FacilitySiteEISID = CInt(drPlant(FieldOrdinal.FacilitySiteEISID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantStatusID))) Then
                        .PlantStatusID = CInt(drPlant(FieldOrdinal.PlantStatusID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.BeginDate))) Then
                        .BeginDate = CDate(drPlant(FieldOrdinal.BeginDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.EndDate))) Then
                        .EndDate = CDate(drPlant(FieldOrdinal.EndDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddressID))) Then
                        .AddressID = CInt(drPlant(FieldOrdinal.AddressID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantClassID))) Then
                        .PlantClassID = CInt(drPlant(FieldOrdinal.PlantClassID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.GovernmentFacilityTypeID))) Then
                        .GovernmentFacilityTypeID = CInt(drPlant(FieldOrdinal.GovernmentFacilityTypeID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.NumberOfEmployees))) Then
                        .NumberOfEmployees = CInt(drPlant(FieldOrdinal.NumberOfEmployees))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantArea))) Then
                        .PlantArea = CDbl(drPlant(FieldOrdinal.PlantArea))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.IsReportedToEIS))) Then
                        .IsReportedToEIS = CBool(drPlant(FieldOrdinal.IsReportedToEIS))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.CommentPublic))) Then
                        .CommentPublic = CStr(drPlant(FieldOrdinal.CommentPublic))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.CommentInternal))) Then
                        .CommentInternal = CStr(drPlant(FieldOrdinal.CommentInternal))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddDate))) Then
                        .AddDate = CDate(drPlant(FieldOrdinal.AddDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddedBy))) Then
                        .AddedBy = CInt(drPlant(FieldOrdinal.AddedBy))
                    End If
                End With
            End If
            drPlant.Close()
            cnFacilities.Close()

            Return objPlant

        End Function

        Friend Function GetByPrimaryKey(ByVal intPlantID As Int32) As Plant

            Dim objPlant As Plant = Nothing
            Dim cnFacilities As OleDbConnection
            Dim drPlant As OleDbDataReader
            Dim commandParameters() As OleDbParameter
            Dim prmintPlantID As OleDbParameter = New OleDbParameter

            With prmintPlantID
                .ParameterName = ParameterName.PlantID
                .Direction = ParameterDirection.Input
                .Value = intPlantID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPlantID

            cnFacilities = New OleDbConnection(GlobalVariables.ConnectionString)
            cnFacilities.Open()
            drPlant = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPlant.HasRows) Then
                objPlant = New Plant
                Call SetFieldOrdinalValues(drPlant)
                drPlant.Read()
                With objPlant
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantID))) Then
                        .PlantID = CInt(drPlant(FieldOrdinal.PlantID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantName))) Then
                        .PlantName = CStr(drPlant(FieldOrdinal.PlantName))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantDescription))) Then
                        .PlantDescription = CStr(drPlant(FieldOrdinal.PlantDescription))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.FacilitySiteEISID))) Then
                        .FacilitySiteEISID = CInt(drPlant(FieldOrdinal.FacilitySiteEISID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantStatusID))) Then
                        .PlantStatusID = CInt(drPlant(FieldOrdinal.PlantStatusID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.BeginDate))) Then
                        .BeginDate = CDate(drPlant(FieldOrdinal.BeginDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.EndDate))) Then
                        .EndDate = CDate(drPlant(FieldOrdinal.EndDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddressID))) Then
                        .AddressID = CInt(drPlant(FieldOrdinal.AddressID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantClassID))) Then
                        .PlantClassID = CInt(drPlant(FieldOrdinal.PlantClassID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.GovernmentFacilityTypeID))) Then
                        .GovernmentFacilityTypeID = CInt(drPlant(FieldOrdinal.GovernmentFacilityTypeID))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.NumberOfEmployees))) Then
                        .NumberOfEmployees = CInt(drPlant(FieldOrdinal.NumberOfEmployees))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.PlantArea))) Then
                        .PlantArea = CDbl(drPlant(FieldOrdinal.PlantArea))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.IsReportedToEIS))) Then
                        .IsReportedToEIS = CBool(drPlant(FieldOrdinal.IsReportedToEIS))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.CommentPublic))) Then
                        .CommentPublic = CStr(drPlant(FieldOrdinal.CommentPublic))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.CommentInternal))) Then
                        .CommentInternal = CStr(drPlant(FieldOrdinal.CommentInternal))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddDate))) Then
                        .AddDate = CDate(drPlant(FieldOrdinal.AddDate))
                    End If
                    If (Not IsDBNull(drPlant(FieldOrdinal.AddedBy))) Then
                        .AddedBy = CInt(drPlant(FieldOrdinal.AddedBy))
                    End If
                End With
            End If
            drPlant.Close()
            cnFacilities.Close()

            Return objPlant

        End Function

        Friend Function GetByPlantClassID(ByVal intPlantClassID As Int32) As DataTable

            Dim dtbPlant As DataTable
            Dim commandParameters() As OleDbParameter
            Dim prmintPlantClassID As OleDbParameter = New OleDbParameter

            With prmintPlantClassID
                .ParameterName = ParameterName.PlantClassID
                .Direction = ParameterDirection.Input
                .Value = intPlantClassID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPlantClassID

            dtbPlant = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByPlantClassID, commandParameters)

            Return dtbPlant

        End Function

        Friend Function GetByPlantClassID_Collection(ByVal intPlantClassID As Int32) As Plants

            Dim cnFacilities As OleDbConnection
            Dim objPlants As Plants = New Plants
            Dim objPlant As Plant = New Plant
            Dim drPlant As OleDbDataReader
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
            drPlant = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByPlantClassID, commandParameters)
            If (drPlant.HasRows) Then
                Call SetFieldOrdinalValues(drPlant)
                While drPlant.Read()

                    objPlant = New Plant
                    With objPlant
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantID))) Then
                            .PlantID = CInt(drPlant(FieldOrdinal.PlantID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantName))) Then
                            .PlantName = CStr(drPlant(FieldOrdinal.PlantName))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantDescription))) Then
                            .PlantDescription = CStr(drPlant(FieldOrdinal.PlantDescription))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.FacilitySiteEISID))) Then
                            .FacilitySiteEISID = CInt(drPlant(FieldOrdinal.FacilitySiteEISID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantStatusID))) Then
                            .PlantStatusID = CInt(drPlant(FieldOrdinal.PlantStatusID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.BeginDate))) Then
                            .BeginDate = CDate(drPlant(FieldOrdinal.BeginDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.EndDate))) Then
                            .EndDate = CDate(drPlant(FieldOrdinal.EndDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddressID))) Then
                            .AddressID = CInt(drPlant(FieldOrdinal.AddressID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantClassID))) Then
                            .PlantClassID = CInt(drPlant(FieldOrdinal.PlantClassID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.GovernmentFacilityTypeID))) Then
                            .GovernmentFacilityTypeID = CInt(drPlant(FieldOrdinal.GovernmentFacilityTypeID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.NumberOfEmployees))) Then
                            .NumberOfEmployees = CInt(drPlant(FieldOrdinal.NumberOfEmployees))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantArea))) Then
                            .PlantArea = CDbl(drPlant(FieldOrdinal.PlantArea))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.IsReportedToEIS))) Then
                            .IsReportedToEIS = CBool(drPlant(FieldOrdinal.IsReportedToEIS))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.CommentPublic))) Then
                            .CommentPublic = CStr(drPlant(FieldOrdinal.CommentPublic))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.CommentInternal))) Then
                            .CommentInternal = CStr(drPlant(FieldOrdinal.CommentInternal))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddDate))) Then
                            .AddDate = CDate(drPlant(FieldOrdinal.AddDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddedBy))) Then
                            .AddedBy = CInt(drPlant(FieldOrdinal.AddedBy))
                        End If
                    End With
                    objPlants.Add(objPlant)
                    objPlant = Nothing
                End While
            End If
            drPlant.Close()
            cnFacilities.Close()

            Return objPlants

        End Function

        Friend Function GetByPlantStatusID(ByVal intPlantStatusID As Int32) As DataTable

            Dim dtbPlant As DataTable
            Dim commandParameters() As OleDbParameter
            Dim prmintPlantStatusID As OleDbParameter = New OleDbParameter

            With prmintPlantStatusID
                .ParameterName = ParameterName.PlantStatusID
                .Direction = ParameterDirection.Input
                .Value = intPlantStatusID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPlantStatusID

            dtbPlant = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByPlantStatusID, commandParameters)

            Return dtbPlant

        End Function

        Friend Function GetByPlantStatusID_Collection(ByVal intPlantStatusID As Int32) As Plants

            Dim cnFacilities As OleDbConnection
            Dim objPlants As Plants = New Plants
            Dim objPlant As Plant = New Plant
            Dim drPlant As OleDbDataReader
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
            drPlant = OleDbHelper.ExecuteReader(cnFacilities, StoredProcedure.GetByPlantStatusID, commandParameters)
            If (drPlant.HasRows) Then
                Call SetFieldOrdinalValues(drPlant)
                While drPlant.Read()

                    objPlant = New Plant
                    With objPlant
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantID))) Then
                            .PlantID = CInt(drPlant(FieldOrdinal.PlantID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantName))) Then
                            .PlantName = CStr(drPlant(FieldOrdinal.PlantName))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantDescription))) Then
                            .PlantDescription = CStr(drPlant(FieldOrdinal.PlantDescription))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.FacilitySiteEISID))) Then
                            .FacilitySiteEISID = CInt(drPlant(FieldOrdinal.FacilitySiteEISID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantStatusID))) Then
                            .PlantStatusID = CInt(drPlant(FieldOrdinal.PlantStatusID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.BeginDate))) Then
                            .BeginDate = CDate(drPlant(FieldOrdinal.BeginDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.EndDate))) Then
                            .EndDate = CDate(drPlant(FieldOrdinal.EndDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddressID))) Then
                            .AddressID = CInt(drPlant(FieldOrdinal.AddressID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantClassID))) Then
                            .PlantClassID = CInt(drPlant(FieldOrdinal.PlantClassID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.GovernmentFacilityTypeID))) Then
                            .GovernmentFacilityTypeID = CInt(drPlant(FieldOrdinal.GovernmentFacilityTypeID))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.NumberOfEmployees))) Then
                            .NumberOfEmployees = CInt(drPlant(FieldOrdinal.NumberOfEmployees))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.PlantArea))) Then
                            .PlantArea = CDbl(drPlant(FieldOrdinal.PlantArea))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.IsReportedToEIS))) Then
                            .IsReportedToEIS = CBool(drPlant(FieldOrdinal.IsReportedToEIS))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.CommentPublic))) Then
                            .CommentPublic = CStr(drPlant(FieldOrdinal.CommentPublic))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.CommentInternal))) Then
                            .CommentInternal = CStr(drPlant(FieldOrdinal.CommentInternal))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddDate))) Then
                            .AddDate = CDate(drPlant(FieldOrdinal.AddDate))
                        End If
                        If (Not IsDBNull(drPlant(FieldOrdinal.AddedBy))) Then
                            .AddedBy = CInt(drPlant(FieldOrdinal.AddedBy))
                        End If
                    End With
                    objPlants.Add(objPlant)
                    objPlant = Nothing
                End While
            End If
            drPlant.Close()
            cnFacilities.Close()

            Return objPlants

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
