'***********************************************************************************************************************
'Assembly Name: APCD.Facilities
'Filename: PlantStatus.vb
'Author: Mike Farris
'Date: 10/03/2011
'Description: Business class for the PlantStatus table of the Facilities database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Facilities.Data

Namespace APCD.Facilities.Business

    <Serializable()> Public Class PlantStatus

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPlantStatusID As Int32 'primary key
        Private m_strPlantStatusTypeName As String
        Private m_strStatusDescription As String
        Private m_strPlantStatusIMSCode As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property PlantStatusID() As Int32
            Get
                Return Me.m_intPlantStatusID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPlantStatusID = Value
            End Set
        End Property

        Public Property PlantStatusName() As String
            Get
                Return Me.m_strPlantStatusTypeName
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantStatusTypeName = Value
            End Set
        End Property

        Public Property PlantStatusDescription() As String
            Get
                Return Me.m_strStatusDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strStatusDescription = Value
            End Set
        End Property

        Public Property PlantStatusIMSCode() As String
            Get
                Return Me.m_strPlantStatusIMSCode
            End Get
            Set(ByVal Value As String)
                Me.m_strPlantStatusIMSCode = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantStatusDB As PlantStatusDB

            Try
                objPlantStatusDB = New PlantStatusDB
                intReutrnValue = objPlantStatusDB.Insert(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantStatusDB As PlantStatusDB

            Try
                objPlantStatusDB = New PlantStatusDB
                intReutrnValue = objPlantStatusDB.Update(Me)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete() As Int32

            Dim intReutrnValue As Int32
            Dim objPlantStatusDB As PlantStatusDB

            Try
                objPlantStatusDB = New PlantStatusDB
                intReutrnValue = objPlantStatusDB.Delete(Me)
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

                .Append(Constants.PlantStatusConstants.FieldName.PlantStatusID)
                .Append(":")
                .Append(Me.PlantStatusID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantStatusConstants.FieldName.PlantStatusName)
                .Append(":")
                .Append(Me.PlantStatusName)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantStatusConstants.FieldName.PlantStatusDescription)
                .Append(":")
                .Append(Me.PlantStatusDescription)
                .Append(ControlChars.CrLf)

                .Append(Constants.PlantStatusConstants.FieldName.PlantStatusIMSCode)
                .Append(":")
                .Append(Me.PlantStatusIMSCode)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.PlantStatusID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPlantStatus As PlantStatus) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PlantStatusID = objPlantStatus.PlantStatusID) _
                AndAlso (Me.PlantStatusName = objPlantStatus.PlantStatusName) _
                AndAlso (Me.PlantStatusDescription = objPlantStatus.PlantStatusDescription) _
                AndAlso (Me.PlantStatusIMSCode = objPlantStatus.PlantStatusIMSCode)) Then
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
