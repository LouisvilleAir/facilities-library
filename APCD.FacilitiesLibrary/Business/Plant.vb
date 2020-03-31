'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: Plant.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Business class for the Plant table of the Facilities database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Data

Namespace APCD.Facilities.Business

    <Serializable()> Public Class Plant

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPlantID As Int32 'primary key
        Private m_strPlantName As String
        Private m_strPlantDescription As String
        Private m_intFacilitySiteEISID As Int32
        Private m_intPlantStatusID As Int32
        Private m_dtBeginDate As DateTime
        Private m_dtEndDate As DateTime
        Private m_intAddressID As Int32
        Private m_intPlantClassID As Int32
        Private m_intGovernmentFacilityTypeID As Int32
        Private m_intNumberOfEmployees As Int32
        Private m_dblPlantArea As Double
        Private m_blnIsReportedToEIS As Boolean
        Private m_strCommentPublic As String
        Private m_strCommentInternal As String
        Private m_dtAddDate As DateTime
        Private m_intAddedBy As Int32

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property PlantID() As Int32
            Get
                Return Me.m_intPlantID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPlantID = Value
            End Set
        End Property

        Public Property PlantName() As String
            Get
                Return Me.m_strPlantName
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantName = Value
            End Set
        End Property

        Public Property PlantDescription() As String
            Get
                Return Me.m_strPlantDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantDescription = Value
            End Set
        End Property

        Public Property FacilitySiteEISID() As Int32
            Get
                Return Me.m_intFacilitySiteEISID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intFacilitySiteEISID = Value
            End Set
        End Property

        Public Property PlantStatusID() As Int32
            Get
                Return Me.m_intPlantStatusID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPlantStatusID = Value
            End Set
        End Property

        Public Property BeginDate() As DateTime
            Get
                Return Me.m_dtBeginDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtBeginDate = Value
            End Set
        End Property

        Public Property EndDate() As DateTime
            Get
                Return Me.m_dtEndDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtEndDate = Value
            End Set
        End Property

        Public Property AddressID() As Int32
            Get
                Return Me.m_intAddressID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intAddressID = Value
            End Set
        End Property

        Public Property PlantClassID() As Int32
            Get
                Return Me.m_intPlantClassID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPlantClassID = Value
            End Set
        End Property

        Public Property GovernmentFacilityTypeID() As Int32
            Get
                Return Me.m_intGovernmentFacilityTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intGovernmentFacilityTypeID = Value
            End Set
        End Property

        Public Property NumberOfEmployees() As Int32
            Get
                Return Me.m_intNumberOfEmployees
            End Get
            Set(ByVal Value As Int32)
                Me.m_intNumberOfEmployees = Value
            End Set
        End Property

        Public Property PlantArea() As Double
            Get
                Return Me.m_dblPlantArea
            End Get
            Set(ByVal Value As Double)
                Me.m_dblPlantArea = Value
            End Set
        End Property

        Public Property IsReportedToEIS() As Boolean
            Get
                Return Me.m_blnIsReportedToEIS
            End Get
            Set(ByVal Value As Boolean)
                Me.m_blnIsReportedToEIS = Value
            End Set
        End Property

        Public Property CommentPublic() As String
            Get
                Return Me.m_strCommentPublic
            End Get
            Set(ByVal Value As String)
                Me.m_strCommentPublic = Value
            End Set
        End Property

        Public Property CommentInternal() As String
            Get
                Return Me.m_strCommentInternal
            End Get
            Set(ByVal Value As String)
                Me.m_strCommentInternal = Value
            End Set
        End Property

        Public Property AddDate() As DateTime
            Get
                Return Me.m_dtAddDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtAddDate = Value
            End Set
        End Property

        Public Property AddedBy() As Int32
            Get
                Return Me.m_intAddedBy
            End Get
            Set(ByVal Value As Int32)
                Me.m_intAddedBy = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantDB As PlantDB

            Try
                objPlantDB = New PlantDB
                intReutrnValue = objPlantDB.Insert(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantDB As PlantDB

            Try
                objPlantDB = New PlantDB
                intReutrnValue = objPlantDB.Update(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantDB As PlantDB

            Try
                objPlantDB = New PlantDB
                intReutrnValue = objPlantDB.Delete(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

#End Region '----- DML -----

#Region "----- Object Class Overloads-----"

        Public Overrides Function ToString() As String

            Dim strbToString As Text.StringBuilder

            strbToString = New Text.StringBuilder
            With strbToString

                .Append(Constants.PlantConstants.FieldName.PlantID)
                .Append(":")
                .Append(Me.PlantID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.PlantName)
                .Append(":")
                .Append(Me.PlantName)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.PlantDescription)
                .Append(":")
                .Append(Me.PlantDescription)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.FacilitySiteEISID)
                .Append(":")
                .Append(Me.FacilitySiteEISID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.PlantStatusID)
                .Append(":")
                .Append(Me.PlantStatusID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.BeginDate)
                .Append(":")
                .Append(Me.BeginDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.EndDate)
                .Append(":")
                .Append(Me.EndDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.AddressID)
                .Append(":")
                .Append(Me.AddressID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.PlantClassID)
                .Append(":")
                .Append(Me.PlantClassID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.GovernmentFacilityTypeID)
                .Append(":")
                .Append(Me.GovernmentFacilityTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.NumberOfEmployees)
                .Append(":")
                .Append(Me.NumberOfEmployees)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.PlantArea)
                .Append(":")
                .Append(Me.PlantArea)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.IsReportedToEIS)
                .Append(":")
                .Append(Me.IsReportedToEIS)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.CommentPublic)
                .Append(":")
                .Append(Me.CommentPublic)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.CommentInternal)
                .Append(":")
                .Append(Me.CommentInternal)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.AddDate)
                .Append(":")
                .Append(Me.AddDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantConstants.FieldName.AddedBy)
                .Append(":")
                .Append(Me.AddedBy)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.PlantID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPlant As Plant) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PlantID = objPlant.PlantID) _
                AndAlso (Me.PlantName = objPlant.PlantName) _
                AndAlso (Me.PlantDescription = objPlant.PlantDescription) _
                AndAlso (Me.FacilitySiteEISID = objPlant.FacilitySiteEISID) _
                AndAlso (Me.PlantStatusID = objPlant.PlantStatusID) _
                AndAlso (Me.BeginDate = objPlant.BeginDate) _
                AndAlso (Me.EndDate = objPlant.EndDate) _
                AndAlso (Me.AddressID = objPlant.AddressID) _
                AndAlso (Me.PlantClassID = objPlant.PlantClassID) _
                AndAlso (Me.GovernmentFacilityTypeID = objPlant.GovernmentFacilityTypeID) _
                AndAlso (Me.NumberOfEmployees = objPlant.NumberOfEmployees) _
                AndAlso (Me.PlantArea = objPlant.PlantArea) _
                AndAlso (Me.IsReportedToEIS = objPlant.IsReportedToEIS) _
                AndAlso (Me.CommentPublic = objPlant.CommentPublic) _
                AndAlso (Me.CommentInternal = objPlant.CommentInternal) _
                AndAlso (Me.AddDate = objPlant.AddDate) _
                AndAlso (Me.AddedBy = objPlant.AddedBy)) Then
                blnEquals = True
            Else
                blnEquals = False
            End If

            Return blnEquals

        End Function

#End Region '----- Object Class Overloads-----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
